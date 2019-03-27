﻿namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Configuration for FlotDotNet.
    /// </summary>
    public static class FlotConfiguration
    {
        /// <summary>
        /// Gets the settings used when serializing JSON.
        /// </summary>
        public static JsonSerializerSettings SerializerSettings { get; } = BuildSerializerSettings();

        /// <summary>
        /// Gets the Flot script version.
        /// </summary>
        public static string FlotVersion => "0.8.3";

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
