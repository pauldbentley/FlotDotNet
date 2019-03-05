namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotTickOptions : List<FlotTick>
    {
        public FlotTickOptions()
        {
        }

        public FlotTickOptions(int number)
        {
            Number = number;
        }

        public FlotTickOptions(string function)
        {
            Function = function;
        }

        public int? Number { get; }

        public string Function { get; }

        public static implicit operator FlotTickOptions(int number) => new FlotTickOptions(number);

        public static implicit operator FlotTickOptions(string function) => new FlotTickOptions(function);

        private object Serialize()
        {
            // can be number, array, or function
            if (!string.IsNullOrEmpty(Function))
            {
                // this needs to be a raw value
                // as we don't want it quoted
                return new JRaw(Function);
            }
            else if (Number.HasValue)
            {
                return Number.Value;
            }
            else
            {
                return ToArray();
            }
        }
    }
}