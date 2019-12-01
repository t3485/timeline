using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports
{
    public class ZCFZComparer : IEqualityComparer<ZCFZ>
    {
        public bool Equals(ZCFZ x, ZCFZ y)
        {
            if (x != null && y != null && x.REPORTDATE == y.REPORTDATE)
                return true;
            return false;
        }

        public int GetHashCode(ZCFZ obj)
        {
            return obj.REPORTDATE.GetHashCode();
        }

        private static ZCFZComparer comparer;

        public static ZCFZComparer Get()
        {
            if (comparer == null)
            {
                comparer = new ZCFZComparer();
            }
            return comparer;
        }
    }

    public class LRBComparer : IEqualityComparer<LRB>
    {
        public bool Equals(LRB x, LRB y)
        {
            if (x != null && y != null && x.REPORTDATE == y.REPORTDATE)
                return true;
            return false;
        }

        public int GetHashCode(LRB obj)
        {
            return obj.REPORTDATE.GetHashCode();
        }

        private static LRBComparer comparer;

        public static LRBComparer Get()
        {
            if (comparer == null)
            {
                comparer = new LRBComparer();
            }
            return comparer;
        }
    }
    public class XJLLBComparer : IEqualityComparer<XJLLB>
    {
        public bool Equals(XJLLB x, XJLLB y)
        {
            if (x != null && y != null && x.REPORTDATE == y.REPORTDATE)
                return true;
            return false;
        }

        public int GetHashCode(XJLLB obj)
        {
            return obj.REPORTDATE.GetHashCode();
        }

        private static XJLLBComparer comparer;

        public static XJLLBComparer Get()
        {
            if (comparer == null)
            {
                comparer = new XJLLBComparer();
            }
            return comparer;
        }
    }
}
