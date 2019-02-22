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
        public static void Add(this ICollection<FlotDataPoint> collection, double? x, double? y)
        {
            GuardNotNull(collection);
            collection.Add(new FlotDataPoint(x, y));
        }

        /// <summary>
        /// Adds a data point to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="label">Label for the data point.</param>
        /// <param name="value">Value of the data point.</param>
        public static void Add(this ICollection<FlotDataPoint> collection, string label, double value)
        {
            GuardNotNull(collection);
            collection.Add(new FlotDataPoint(label, value));
        }

        private static void GuardNotNull(ICollection<FlotDataPoint> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
        }
    }
}