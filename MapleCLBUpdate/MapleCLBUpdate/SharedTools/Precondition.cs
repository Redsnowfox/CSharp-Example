using System;
using JetBrains.Annotations;

namespace SharedTools {
    public class Precondition {
        [ContractAnnotation("condition:false => halt")]
        public static void Check<T>(bool condition, string message = null) where T : Exception, new() {
            if (condition) {
                return;
            }

            var exception = message == null ? new T() : Activator.CreateInstance(typeof(T), message) as T;
            if (exception == null) {
                throw new T();
            }
            throw exception;
        }

        [ContractAnnotation("o:null => halt")]
        public static void NotNull(object o, string name = null) {
            Check<ArgumentNullException>(o != null, name);
        }

        public static void InRange(int value, int min, int max, string message = "") {
            Check<IndexOutOfRangeException>(value >= min && value <= max,
                string.Concat(message, $"{value} < {min} OR {value} > {max}"));
        }
    }
}
