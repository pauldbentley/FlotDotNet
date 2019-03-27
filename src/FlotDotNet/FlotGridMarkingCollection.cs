namespace FlotDotNet
{
    using System;
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
    public sealed class FlotGridMarkingCollection : List<FlotGridMarking>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridMarkingCollection"/> class.
        /// </summary>
        public FlotGridMarkingCollection()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridMarkingCollection"/> class with the given markings.
        /// </summary>
        /// <param name="markings">The markings.</param>
        public FlotGridMarkingCollection(IEnumerable<FlotGridMarking> markings)
            : base(markings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridMarkingCollection"/> class with a specified function.
        /// </summary>
        /// <param name="function">The function.</param>
        public FlotGridMarkingCollection(string function)
            : base(0)
        {
            if (function == null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            if (string.IsNullOrWhiteSpace(function))
            {
                throw new ArgumentOutOfRangeException(nameof(function));
            }

            FunctionRaw = new JRaw(function);
        }

        /// <summary>
        /// Gets the function.
        /// </summary>
        [JsonIgnore]
        public string Function => FunctionRaw?.ToString();

        private JRaw FunctionRaw { get; }

        /// <summary>
        /// Creates a new <see cref="FlotGridMarkingCollection"/> with the specified function.
        /// </summary>
        /// <param name="function">The CSS color.</param>
        public static implicit operator FlotGridMarkingCollection(string function) => new FlotGridMarkingCollection(function);

        /// <summary>
        /// Creates a new <see cref="FlotGridMarkingCollection"/> instance with the given ticks.
        /// </summary>
        /// <param name="markings">The markings.</param>
        public static implicit operator FlotGridMarkingCollection(FlotGridMarking[] markings) => new FlotGridMarkingCollection(markings);

        private object Serialize()
        {
            // can be function or array
            if (FunctionRaw != null)
            {
                return FunctionRaw;
            }
            else
            {
                return ToArray();
            }
        }
    }
}
