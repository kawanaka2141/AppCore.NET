namespace System {
    public static class DateTimeFormatExtension {
        public static string ToYYYYMMDD(this DateTime self) {
            return self.ToString("yyyyMMdd");
        }
    }
}
