using System;
using System.Text.RegularExpressions;

namespace System {
    public static class StringPredicateExtension {
        public static bool IsEmpty(this string self) {
            return string.IsNullOrEmpty(self);
        }

        public static bool Presents(this string self) {
            return !string.IsNullOrEmpty(self);
        }

        public static bool Filled(this string self) {
            if(self == null) return false;
            return self.Trim().Presents();
        }

        public static bool IsDate(this string self) {
            if(self.IsEmpty()) return true;
            return self.Match(@"\A\d{4}[/-]\d{2}[/-]\d{2}\z") && self._IsDateTime();
        }

        public static bool IsDateTime(this string self) {
            if(self.IsEmpty()) return true;
            return self.Match(@"\A\d{4}[/-]\d{2}[/-]\d{2} \d{2}:\d{2}:\d{2}\z") && self._IsDateTime();
        }

        public static bool IsZip(this string self) {
            if(self.IsEmpty()) return true;
            return self.IsNumeric(1, 14);
        }

        public static bool IsAlnum(this string self, int minLength, int maxLength) {
            if(self.IsEmpty()) return true;
            return self.Match(GeneratePattern(@"\A[0-9A-Za-z]\z", minLength, maxLength));
        }

        public static bool IsNumeric(this string self, int minLength, int maxLength) {
            if(self.IsEmpty()) return true;
            return self.Match(GeneratePattern(@"\d", minLength, maxLength));
        }

        public static DateTime? ToDateTime(this string self) {
            return self._IsDateTime() ? (DateTime?)DateTime.Parse(self) : null;
        }

        private static bool Match(this string self, string pattern) {
            if(self.IsEmpty()) return true;
            return Regex.IsMatch(self, pattern);
        }

        private static string GeneratePattern(string chars, int minLength, int maxLength) {
            return string.Format(@"\A{0}{{{1},{2}}}\z", chars, minLength, maxLength);

        }

        private static bool _IsDateTime(this string s) {
            DateTime nouse;
            return DateTime.TryParse(s, out nouse);
        }
    }
}
