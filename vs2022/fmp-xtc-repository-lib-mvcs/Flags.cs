using System;
using System.Collections.Generic;
using System.Text;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    public class Flags
    {
        public const ulong LOCK = 1;

        public static bool HasFlag(ulong _flags, ulong _flag)
        {
            return (_flags & _flag) == _flag;
        }

        public static ulong AddFlag(ulong _flags, ulong _flag)
        {
            return _flags | _flag;
        }

        public static ulong RemoveFlag(ulong _flags, ulong _flag)
        {
            return _flags & (~_flag);
        }
    }
}
