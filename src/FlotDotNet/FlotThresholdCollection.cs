namespace FlotDotNet
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of <see cref="FlotThreshold"/> objects.
    /// </summary>
    [JsonConverter(typeof(SingleItemOrListConverter))]
    public class FlotThresholdCollection : List<FlotThreshold>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotThresholdCollection"/> class.
        /// </summary>
        internal FlotThresholdCollection()
        {
        }

        /// <summary>
        /// Adds a new <see cref="FlotThreshold"/> to the end of the <see cref="FlotThresholdCollection"/> with the given values.
        /// </summary>
        /// <param name="below">The below value of the threshold.</param>
        /// <param name="color">The color of the threshold.</param>
        public void Add(decimal below, FlotColor color) => Add(new FlotThreshold(below, color));
    }
}