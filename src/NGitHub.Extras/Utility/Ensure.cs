using System;

namespace NGitHub.Extras.Utility {
    internal static class Ensure {
        public static void ArgumentNotNull(Object argument,
                                           String argumentName) {
            if (argument == null) {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void IsTrue(bool condition, String message) {
            if (condition != true) {
                throw new ArgumentException(message);
            }
        }
    }
}
