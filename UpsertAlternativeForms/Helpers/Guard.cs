using System;

namespace KenticoCommunity.UpsertAlternativeForms.Helpers
{
    /// <summary>
    /// Provide helper methods for checking parameter arguments
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws an exception if an argument is null
        /// </summary>
        /// <param name="value">The value to be tested</param>
        /// <param name="name">The name of the argument</param>
        public static void ArgumentNotNull(object value, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = nameof(value);
            }

            if (value == null)
            {
                throw new ArgumentNullException(name, $"Argument { name } must not be null");
            }
        }

        /// <summary>
        /// Throws an exception if a string argument is null or empty
        /// </summary>
        /// <param name="value">The value to be tested</param>
        /// <param name="name">The name of the argument</param>
        public static void ArgumentNotNullOrEmpty(string value, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = nameof(value);
            }

            ArgumentNotNull(value, name);

            if (value == string.Empty)
            {
                throw new ArgumentException($"Argument { name } must not be an empty string", name);
            }
        }
    }
}
