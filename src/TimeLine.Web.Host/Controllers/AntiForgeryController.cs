using Microsoft.AspNetCore.Antiforgery;
using TimeLine.Controllers;

namespace TimeLine.Web.Host.Controllers
{
    public class AntiForgeryController : TimeLineControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
