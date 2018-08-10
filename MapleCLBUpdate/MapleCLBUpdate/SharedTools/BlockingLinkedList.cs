using System.Collections.Generic;
using System.Threading;

namespace SharedTools {
    public class BlockingLinkedList<T> {
        private readonly object accessLock = new object();
        private readonly LinkedList<T> list = new LinkedList<T>();
        private readonly ManualResetEvent waiter = new ManualResetEvent(false);

        public T GetFirst(int timeout = -1) {
            if (!waiter.WaitOne(timeout)) {
                return default(T);
            }
            lock (accessLock) {
                var result = list.First.Value;
                list.RemoveFirst();
                if (list.Count == 0) {
                    waiter.Reset();
                }
                return result;
            }
        }

        public bool TryGetFirst(out T outValue, int timeout = -1) {
            if (!waiter.WaitOne(timeout)) {
                outValue = default(T);
                return false;
            }
            lock (accessLock) {
                outValue = list.First.Value;
                list.RemoveFirst();
                if (list.Count == 0) {
                    waiter.Reset();
                }
            }
            return true;
        }

        public void AddFirst(T item) {
            lock (accessLock) {
                list.AddFirst(item);
            }
            waiter.Set();
        }

        public void AddLast(T item) {
            lock (accessLock) {
                list.AddLast(item);
            }
            waiter.Set();
        }
    }
}
