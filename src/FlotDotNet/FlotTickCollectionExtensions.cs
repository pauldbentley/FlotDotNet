namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for <see cref="FlotTick"/> collection initializers.
    /// </summary>
    public static class FlotTickCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="FlotThreshold"/> to the end of the <see cref="ICollection{T}"/> with the given value.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="value">The value.</param>
        public static void Add(this ICollection<FlotTick> collection, double value)
        {
            GuardNotNull(collection);
            collection.Add(new FlotTick(value));
        }

        /// <summary>
        /// Adds a new <see cref="FlotThreshold"/> to the end of the <see cref="ICollection{T}"/> with the given value and label.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="value">The value.</param>
        /// <param name="label">The label.</param>
        public static void Add(this ICollection<FlotTick> collection, double value, string label)
        {
            GuardNotNull(collection);
            collection.Add(new FlotTick(value, label));
        }

        /// <summary>
        /// Adds a new <see cref="FlotThreshold"/> to the end of the <see cref="ICollection{T}"/> with the given value and time label.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeLabel">The time label.</param>
        public static void Add(this ICollection<FlotTick> collection, double value, double timeLabel)
        {
            GuardNotNull(collection);
            collection.Add(new FlotTick(value, timeLabel));
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