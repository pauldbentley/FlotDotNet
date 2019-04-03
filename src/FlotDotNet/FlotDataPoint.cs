﻿namespace FlotDotNet
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an x,y-pair to be plotted on a chart.
    /// </summary>
    [JsonArray]
    public sealed class FlotDataPoint : IEnumerable<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with specific x-y values.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        public FlotDataPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with specific x-y and bottom values.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        /// <param name="bottom">The bottom value for the data.</param>
        public FlotDataPoint(double x, double y, double bottom)
            : this(x, y)
        {
            Bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with a specific category and value.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="value">The value.</param>
        public FlotDataPoint(string category, double value)
        {
            Category = category;
            Y = value;
        }

        /// <summary>
        /// Gets the value for the x-axis.
        /// </summary>
        public double? X { get; }

        /// <summary>
        /// Gets the value for the y-axis.
        /// </summary>
        public double? Y { get; }

        /// <summary>
        /// Gets a bottom co-ordinate.
        /// For filled lines and bars, you can specify a third coordinate which is the bottom of the filled area/bar.
        /// </summary>
        public double? Bottom { get; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Returns an enumerator that iterates through the data points.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the data points.</returns>
        public IEnumerator<object> GetEnumerator()
        {
            // category data
            if (!string.IsNullOrEmpty(Category))
            {
                yield return Category;
                yield return Y;
            }

            // standard data
            else
            {
                yield return X;
                yield return Y;

                if (Bottom.HasValue)
                {
                    yield return Bottom;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the data points.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the data points.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}