using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sabia.Api.Util
{
    public static class StringUtil
    {
        public static string ToSlug(this string str)
        {
            return Regex.Escape(str.Replace(' ', '-').Replace('ç','c').Replace('ã','a').Replace('á','a')
                .Replace('ó','o').Replace('é','e').Replace('â','a').Replace('ô','o'));
        }
    }
}
