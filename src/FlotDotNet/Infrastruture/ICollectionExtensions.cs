namespace FlotDotNet.Infrastruture
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for the <see cref="ICollection{T}"/> collection initializers.
    /// </summary>
    internal static class ICollectionExtensions
    {
        /// <summary>
        /// Adds a value to the collection with a null check
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreNull">Ignore any null values when adding.</param>
        public static void Add<T>(this ICollection<T> collection, T value, bool ignoreNull)
            where T : class
        {
            // add if we have a value
            // or we have a null but we are not ignoring null
            if (value != null || !ignoreNull)
            {
                collection.Add(value);
            }
        }
    }
}
