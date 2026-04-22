using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleCommandSet.Extensions
{
    /// <summary>
    /// Extension methods that provide cross-version compatibility for the Revit API.
    /// </summary>
    public static class RevitApiCompatibilityExtensions
    {
        // Cache reflection results to improve performance
        private static readonly Lazy<PropertyInfo> ElementIdValueProperty =
            new Lazy<PropertyInfo>(() => typeof(ElementId).GetProperty("Value"));

        private static readonly Lazy<PropertyInfo> ElementIdIntegerValueProperty =
            new Lazy<PropertyInfo>(() => typeof(ElementId).GetProperty("IntegerValue"));

        /// <summary>
        /// Get the integer value of an ElementId in a version-compatible way.
        /// </summary>
        public static int GetIdValue(this ElementId id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            // First check whether the Value property is available (Revit 2022+)
            if (ElementIdValueProperty.Value != null)
            {
                try
                {
                    return (int)ElementIdValueProperty.Value.GetValue(id);
                }
                catch
                {
                    // On failure, fall back to IntegerValue
                }
            }

            // Use IntegerValue (older versions of Revit)
            return id.IntegerValue;
        }

        /// <summary>
        /// Get the current Revit version number for the document.
        /// </summary>
        public static int GetRevitVersionNumber(this Document doc)
        {
            if (doc == null)
                throw new ArgumentNullException(nameof(doc));

            string versionString = doc.Application.VersionNumber;

            if (int.TryParse(versionString, out int versionNumber))
            {
                return versionNumber;
            }
            return 0;
        }

    }
}
