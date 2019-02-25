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
        /// Adds a <see cref="FlotDataPoint"/> to the end of the <see cref="ICollection{FlotData}"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        public static void Add(this ICollection<FlotDataPoint> collection, double x, double y)
        {
            GuardNotNull(collection);
            collection.Add(new FlotDataPoint(x, y));
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