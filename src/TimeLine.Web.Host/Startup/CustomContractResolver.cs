using Abp.Dependency;
using Abp.Json;
using Abp.Timing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TimeLine.Web.Host.Startup
{
    public class CustomContractResolver : AbpContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            ModifyProperty(member, property);

            return property;
        }

        protected override void ModifyProperty(MemberInfo member, JsonProperty property)
        {
            if (property.PropertyType != typeof(DateTime) && property.PropertyType != typeof(DateTime?))
            { return; }

            property.Converter = new AbpDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
        }
    }
}
