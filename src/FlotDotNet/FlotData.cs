namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    [JsonConverter(typeof(FlotConverter))]
    public class FlotData
    {
    }
}