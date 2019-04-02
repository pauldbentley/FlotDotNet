namespace FlotDotNet
{
    using System;

    /// <summary>
    /// A category when plotting textual data or categories.
    /// </summary>
    public sealed class FlotCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotCategory"/> class with a given name.
        /// </summary>
        /// <param name="name">The category name.</param>
        public FlotCategory(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotCategory"/> class with a given name and value.
        /// </summary>
        /// <param name="name">The category name.</param>
        /// <param name="value">The value.</param>
        public FlotCategory(string name, int value)
            : this(name)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the category name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value if you need to customize the distances between the categories.
        /// </summary>
        public int? Value { get; }

        /// <summary>
        /// Conversion from <see cref="string"/> to <see cref="FlotCategory"/>.
        /// </summary>
        /// <param name="category">The category.</param>
        public static implicit operator FlotCategory(string category) => new FlotCategory(category);

        /// <summary>
        /// Conversion from <see cref="FlotCategory"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="category">The category.</param>
        public static implicit operator string(FlotCategory category) => category.Name;
    }
}
