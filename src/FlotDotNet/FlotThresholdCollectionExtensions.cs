namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for <see cref="FlotThreshold"/> collection initializers.
    /// </summary>
    public static class FlotThresholdCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="FlotThreshold"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="below">The below value of the threshold.</param>
        /// <param name="color">The color of the threshold.</param>
        public static void Add(this ICollection<FlotThreshold> collection, decimal below, FlotColor color)
        {
            GuardNotNull(collection);
            collection.Add(new FlotThreshold(below, color));
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