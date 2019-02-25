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
            Value = default;
        }

        private AutoValue(T value)
        {
            IsAuto = false;
            Value = value;
        }

        private T Value { get; }

        private bool IsAuto { get; }

        public static implicit operator AutoValue<T>(string value) => new AutoValue<T>(value);

        public static implicit operator AutoValue<T>(T value) => new AutoValue<T>(value);

        public static explicit operator T(AutoValue<T> value) => value.Value;

        internal object Serialize()
        {
            if (IsAuto)
            {
                return Auto;
            }

            return Value;
        }
    }
}
