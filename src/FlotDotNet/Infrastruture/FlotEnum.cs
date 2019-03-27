namespace FlotDotNet.Infrastruture
{
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// An enumeration value.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public abstract class FlotEnum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotEnum"/> class with a specific value.
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        internal FlotEnum(string value)
            : this(value, value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotEnum"/> class with a specific name and value.
        /// </summary>
        /// <param name="name">The enumeration name.</param>
        /// <param name="value">The enumeration value.</param>
        internal FlotEnum(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets the enumeration name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the enumeration value.
        /// </summary>
        public string Value { get; }

        private protected object Serialize() => Value.ToLowerInvariant();

        private object DebuggerDisplay() => Name;
    }
}