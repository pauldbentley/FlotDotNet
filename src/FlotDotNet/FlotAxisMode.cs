﻿namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// Defines how the values on axes are displayed.
    /// </summary>
    public sealed class FlotAxisMode : FlotEnum
    {
        /// <summary>
        /// The axis is displayed as decimal numbers.
        /// </summary>
        public static readonly FlotAxisMode Decimal = new FlotAxisMode(nameof(Decimal));

        /// <summary>
        /// The axis is displayed as time.
        /// </summary>
        public static readonly FlotAxisMode Time = new FlotAxisMode(nameof(Time));

        /// <summary>
        /// The axis is displayed as categories.
        /// </summary>
        public static readonly FlotAxisMode Categories = new FlotAxisMode(nameof(Categories));

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotAxisMode"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        private FlotAxisMode(string value)
            : base(value)
        {
        }
    }
}