namespace FlotDotNet.Infrastruture
{
    /// <summary>
    /// Specifies empty value handling options for the <see cref="SerializationHelper"/>.
    /// </summary>
    internal enum EmptyValueHandling
    {
        /// <summary>
        /// Include value values when serializing objects.
        /// </summary>
        Include = 0,

        /// <summary>
        /// Ignore null values when serializing objects.
        /// </summary>
        Ignore = 1
    }
}
