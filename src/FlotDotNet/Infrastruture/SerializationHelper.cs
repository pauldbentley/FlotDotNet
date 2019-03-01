namespace FlotDotNet.Infrastruture
{
    using System;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Helper class for serialization.
    /// </summary>
    internal static class SerializationHelper
    {
        private const string SerializeMethodName = "Serialize";

        private const string ShouldSerializeMethodPrefix = "ShouldSerialize";

        /// <summary>
        /// Gets the serialize method from the given type.
        /// </summary>
        /// <param name="objectType">The type.</param>
        /// <returns>A <see cref="MethodInfo"/> of the serialize method if it exists; otherwise, null.</returns>
        public static MethodInfo GetSerializeMethod(Type objectType)
        {
            // see if there is a specific Serialize() method
            // this can be private or internal
            var method = objectType.GetMethod(SerializeMethodName, BindingFlags.NonPublic | BindingFlags.Instance);

            return method != null && method.GetParameters().Length == 0
                ? method
                : null;
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

            // see if there is a specific ShouldSerialize() method on the value
            // this can be private or internal
            var shouldSerializeMethod = objectType.GetMethod(ShouldSerializeMethodPrefix, BindingFlags.NonPublic | BindingFlags.Instance);
            if (shouldSerializeMethod != null)
            {
                // this is for the whole value
                // so we don't need to check any further
                // if this is true
                if ((bool)shouldSerializeMethod.Invoke(value, null))
                {
                    return true;
                }
            }

            // go through each property
            // these can be private or internal
            // as we need to check the attributes
            foreach (var property in objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                // check for JsonIgnore
                var jsonIgnore = property.GetCustomAttribute<JsonIgnoreAttribute>();

                if (jsonIgnore != null)
                {
                    continue;
                }

                // for private properties
                // we check if we have a JsonProperty attribute
                if (property.GetMethod.IsPrivate)
                {
                    var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();

                    // if there is an attribute
                    // this private property will be serialized if it has a value
                    // so if there isn't an attribute
                    // it can be ignored
                    if (jsonProperty == null)
                    {
                        continue;
                    }
                }

                // and test if we should serialize the value.
                // once one property needs serializing we return true.
                var propertyValue = property.GetValue(value);

                // see if there is a specific check on the property
                // Json.Net requires this to be public
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

        /// <summary>
        /// Checks if the given value should be serialized and either returns the value of a default.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <returns><paramref name="value"/> if the <paramref name="value"/> should be serialize, otherwise, a default value.</returns>
        public static T ShouldSerializeOrDefault<T>(T value) => ShouldSerialize(value) ? value : default;
    }
}
