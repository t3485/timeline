using Abp.AutoMapper;
using Abp.Runtime.Validation;
using TimeLine.Axis.Lines;

namespace TimeLine.Axis.Dto
{
    [AutoMapTo(typeof(TimeAxis))]
    public class CreateAxisDto : IShouldNormalize
    {
        public string title { get; set; }

        public void Normalize()
        {

        }
    }
}
