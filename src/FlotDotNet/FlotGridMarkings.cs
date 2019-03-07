namespace FlotDotNet
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Markings are used to draw simple lines and rectangular areas in the background of the plot.
    /// You can either specify an array of ranges on the form { xaxis: { from, to }, yaxis: { from, to } }
    /// or with a function that returns such an array given the axes for the plot in an object as the first parameter.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotGridMarkings : List<FlotGridMarking>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridMarkings"/> class.
        /// </summary>
        public FlotGridMarkings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridMarkings"/> class with a specified function.
        /// </summary>
        /// <param name="function">The function.</param>
        public FlotGridMarkings(string function)
        {
            Function = function;
        }

        /// <summary>
        /// Gets the function.
        /// </summary>
        public string Function { get; }

        /// <summary>
        /// Creates a new <see cref="FlotGridMarkings"/> with the specified function.
        /// </summary>
        /// <param name="function">The CSS color.</param>
        public static implicit operator FlotGridMarkings(string function) => new FlotGridMarkings(function);

        private object Serialize()
        {
            // can be function or array
            if (!string.IsNullOrEmpty(Function))
            {
                // this needs to be a raw value
                // as we don't want it quoted
                return new JRaw(Function);
            }
            else
            {
                return ToArray();
            }
        }
    }
}
