namespace FlotDotNet.Infrastruture
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts Flot objecs to JSON.
    /// </summary>
    internal class FlotConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="FlotConverter"/> can read JSON.
        /// </summary>
        public override bool CanRead => false;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
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
            var method = SerializationHelper.GetSerializeMethod(value.GetType());
            if (method != null)
            {
                var data = method.Invoke(value, null);
                serializer.Serialize(writer, data);
            }
        }
    }
}
