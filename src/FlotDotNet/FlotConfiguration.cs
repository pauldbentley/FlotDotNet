namespace FlotDotNet
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class FlotConfiguration
    {
        /// <summary>
        /// Gets the settings used when reading JSON in the API.
        /// </summary>
        internal static JsonSerializerSettings SerializerSettings { get; } = BuildSerializerSettings();

        private static JsonSerializerSettings BuildSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
