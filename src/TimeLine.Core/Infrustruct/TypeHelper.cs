using Abp.Dependency;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TimeLine.Infrustruct
{
    public interface ITypeHelper : ITransientDependency
    {
        Func<T, TReturn> GetPropertyAccess<T, TReturn>(string name);

        string GetPropertyDescribe<T>(string name);
    }
}
