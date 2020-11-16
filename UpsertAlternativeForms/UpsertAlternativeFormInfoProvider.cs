using CMS;
using CMS.FormEngine;
using KenticoCommunity.UpsertAlternativeForms;
using KenticoCommunity.UpsertAlternativeForms.Helpers;

[assembly: RegisterCustomProvider(typeof(UpsertAlternativeFormInfoProvider))]

namespace KenticoCommunity.UpsertAlternativeForms
{
    /// <inheritdoc />
    /// <summary>
    /// Kentico custom provider for alternative forms to enable using alternative forms named "upsert"
    /// for all three form modes supported for pages: "insert", "update", and "newculture".
    /// </summary>
    public class UpsertAlternativeFormInfoProvider : AlternativeFormInfoProvider
    {
        /// <inheritdoc />
        /// <summary>
        /// Overrides default Kentico behavior by allowing an alternative form named "upsert" to be used if
        /// forms named "insert", "update", or "newculture" do not exist.
        /// </summary>
        /// <param name="alternativeFormFullName">The provided name of the alternative form</param>
        /// <param name="useHashtable">Optional flag to use a hash table</param>
        /// <returns>An AlternativeFormInfo object</returns>
        protected override AlternativeFormInfo GetInfoByFullName(string alternativeFormFullName, bool useHashtable = true)
        {
            Guard.ArgumentNotNullOrEmpty(alternativeFormFullName, nameof(alternativeFormFullName));

            var providedForm = base.GetInfoByFullName(alternativeFormFullName, useHashtable);
            if (providedForm != null)
            {
                return providedForm;
            }

            if(!AlternativeFormNameHelper.IsBuiltInPageTypeFormName(alternativeFormFullName))
            {
                return null;
            }
            var upsertFormName = AlternativeFormNameHelper.CreateUpsertFullName(alternativeFormFullName);
            return base.GetInfoByFullName(upsertFormName);
        }
    }
}
