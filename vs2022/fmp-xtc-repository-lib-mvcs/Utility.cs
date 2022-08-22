using System;
using System.Collections.Generic;
using System.Text;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    public static class Utility
    {
        public static string SizeToString(ulong _size)
        {
            if (_size < 1024L)
                return string.Format("{0}B", _size);
            if (_size < 1024L * 1024)
                return string.Format("{0}K", _size / 1024);
            if (_size < 1024L * 1024 * 1024)
                return string.Format("{0}M", _size / 1024 / 1024);
            if (_size < 1024L * 1024 * 1024 * 1024)
                return string.Format("{0}G", _size / 1024 / 1024 / 1024);
            return string.Format("{0}T", _size / 1024 / 1024 / 1024 / 1024);
        }

        public static string TimestampToString(long _timestamp)
        {
            DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(_timestamp);
            return dto.LocalDateTime.ToString("yyyy/MM/dd");
        }
    }
}
