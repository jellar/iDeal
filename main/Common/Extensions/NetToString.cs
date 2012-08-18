using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UIT.iDeal.Common.Extensions
{
    /// <summary>
    /// Takes variously formatted strings and turns them into words with spaces
    /// </summary>
    public static class NetToString
    {
        static readonly Func<string, string> FromUnderscoreSeparatedWords = methodName => string.Join(" ", methodName.Split(new[] { '_' }));
        static string FromPascalCase(string name)
        {
            var chars = name.Aggregate(
                new List<char>(),
                (list, currentChar) =>
                    {
                        if (currentChar == ' ')
                        {
                            list.Add(currentChar);
                            return list;
                        }

                        if (list.Count == 0)
                        {
                            list.Add(currentChar);
                            return list;
                        }

                        var lastCharacterInTheList = list[list.Count - 1];
                        if (lastCharacterInTheList != ' ')
                        {
                            if (char.IsDigit(lastCharacterInTheList))
                            {
                                if (char.IsLetter(currentChar))
                                    list.Add(' ');
                            }
                            else if (!char.IsLower(currentChar))
                                list.Add(' ');
                        }

                        list.Add(char.ToLower(currentChar, CultureInfo.CurrentCulture));

                        return list;
                    });

            var result = new string(chars.ToArray());
            return result.Replace(" i ", " I "); // I is an exception
        }

        public static Func<string, string> Convert = name => FromPascalCase(FromUnderscoreSeparatedWords(name));
    }
}