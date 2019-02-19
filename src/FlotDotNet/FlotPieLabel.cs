namespace FlotDotNet
{
    /// <summary>
    /// Pie slice label.
    /// </summary>
    [FlotProperty]
    public partial class FlotPieLabel : FlotElement
    {
        /// <summary>
        ///  Enable/Disable the labels. This can be set to true, false, or 'auto'. When set to 'auto', it will be set to false if the legend is enabled and true if not.
        /// </summary>
        [FlotProperty(SerializationOptions = FlotSerializationOptions.QuoteValue)]
        public string Show = "auto";

        /// <summary>
        /// Sets the radius at which to place the labels. If value is between 0 and 1 (inclusive) then it will use that as a percentage of the available space (size of the container), otherwise it will use the value as a direct pixel length.
        /// </summary>
        [FlotProperty]
        public double Radius = 1;

        /// <summary>
        /// Hides the labels of any pie slice that is smaller than the specified percentage (ranging from 0 to 1) i.e. a value of '0.03' will hide all slices 3% or less of the total.
        /// </summary>
        [FlotProperty]
        public double Threshold = 0;

        /// <summary>
        /// This function specifies how the positioned labels should be formatted, and is applied after the legend's labelFormatter function. The labels can also still be styled using the class "pieLabel" (i.e. ".pieLabel" or "#graph1 .pieLabel").
        /// The value of this property must be valid JavaScript; it is not quoted by the serialisation.
        /// </summary>
        [FlotProperty]
        public string Formatter = "function(label, series){return '<div style=\"font-size:8pt;text-align:center;padding:2px;color:white;\">'+label+'<br/>'+Math.round(series.percent)+'%</div>';}";

        /// <summary>
        /// Background color of the positioned labels.
        /// </summary>
        [FlotProperty]
        public FlotPieLabelBackground Background = new FlotPieLabelBackground();
    }
}