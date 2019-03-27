namespace FlotDotNet.Infrastruture
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// A value which can either be "auto" or a specific value.
    /// </summary>
    /// <typeparam name="T">The type of specific value.</typeparam>
    [JsonConverter(typeof(FlotConverter))]
    public sealed class AutoValue<T>
    {
        private const string Auto = "auto";

        private AutoValue(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(value) || value != Auto)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            IsAuto = true;
        }

        private AutoValue(T value)
        {
            Value = value;
        }

        private T Value { get; }

        private bool IsAuto { get; }

        /// <summary>
        /// Conversion from <see cref="string"/> to a <see cref="AutoValue{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator AutoValue<T>(string value) => new AutoValue<T>(value);

        /// <summary>
        /// Conversion from a given value to a <see cref="AutoValue{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator AutoValue<T>(T value) => new AutoValue<T>(value);

        /// <summary>
        /// Conversion from <see cref="AutoValue{T}"/> to a given type.
        /// </summary>
        /// <param name="value">The value.</param>
        public static explicit operator T(AutoValue<T> value) => value.Value;

        private object Serialize()
        {
            if (IsAuto)
            {
                return Auto;
            }

            return Value;
        }
    }
}
