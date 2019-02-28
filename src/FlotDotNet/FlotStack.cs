namespace FlotDotNet
{
    using System.Diagnostics;

    /// <summary>
    /// Flot plugin for stacking data sets rather than overlyaing them.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotStack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotStack"/> class with a specified boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        internal FlotStack(bool value)
        {
            BoolValue = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotStack"/> class with a specified string key.
        /// </summary>
        /// <param name="key">The key.</param>
        internal FlotStack(string key)
        {
            StringKey = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotStack"/> class with a specified number key.
        /// </summary>
        /// <param name="key">The key.</param>
        internal FlotStack(int key)
        {
            NumberKey = key;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        internal object Value
        {
            get
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

        private object DebuggerDisplay() => Value;
    }
}
