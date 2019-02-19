namespace FlotDotNet
{
    public partial class FlotPie
    {
        /// <summary>
        /// Positioning of the pie chart within the canvas.
        /// </summary>
        [FlotProperty]
        public class FlotPieOffset : FlotElement
        {
            /// <summary>
            /// Pixel distance to move the pie up and down (relative to the center).
            /// </summary>
            [FlotProperty]
            public int Top = 0;

            /// <summary>
            /// Pixel distance to move the pie left and right (relative to the center).
            /// </summary>
            [FlotProperty(SerializationOptions = FlotSerializationOptions.QuoteValue)]
            public string Left = "auto";
        }

    }
}