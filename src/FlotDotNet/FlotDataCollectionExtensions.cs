namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for <see cref="FlotData"/> collection initializers.
    /// </summary>
    public static class FlotDataCollectionExtensions
    {
        /// <summary>
        /// Adds a <see cref="FlotChartData"/> to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        public static void Add(this ICollection<FlotData> collection, double x, double y)
        {
            GuardNotNull(collection);
            collection.Add(new FlotChartData(x, y));
        }

        /// <summary>
        /// Adds a <see cref="FlotChartData"/> to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        public static void Add(this ICollection<FlotChartData> collection, double x, double y)
        {
            GuardNotNull(collection);
            collection.Add(new FlotChartData(x, y));
        }

        /// <summary>
        /// Adds a <see cref="FlotPieData"/> to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="label">Label for the data point.</param>
        /// <param name="value">Value of the data point.</param>
        public static void Add(this ICollection<FlotData> collection, string label, double value)
        {
            GuardNotNull(collection);
            collection.Add(new FlotPieData(label, value));
        }

        /// <summary>
        /// Adds a <see cref="FlotPieData"/> to the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="label">Label for the data point.</param>
        /// <param name="value">Value of the data point.</param>
        public static void Add(this ICollection<FlotPieData> collection, string label, double value)
        {
            GuardNotNull(collection);
            collection.Add(new FlotPieData(label, value));
        }

        private static void GuardNotNull(object collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
        }
    }
}