namespace FlotDotNet.Infrastruture
{
    using System;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts Flot objects to JSON.
    /// </summary>
    internal class FlotConverter : JsonConverter
    {
        private const string SerializeMethodName = "Serialize";

        /// <summary>
        /// Gets a value indicating whether this <see cref="FlotConverter"/> can read JSON.
        /// </summary>
        public override bool CanRead => false;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// We assume that any object given this converter can convert.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType) => true;

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // we are assuming the Serialize() method exists
            // it would be a developer error to uses this attribute
            // and not have the method.
            var method = GetSerializeMethod(value.GetType());
            var data = method.Invoke(value, null);
            serializer.Serialize(writer, data);
        }

        private static MethodInfo GetSerializeMethod(Type objectType)
        {
            // see if there is a specific Serialize() method
            var method = objectType.GetMethod(SerializeMethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            return method != null && method.GetParameters().Length == 0
                ? method
                : null;
        }
    }
}
