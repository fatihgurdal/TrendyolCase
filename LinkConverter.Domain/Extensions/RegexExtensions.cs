using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinkConverter.Domain.Extensions
{
    public static class RegexExtensions
    {
        public static IEnumerable<Match> GetRegexMatch(this string input, string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var matchList = regex.Matches(input);
            return matchList.AsEnumerable();
        }
    }
}
