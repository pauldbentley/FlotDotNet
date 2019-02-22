namespace FlotDotNet.Infrastruture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Used to convert objects which can either be a single item, or a list of items.
    /// Empty collections are output as null.
    /// </summary>
    internal class SingleItemOrListConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="SingleItemOrListConverter"/> can read JSON.
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
        /// This will either be a singe item, or a list of items.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = value as IEnumerable<object>;

            if (collection == null || collection.Count() == 0)
            {
                writer.WriteNull();
            }
            else if (collection.Count() == 1)
            {
                serializer.Serialize(writer, collection.First());
            }
            else
            {
                serializer.Serialize(writer, collection.ToArray());
            }
        }
    }
}
