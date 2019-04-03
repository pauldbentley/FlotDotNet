namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for <see cref="FlotDataPoint"/> collection initializers.
    /// </summary>
    public static class FlotDataPointCollectionExtensions
    {
        /// <summary>
        /// Adds a data point to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        public static void Add(this ICollection<FlotDataPoint> collection, double x, double y)
        {
            GuardNotNull(collection);
            collection.Add(new FlotDataPoint(x, y));
        }

        /// <summary>
        /// Adds a data point to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        /// <param name="bottom">The bottom value for the data.</param>
        public static void Add(this ICollection<FlotDataPoint> collection, double x, double y, double bottom)
        {
            GuardNotNull(collection);
            collection.Add(new FlotDataPoint(x, y, bottom));
        }

        /// <summary>
        /// Adds a new <see cref="FlotDataPoint"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="category">The category name.</param>
        /// <param name="value">The category value.</param>
        public static void Add(this ICollection<FlotDataPoint> collection, string category, double value)
        {
            GuardNotNull(collection);
            collection.Add(new FlotDataPoint(category, value));
        }

        private static void GuardNotNull(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}