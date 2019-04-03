namespace FlotDotNet
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a data point with a category.
    /// </summary>
    [JsonArray]
    public sealed class FlotCategoryData : IEnumerable<object>, IFlotDataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotCategoryData"/> class with a category and value.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="value">The value.</param>
        public FlotCategoryData(string category, double value)
        {
            Category = category;
            Value = value;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Gets the value for the y-axis.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Gets the data type of the data item.
        /// </summary>
        public string DataType => nameof(FlotCategoryData);

        /// <summary>
        /// Returns an enumerator that iterates through the data points.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the data points.</returns>
        public IEnumerator<object> GetEnumerator()
        {
            yield return Category;
            yield return Value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the data points.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the data points.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}