using AutoMapper;
using StupigShop.Model.Models;
using StupigShop.Service;
using StupigShop.Web.Models;
using System.Web.Mvc;

namespace StupigShop.Web.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        // GET: Page
        public ActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            var model = Mapper.Map<Page, PageViewModel>(page);
            return View(model);
        }
    }
}