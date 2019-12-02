using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLine.Reports.Dto
{
    public class CartDto
    {
        public IEnumerable<DateTime> Date { get; set; }

        public IEnumerable<CartDetailDto> Cart { get; set; }
    }

    public class CartDetailDto
    {

        public IEnumerable<decimal> Data { get; set; }

        public string Name { get; set; }
    }
}
