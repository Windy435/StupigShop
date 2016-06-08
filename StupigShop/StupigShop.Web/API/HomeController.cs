using StupigShop.Service;
using StupigShop.Web.Infrastructure.Core;
using System.Web.Http;

namespace StupigShop.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;

        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, Stupig Member. ";
        }
    }
}