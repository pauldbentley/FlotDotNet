namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Flot plugin for stacking data sets rather than overlyaing them.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotStack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotStack"/> class with a boolean key.
        /// </summary>
        /// <param name="key">The key.</param>
        public FlotStack(bool key)
        {
            BooleanKey = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotStack"/> class with a string key.
        /// </summary>
        /// <param name="key">The key.</param>
        public FlotStack(string key)
        {
            StringKey = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotStack"/> class with a numeric key.
        /// </summary>
        /// <param name="key">The key.</param>
        public FlotStack(int key)
        {
            NumericKey = key;
        }

        /// <summary>
        /// Gets the boolean key.
        /// </summary>
        public bool? BooleanKey { get; }

        /// <summary>
        /// Gets the string key.
        /// </summary>
        public string StringKey { get; }

        /// <summary>
        /// Gets the numeric key.
        /// </summary>
        public int? NumericKey { get; }

        /// <summary>
        /// Creates a <see cref="FlotStack"/> from the specified boolean value.
        /// </summary>
        /// <param name="key">The key.</param>
        public static implicit operator FlotStack(bool key) => new FlotStack(key);

        /// <summary>
        /// Creates a <see cref="FlotStack"/> from the specified string key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static implicit operator FlotStack(string key) => new FlotStack(key);

        /// <summary>
        /// Creates a <see cref="FlotStack"/> from the specified number key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static implicit operator FlotStack(int key) => new FlotStack(key);

        /// <summary>
        /// Serialized the <see cref="FlotStack"/> to an object for JSON output.
        /// </summary>
        /// <returns>An object for JSON output.</returns>
        private object Serialize()
        {
            if (BooleanKey.HasValue)
            {
                return BooleanKey;
            }

            if (NumericKey.HasValue)
            {
                return NumericKey;
            }

            return StringKey;
        }

        private object DebuggerDisplay() => Serialize();
    }
}
