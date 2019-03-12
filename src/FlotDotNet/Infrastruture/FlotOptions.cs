namespace FlotDotNet.Infrastruture
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the base options available to flot option elements
    /// </summary>
    public abstract class FlotOptions
    {
        /// <summary>
        /// Gets or sets a flag which indicates that the element should be shown.
        /// </summary>
        public bool? Show
        {
            get => (bool?)GetValue(nameof(Show));
            set => SetValue(nameof(Show), value);
        }

        /// <summary>
        /// Gets or sets the thickness of the line or outline in pixels. You can set it to 0 to prevent a line or outline from being drawn; this will also hide the shadow.
        /// </summary>
        public int? LineWidth
        {
            get => (int?)GetValue(nameof(LineWidth));
            set => SetValue(nameof(LineWidth), value);
        }

        /// <summary>
        /// Gets or sets the whether the shape should be filled.
        /// For lines, this produces area graphs.
        /// You can adjust the opacity of the fill by setting fill to a number between 0 (fully transparent) and 1 (fully opaque).
        /// </summary>
        public FlotFill Fill
        {
            get => (FlotFill)GetValue(nameof(Fill));
            set => SetValue(nameof(Fill), value);
        }

        /// <summary>
        /// Gets a value indicating whether there are any options with a value.
        /// </summary>
        [JsonIgnore]
        public virtual bool HasValue => Values.Count > 0;

        /// <summary>
        /// Gets a <see cref="Dictionary{TKey, TValue}"/> of the options set.
        /// </summary>
        protected Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets an option value.
        /// </summary>
        /// <param name="name">The name of the option.</param>
        /// <param name="value">The value of the option.</param>
        protected void SetValue(string name, object value)
        {
            if (value == null)
            {
                Values.Remove(name);
            }
            else
            {
                Values[name] = value;
            }
        }

        /// <summary>
        /// Gets the value of an option.
        /// </summary>
        /// <param name="name">The name of the option.</param>
        /// <returns>The value of the option.</returns>
        protected object GetValue(string name)
        {
            return Values.TryGetValue(name, out object value)
              ? value
              : null;
        }
    }
}