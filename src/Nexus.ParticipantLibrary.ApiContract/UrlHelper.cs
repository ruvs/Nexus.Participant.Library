using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus.ParticipantLibrary.ApiContract
{
    internal static class UrlHelper
    {

        public static string ToCommaDelimitedString(this IEnumerable<Guid> guids)
        {
            var stringBuilder = new StringBuilder();
            foreach (Guid key in guids)
            {
                stringBuilder.AppendFormat("{0},", key);
            }
            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}