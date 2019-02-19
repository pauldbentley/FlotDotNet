namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotTick
    {
        public FlotTick(double value)
        {
            Value = value;
        }

        public FlotTick(double value, string label)
            : this(value)
        {
            Label = label;
        }

        public FlotTick(double value, double timeLabel)
            : this(value)
        {
            TimeLabel = timeLabel;
        }

        public double Value { get; }

        public string Label { get; }

        public double? TimeLabel { get; }

        public static implicit operator FlotTick(double value) => new FlotTick(value);

        internal object Serialize()
        {
            if (string.IsNullOrEmpty(Label) && !TimeLabel.HasValue)
            {
                // just a value
                return Value;
            }
            else
            {
                // a value and label
                var array = new List<object>
                {
                    Value
                };

                if (!string.IsNullOrEmpty(Label))
                {
                    array.Add(Label);
                }
                else
                {
                    array.Add(TimeLabel);
                }

                return array;
            }
        }

        private object DebuggerDisplay() => Value;
    }
}