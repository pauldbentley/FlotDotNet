namespace FlotDotNet
{
    /// <summary>
    /// Defines the align options for flot elements.
    /// </summary>
    public sealed class FlotBarAlign : FlotEnum
    {
        /// <summary>
        /// Left aligned.
        /// </summary>
        public static readonly FlotBarAlign Left = new FlotBarAlign(nameof(Left));

        /// <summary>
        /// Right aligned.
        /// </summary>
        public static readonly FlotBarAlign Right = new FlotBarAlign(nameof(Right));

        /// <summary>
        /// Center aligned.
        /// </summary>
        public static readonly FlotBarAlign Center = new FlotBarAlign(nameof(Center));

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotBarAlign"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        private FlotBarAlign(string value)
            : base(value)
        {
        }
    }
}
