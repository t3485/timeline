using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Axis.Dto
{
    public class UserAuthDto
    {
        public long UID { get; set; }
        
        public string Name { get; set; }

        public IEnumerable<string> Authority { get; set; }
    }
}
