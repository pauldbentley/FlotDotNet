namespace FlotDotNet
{
    /// <summary>
    /// Pie slice label background.
    /// </summary>
    [FlotProperty]
    public class FlotPieLabelBackground : FlotElement
    {
        /// <summary>
        /// Colour of the label background.
        /// </summary>
        [FlotProperty(SerializationOptions = FlotSerializationOptions.QuoteValue)]
        public string Color = "#000";

        /// <summary>
        /// Opacity of the label background
        /// </summary>
        [FlotProperty]
        public double Opacity = 0.5;
    }
}