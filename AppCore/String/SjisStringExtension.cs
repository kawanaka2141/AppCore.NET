using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System {
    public static class SjisStringExtension {
        private static readonly Encoding encoding = Encoding.GetEncoding(
            @"Shift_JIS",
            new EncoderReplacementFallback(@"？"),
            new DecoderReplacementFallback(@"？"));

        public static bool MaxLength(this string self, int max) {
            if(self.IsEmpty()) return true;
            return self.GetSjisByteCount() <= max;
        }

        public static bool FixLength(this string self, int length) {
            if(self.IsEmpty()) return true;
            return self.GetSjisByteCount() == length;
        }

        public static int GetSjisByteCount(this string self) {
            return encoding.GetByteCount(self);
        }

        public static int GetSjisByteCount(this char self) {
            return encoding.GetByteCount(new[] { self });
        }

        public static string SubstringAsSjis(this string self, int startIndex, int length) {
            var offsets = self.GetOffsetBytes();
            var starts = offsets.First(it => startIndex <= it[0])[0];
            var ends = offsets.Last(it => it[1] <= startIndex + length)[1];
            return SubstringByRawByte(self, starts, ends - starts);
        }

        private static IList<int[]> GetOffsetBytes(this string s) {
            var offsets = new List<int[]>(s.Length);  // Why not use Tuple ? => for .NET Framework 3.0

            var starts = 0;
            foreach(var byteLength in s.Select(GetSjisByteCount)) {
                offsets.Add(new[] { starts, starts + byteLength });
                starts += byteLength;
            }

            return offsets;
        }

        private static string SubstringByRawByte(this string s, int startIndex, int length) {
            return encoding.GetString(encoding.GetBytes(s).Skip(startIndex).Take(length).ToArray());
        }
    }
}
