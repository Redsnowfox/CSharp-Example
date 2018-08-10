using System.Threading;

namespace SharedTools {
    public class Blocking<T> {
        private readonly AutoResetEvent waiter;
        private T value;

        public Blocking() {
            waiter = new AutoResetEvent(false);
        }

        public Blocking(T value) {
            this.value = value;
            waiter = new AutoResetEvent(true);
        }

        public T Get() {
            waiter.WaitOne();
            return value;
        }

        public bool TryGet(out T outValue, int timeout = -1) {
            bool success = waiter.WaitOne(timeout);
            outValue = success ? value : default(T);
            return success;
        }

        public void Set(T value) {
            this.value = value;
            waiter.Set();
        }
    }
}
