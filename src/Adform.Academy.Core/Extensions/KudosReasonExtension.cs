using Adform.Academy.Core.Enumerators;
using System.ComponentModel;

namespace Adform.Academy.Core.Extensions
{
    public static class KudosReasonExtension
    {
        public static string ToDescriptionString(this KudosReason val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
