namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// A tick on a chart series.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotTick
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTick"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public FlotTick(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTick"/> class with a specified value and label.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="label">The label.</param>
        public FlotTick(double value, string label)
            : this(value)
        {
            Label = label;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTick"/> class with a specified value and time label.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="timeLabel">The time label.</param>
        public FlotTick(double value, double timeLabel)
            : this(value)
        {
            TimeLabel = timeLabel;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Gets the label.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Gets the time label.
        /// </summary>
        public double? TimeLabel { get; }

        private object Serialize()
        {
            var array = new List<object>
            {
                Value
            };

            if (!string.IsNullOrEmpty(Label))
            {
                array.Add(Label);
            }

            if (TimeLabel.HasValue)
            {
                array.Add(TimeLabel);
            }

            return array.Count == 1
                ? array[0]
                : array;
        }

        private object DebuggerDisplay()
        {
            if (!TimeLabel.HasValue && string.IsNullOrEmpty(Label))
            {
                return Value;
            }

            if (TimeLabel.HasValue)
            {
                return new { Value, TimeLabel };
            }

            return new { Value, Label };
        }
    }
}