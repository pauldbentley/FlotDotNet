namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Defines the options for how ticks are displayed on a plot.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotTickOptions : List<FlotTick>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickOptions"/> class.
        /// </summary>
        public FlotTickOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickOptions"/> class with the given ticks.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        public FlotTickOptions(IEnumerable<FlotTick> ticks)
            : base(ticks)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickOptions"/> class with a given number of ticks.
        /// </summary>
        /// <param name="number">The number of ticks.</param>
        public FlotTickOptions(int number)
            : base(0)
        {
            Number = number;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickOptions"/> class with a given tick function.
        /// </summary>
        /// <param name="function">The tick function.</param>
        public FlotTickOptions(string function)
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
        /// Gets the number of ticks.
        /// </summary>
        [JsonIgnore]
        public int? Number { get; }

        /// <summary>
        /// Gets the tick function.
        /// </summary>
        [JsonIgnore]
        public string Function => FunctionRaw?.ToString();

        private JRaw FunctionRaw { get; }

        /// <summary>
        /// Creates a new <see cref="FlotTickOptions"/> instance with the given number of ticks.
        /// </summary>
        /// <param name="number">The number of ticks.</param>
        public static implicit operator FlotTickOptions(int number) => new FlotTickOptions(number);

        /// <summary>
        /// Creates a new <see cref="FlotTickOptions"/> instance with the given tick function.
        /// </summary>
        /// <param name="function">The tick function.</param>
        public static implicit operator FlotTickOptions(string function) => new FlotTickOptions(function);

        /// <summary>
        /// Creates a new <see cref="FlotTickOptions"/> instance with the given ticks.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        public static implicit operator FlotTickOptions(FlotTick[] ticks) => new FlotTickOptions(ticks);

        private object Serialize()
        {
            // can be number, array, or function
            if (FunctionRaw != null)
            {
                return FunctionRaw;
            }
            else if (Number.HasValue)
            {
                return Number;
            }
            else
            {
                return ToArray();
            }
        }
    }
}