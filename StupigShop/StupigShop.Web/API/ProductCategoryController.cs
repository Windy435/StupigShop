using AutoMapper;
using StupigShop.Model.Models;
using StupigShop.Service;
using StupigShop.Web.Infrastructure.Core;
using StupigShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StupigShop.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpReponse(request, () =>
            {
                IEnumerable<ProductCategory> model = _productCategoryService.GetAll();
                IEnumerable<ProductCategoryViewModel> modelVM = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                HttpResponseMessage respone = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return respone;
            });
        }
    }
}