using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TimeLine.Infrustruct
{
    public class TypeHelper : ITypeHelper
    {
        private readonly ICacheManager _cacheManager;

        public const string TypePropertyName = "TypeHelper";

        public TypeHelper(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public Func<T, TReturn> GetPropertyAccess<T, TReturn>(string name)
        {
            return _cacheManager.GetCache(typeof(T).Name)
                .Get<string, Func<T, TReturn>>(name, x =>
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                    var lamdba = Expression.Lambda(Expression.Property(parameter, x), parameter);
                    var e = lamdba.Compile();

                    return (Func<T, TReturn>)e;
                });
        }

        public string GetPropertyDescribe<T>(string name)
        {
            return _cacheManager.GetCache($"{typeof(T).Name}_Display")
                   .Get<string, string>(name, x =>
                   {
                       var p = typeof(T).GetProperty(name);

                       if (p == null)
                       {
                           return null;
                       }

                       var attr = p.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

                       if (attr != null)
                       {
                           var display = attr as DisplayAttribute;
                           return display.Name;
                       }

                       return null;
                   });
            
        }
    }
}
