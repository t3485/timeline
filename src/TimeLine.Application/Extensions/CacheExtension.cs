using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Extensions
{
    public static class CacheExtension
    {
        public static ICache GetPermanentCache(this ICacheManager manager)
        {
            return manager.GetCache("PermanentCache");
        }


    }
}
