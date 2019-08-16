using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TimeLine.Axis.Dto;
using TimeLine.Axis.Lines;

namespace TimeLine.Extensions
{
    public class EnumUtils<T>
    {
        public static string GetEnumDescript(T value)
        {
            var field = typeof(T).GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(LimitedAttribute), false);

            if (attributes.Length > 0)
            {
                return (attributes[0] as LimitedAttribute).Name;
            }
            return string.Empty;
        }

        public static AxisAuthorityDto GetAxisAuthorityEnumDescript(T value)
        {
            var field = typeof(T).GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(LimitedAttribute), false);

            if (attributes.Length > 0 && attributes[0] is LimitedAttribute attr)
            {
                return new AxisAuthorityDto(attr.Name, value.ToString(), attr.Exclusive, attr.BasicNeed, Convert.ToInt32(value));
            }

            return null;
        }
    }
}
