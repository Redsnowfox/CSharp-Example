using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SharedTools {
    public class MultiKeyDictionary<TK, TL, TV> {
        internal readonly Dictionary<TK, TV> BaseDictionary = new Dictionary<TK, TV>();
        internal readonly Dictionary<TK, TL> PrimaryToSubkeyMapping = new Dictionary<TK, TL>();
        private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
        internal readonly Dictionary<TL, TK> SubDictionary = new Dictionary<TL, TK>();

        public TV this[TL subKey] {
            get {
                TV item;
                if (TryGetValue(subKey, out item)) {
                    return item;
                }

                throw new KeyNotFoundException("sub key not found: " + subKey);
            }
        }

        public TV this[TK primaryKey] {
            get {
                TV item;
                if (TryGetValue(primaryKey, out item)) {
                    return item;
                }

                throw new KeyNotFoundException("primary key not found: " + primaryKey);
            }
        }

        public List<TV> Values {
            get {
                readerWriterLock.EnterReadLock();
                try {
                    return BaseDictionary.Values.ToList();
                } finally {
                    readerWriterLock.ExitReadLock();
                }
            }
        }

        public int Count {
            get {
                readerWriterLock.EnterReadLock();
                try {
                    return BaseDictionary.Count;
                } finally {
                    readerWriterLock.ExitReadLock();
                }
            }
        }

        public void Associate(TL subKey, TK primaryKey) {
            readerWriterLock.EnterUpgradeableReadLock();

            try {
                if (!BaseDictionary.ContainsKey(primaryKey)) {
                    throw new KeyNotFoundException($"The base dictionary does not contain the key '{primaryKey}'");
                }

                if (PrimaryToSubkeyMapping.ContainsKey(primaryKey)) // Remove the old mapping first
                {
                    readerWriterLock.EnterWriteLock();

                    try {
                        if (SubDictionary.ContainsKey(PrimaryToSubkeyMapping[primaryKey])) {
                            SubDictionary.Remove(PrimaryToSubkeyMapping[primaryKey]);
                        }

                        PrimaryToSubkeyMapping.Remove(primaryKey);
                    } finally {
                        readerWriterLock.ExitWriteLock();
                    }
                }

                SubDictionary[subKey] = primaryKey;
                PrimaryToSubkeyMapping[primaryKey] = subKey;
            } finally {
                readerWriterLock.ExitUpgradeableReadLock();
            }
        }

        public bool TryGetValue(TL subKey, out TV val) {
            val = default(TV);

            readerWriterLock.EnterReadLock();

            try {
                TK primaryKey;
                if (SubDictionary.TryGetValue(subKey, out primaryKey)) {
                    return BaseDictionary.TryGetValue(primaryKey, out val);
                }
            } finally {
                readerWriterLock.ExitReadLock();
            }

            return false;
        }

        public bool TryGetValue(TK primaryKey, out TV val) {
            readerWriterLock.EnterReadLock();

            try {
                return BaseDictionary.TryGetValue(primaryKey, out val);
            } finally {
                readerWriterLock.ExitReadLock();
            }
        }

        public bool ContainsKey(TL subKey) {
            TV val;
            return TryGetValue(subKey, out val);
        }

        public bool ContainsKey(TK primaryKey) {
            TV val;
            return TryGetValue(primaryKey, out val);
        }

        public void Remove(TK primaryKey) {
            readerWriterLock.EnterWriteLock();

            try {
                if (PrimaryToSubkeyMapping.ContainsKey(primaryKey)) {
                    if (SubDictionary.ContainsKey(PrimaryToSubkeyMapping[primaryKey])) {
                        SubDictionary.Remove(PrimaryToSubkeyMapping[primaryKey]);
                    }
                    PrimaryToSubkeyMapping.Remove(primaryKey);
                }
                BaseDictionary.Remove(primaryKey);
            } finally {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void Remove(TL subKey) {
            readerWriterLock.EnterWriteLock();
            try {
                BaseDictionary.Remove(SubDictionary[subKey]);
                PrimaryToSubkeyMapping.Remove(SubDictionary[subKey]);
                SubDictionary.Remove(subKey);
            } finally {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void Add(TK primaryKey, TV val) {
            readerWriterLock.EnterWriteLock();
            try {
                BaseDictionary.Add(primaryKey, val);
            } finally {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void Add(TK primaryKey, TL subKey, TV val) {
            Add(primaryKey, val);
            Associate(subKey, primaryKey);
        }

        public TV[] CloneValues() {
            readerWriterLock.EnterReadLock();
            try {
                TV[] values = new TV[BaseDictionary.Values.Count];
                BaseDictionary.Values.CopyTo(values, 0);

                return values;
            } finally {
                readerWriterLock.ExitReadLock();
            }
        }

        public TK[] ClonePrimaryKeys() {
            readerWriterLock.EnterReadLock();
            try {
                TK[] values = new TK[BaseDictionary.Keys.Count];
                BaseDictionary.Keys.CopyTo(values, 0);

                return values;
            } finally {
                readerWriterLock.ExitReadLock();
            }
        }

        public TL[] CloneSubKeys() {
            readerWriterLock.EnterReadLock();
            try {
                TL[] values = new TL[SubDictionary.Keys.Count];
                SubDictionary.Keys.CopyTo(values, 0);

                return values;
            } finally {
                readerWriterLock.ExitReadLock();
            }
        }

        public void Clear() {
            readerWriterLock.EnterWriteLock();
            try {
                BaseDictionary.Clear();
                SubDictionary.Clear();
                PrimaryToSubkeyMapping.Clear();
            } finally {
                readerWriterLock.ExitWriteLock();
            }
        }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator() {
            readerWriterLock.EnterReadLock();
            try {
                return BaseDictionary.GetEnumerator();
            } finally {
                readerWriterLock.ExitReadLock();
            }
        }
    }
}
