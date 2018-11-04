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
            return Regex.Escape(str.Replace(' ', '-'));
        }
    }
}
