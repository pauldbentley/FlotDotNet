namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;

    public abstract class TestClass
    {
        private JsonSerializerSettings SerializerSettings { get; } = FlotConfiguration.SerializerSettings;

        protected string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, SerializerSettings);
        }
    }
}
