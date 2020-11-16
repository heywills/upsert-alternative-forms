using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenticoCommunity.UpsertAlternativeForms.Models
{
    /// <summary>
    /// Hold the two parts of an Alternative Form Full Name in 
    /// parsed components.
    /// </summary>
    internal class AlternativeFormNameParts
    {
        /// <summary>
        /// The class name the alternative form belongs to (e.g. "Custom.MyPageType").
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// The alternative form name (e.g. "Update").
        /// </summary>
        public string FormName { get; set; }
    }
}
