using System;

namespace FanArtPortable
{
    internal static class ExtensionMethods
    {
        private const string EndOfFilm = "\":{\"";

        internal static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        internal static string FixJson(this string originalJson)
        {
            var fixedJson = originalJson.ReplaceFirst(EndOfFilm, "\",\"Details\":{\"")
                                        .ReplaceFirst("{", "{\"Item\":{\"Name\":");
            fixedJson += "}";

            return fixedJson;
        }
    }
}
