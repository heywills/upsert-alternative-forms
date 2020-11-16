using KenticoCommunity.UpsertAlternativeForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenticoCommunity.UpsertAlternativeForms.Helpers
{
    /// <summary>
    /// Helper class for parsing alternative form full names and checking form name conditions.
    /// </summary>
    internal class AlternativeFormNameHelper
    {
        private const char FormNameDelimiter = '.';
        private const string UpsertFormName = "Upsert";
        // These three alternative form names are the built-in names used for Page Types.
        private static readonly string[] BuiltInPageTypeAlternativeFormNames = { "update", "insert", "newculture" };

        /// <summary>
        /// Parse an alternative form full name (e.g. Namespace.Type.AlternativeFormName) and
        /// return an AltnerativeFormNameParts object.
        /// </summary>
        /// <param name="alternativeFormFullName"></param>
        /// <returns></returns>
        public static AlternativeFormNameParts ParseAlternativeFormFullName(string alternativeFormFullName)
        {
            Guard.ArgumentNotNullOrEmpty(alternativeFormFullName, nameof(alternativeFormFullName));
            var delimiterPosition = alternativeFormFullName.LastIndexOf(FormNameDelimiter);
            if(delimiterPosition < 0)
            {
                throw new ArgumentException("The alternativeFormFullName parameter must be a 3-part name delimited by a '.'.");
            }

            var alternativeFormNameParts = new AlternativeFormNameParts();
            alternativeFormNameParts.ClassName = alternativeFormFullName.Substring(0, delimiterPosition);
            alternativeFormNameParts.FormName = alternativeFormFullName.Substring(delimiterPosition + 1);
            return alternativeFormNameParts;
        }

        /// <summary>
        /// Check an alternative form name and determine if it represents one of the
        /// built-in alternative form names for page types.
        /// </summary>
        /// <param name="alternativeFormFullName"></param>
        /// <returns></returns>
        public static bool IsBuiltInPageTypeFormName(string alternativeFormFullName)
        {
            Guard.ArgumentNotNullOrEmpty(alternativeFormFullName, nameof(alternativeFormFullName));
            var nameParts = AlternativeFormNameHelper.ParseAlternativeFormFullName(alternativeFormFullName);
            return AlternativeFormNameHelper.BuiltInPageTypeAlternativeFormNames.Contains(nameParts.FormName, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// With the provided alternative form full name, create a full name for an 
        /// alternative form named "Upsert" for the same data class.
        /// Example: Namespace.Type.Insert -> Namespace.Type.Upsert
        /// </summary>
        /// <param name="alternativeFormFullName"></param>
        /// <returns></returns>
        public static string CreateUpsertFullName(string alternativeFormFullName)
        {
            Guard.ArgumentNotNullOrEmpty(alternativeFormFullName, nameof(alternativeFormFullName));
            var nameParts = AlternativeFormNameHelper.ParseAlternativeFormFullName(alternativeFormFullName);
            return nameParts.ClassName + FormNameDelimiter + UpsertFormName;
        }
    }
}
