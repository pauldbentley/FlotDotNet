namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension Add methods for <see cref="FlotScaling"/> collection initializers.
    /// </summary>
    public static class FlotScalingCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="FlotScaling"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="opacity">The opaticy.</param>
        /// <param name="brightness">The brightness.</param>
        public static void Add(this ICollection<FlotScaling> collection, double? opacity, double? brightness)
        {
            GuardNotNull(collection);
            collection.Add(new FlotScaling(opacity, brightness));
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