namespace FlotDotNet.Infrastruture
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Base class for all Flot elements.
    /// </summary>
    internal static class SerializationHelper
    {
        /// <summary>
        /// Serializes the specified object to a JSON string using <see cref="FlotConfiguration.SerializerSettings"/>.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="emptyValueHandling">How empty values are handled during serialization.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string SerializeObject(object value, EmptyValueHandling emptyValueHandling)
        {
            string json = JsonConvert.SerializeObject(value, FlotConfiguration.SerializerSettings);

            bool isNull = json == "null";
            bool isEmpty = json == "{}" || json == "[]";

            if (isNull && FlotConfiguration.SerializerSettings.NullValueHandling == NullValueHandling.Ignore)
            {
                return null;
            }

            if (isEmpty && emptyValueHandling == EmptyValueHandling.Ignore)
            {
                return null;
            }

            return json;
        }

        /// <summary>
        /// Serializes the specified object to a <see cref="JRaw"/> using <see cref="FlotConfiguration.SerializerSettings"/>.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="emptyValueHandling">How empty values are handled during serialization.</param>
        /// <returns>A <see cref="JRaw"/> representation of the object.</returns>
        public static JRaw SerializeObjectRaw(object value, EmptyValueHandling emptyValueHandling)
        {
            string json = SerializeObject(value, emptyValueHandling);

            return json != null
                ? new JRaw(json)
                : null;
        }
    }
}
