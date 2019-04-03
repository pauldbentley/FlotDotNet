namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for <see cref="FlotCategory"/> collection initializers.
    /// </summary>
    public static class FlotCategoryCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="FlotCategory"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="category">The category name.</param>
        public static void Add(this ICollection<FlotCategory> collection, string category)
        {
            GuardNotNull(collection);
            collection.Add(new FlotCategory(category));
        }

        /// <summary>
        /// Adds a new <see cref="FlotCategory"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="category">The category name.</param>
        /// <param name="value">The category value.</param>
        public static void Add(this ICollection<FlotCategory> collection, string category, int value)
        {
            GuardNotNull(collection);
            collection.Add(new FlotCategory(category, value));
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