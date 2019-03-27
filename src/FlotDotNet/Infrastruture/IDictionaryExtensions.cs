namespace FlotDotNet.Infrastruture
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension Add methods for the <see cref="IDictionary{TKey, TValue}"/> collection initializers.
    /// </summary>
    internal static class IDictionaryExtensions
    {
        /// <summary>
        /// Adds a value to the dictionary with a null check
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="ignoreNull">Ignore any null values when adding.</param>
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value, bool ignoreNull)
            where TValue : class
        {
            // add if we have a value
            // or we have a null but we are not ignoring null
            if (value != null || !ignoreNull)
            {
                dictionary.Add(key, value);
            }
        }
    }
}
