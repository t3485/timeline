using Abp.Application.Services.Dto;

namespace TimeLine.Axis.Dto
{
    public class AssignAuthDto : EntityDto<int>
    {
        public string[] AuthorizeType { get; set; }

        public long UID { get; set; }
    }

    public class RemoveAuthorityDto : EntityDto<int>
    {
        public string AuthorizeType { get; set; }

        public long UID { get; set; }
    }
}
