namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// A Flot data item.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    public abstract class FlotData
    {
    }
}