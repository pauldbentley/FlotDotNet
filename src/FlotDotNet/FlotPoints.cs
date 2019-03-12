namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Specific points options
    /// </summary>
    public sealed class FlotPoints : FlotOptions
    {
        /// <summary>
        /// Gets or sets the radius of the symbol.
        /// </summary>
        public int? Radius
        {
            get => (int?)GetValue(nameof(Radius));
            set => SetValue(nameof(Radius), value);
        }

        /// <summary>
        /// Gets or sets the symbol.
        /// Value can be "circle" or a function callback.
        /// </summary>
        [JsonIgnore]
        public string Symbol
        {
            get => (string)GetValue(nameof(Symbol));
            set => SetValue(nameof(Symbol), value);
        }

        /// <summary>
        /// Gets or sets the fill color.
        /// Value can be null or color/gradient.
        /// </summary>
        public FlotColor FillColor
        {
            get => (FlotColor)GetValue(nameof(FillColor));
            set => SetValue(nameof(FillColor), value);
        }

        [JsonProperty(PropertyName = "symbol")]
        private object SymbolObject
        {
            get
            {
                if (Symbol == null)
                {
                    return null;
                }

                if (Symbol == "circle")
                {
                    return Symbol;
                }

                return new JRaw(Symbol);
            }
        }
    }
}