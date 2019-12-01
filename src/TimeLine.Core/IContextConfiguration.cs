using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Core
{
    public interface IContextConfiguration
    {
        void Config(ModelBuilder builder);
    }
}
