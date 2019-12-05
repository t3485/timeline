using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Infrustruct
{
    public interface IStringAnylize : ITransientDependency
    {
        Queue<string> Middle2SuffixExp(string exp);

        int SkipSpace(string s, int i);

        bool IsOperation(string o);

        string Describe { get; set; }
    }
}
