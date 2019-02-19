namespace FlotDotNet.Infrastruture
{
    using System;
    using Newtonsoft.Json;

    internal class FlotConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return SerializationHelper.GetSerializeMethod(objectType) != null;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = SerializationHelper.GetSerializeMethod(value.GetType());
            if (method != null)
            {
                var data = method.Invoke(value, null);
                serializer.Serialize(writer, data);
            }
            else
            {
                throw new ArgumentException("Type does not define " + SerializationHelper.SerializeMethodName + "() method.", nameof(value));
            }
        }
    }
}
