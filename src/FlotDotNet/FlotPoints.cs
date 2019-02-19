namespace FlotDotNet
{
    public sealed class FlotPoints : FlotOptions
    {
        /// <summary>
        /// The radius of the symbol
        /// </summary>
        public int? Radius { get; set; }

        /// <summary>
        /// Value can be "circle" or function
        /// </summary>
        public string Symbol { get; set; }
    }
}