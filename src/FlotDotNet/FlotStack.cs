namespace FlotDotNet
{
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
        private FlotStack(bool value)
        {
            BoolValue = value;
        }

        private FlotStack(string key)
        {
            StringKey = key;
        }

        private FlotStack(int key)
        {
            NumberKey = key;
        }

        private bool? BoolValue { get; set; }

        private string StringKey { get; set; }

        private int? NumberKey { get; set; }

        /// <summary>
        /// Creates a <see cref="FlotStack"/> from the specified boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator FlotStack(bool value) => new FlotStack(value);

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
        internal object Serialize()
        {
            if (BoolValue.HasValue)
            {
                return BoolValue;
            }

            if (NumberKey.HasValue)
            {
                return NumberKey;
            }

            return StringKey;
        }

        private object DebuggerDisplay() => Serialize();
    }
}
