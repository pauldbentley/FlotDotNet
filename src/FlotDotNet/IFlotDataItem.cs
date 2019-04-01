namespace FlotDotNet
{
    /// <summary>
    /// Allows data to be added to a chart.
    /// </summary>
    public interface IFlotDataItem
    {
        /// <summary>
        /// Gets the data type of the data item.
        /// </summary>
        string DataType { get; }
    }
}
