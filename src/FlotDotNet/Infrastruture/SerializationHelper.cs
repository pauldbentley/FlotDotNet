namespace FlotDotNet.Infrastruture
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Helper class for serialization.
    /// </summary>
    internal static class SerializationHelper
    {
        /// <summary>
        /// The name of the Serialize method.
        /// </summary>
        public const string SerializeMethodName = "Serialize";

        /// <summary>
        /// The prefix of the ShouldSerialize method name.
        /// </summary>
        public const string ShouldSerializeMethodPrefix = "ShouldSerialize";

        /// <summary>
        /// Gets the serialize method from the given type.
        /// </summary>
        /// <param name="objectType">The type.</param>
        /// <returns>A <see cref="MethodInfo"/> of the serialize method if it exists; otherwise, null.</returns>
        public static MethodInfo GetSerializeMethod(Type objectType)
        {
            var method = objectType.GetMethod(SerializeMethodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            if (method != null && method.GetParameters().Length == 0)
            {
                return method;
            }

            return null;
        }

        /// <summary>
        /// Checks if the given value should be serialized.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>true if the value should be serialize; otherwise, false.</returns>
        public static bool ShouldSerialize(object value)
        {
            // we don't serialize nulls
            if (value == null)
            {
                return false;
            }

            var objectType = value.GetType();

            // see if there is a specific serialize method
            var method = GetSerializeMethod(value.GetType());
            if (method != null)
            {
                var data = method.Invoke(value, null);
                return data != null;
            }

            // go through each property
            foreach (var property in objectType.GetProperties())
            {
                // check for JsonIgnore
                var ignore = property.GetCustomAttribute<JsonIgnoreAttribute>();

                if (ignore != null)
                {
                    continue;
                }

                // and test if we should serialize the value.
                // once one property needs serializing we return true.
                var propertyValue = property.GetValue(value);

                // see if there is a specific check on the property
                var shouldSerializePropertyMethod = objectType.GetMethod(ShouldSerializeMethodPrefix + property.Name);

                if (shouldSerializePropertyMethod != null)
                {
                    // specific check
                    if ((bool)shouldSerializePropertyMethod.Invoke(value, null))
                    {
                        return true;
                    }
                }
                else if (propertyValue != null)
                {
                    // general null check
                    return true;
                }
            }

            return false;
        }
    }
}
