using AutoMapper;
using StupigShop.Model.Models;
using StupigShop.Service;
using StupigShop.Web.Infrastructure.Core;
using StupigShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StupigShop.Web.Infrastructure.Extensions;

namespace StupigShop.Web.API
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        #region Initialize

        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        #endregion

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;
                IEnumerable<ProductCategory> model = _productCategoryService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                IEnumerable<ProductCategoryViewModel> modelVM = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = modelVM,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                HttpResponseMessage respone = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return respone;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                var model = _productCategoryService.GetById(id);
                var modelVM = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                HttpResponseMessage respone = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return respone;
            });
        }

        [Route("getallparents")]
        [HttpGet]
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

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel modelVM)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = new ProductCategory();
                    model.UpdateProductCategory(modelVM);

                    _productCategoryService.Add(model);
                    _productCategoryService.Save();

                    var reponseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
                    response = request.CreateResponse(HttpStatusCode.Created, reponseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel modelVM)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _productCategoryService.GetById(modelVM.ID);
                    model.UpdateProductCategory(modelVM);

                    model.UpdatedDate = DateTime.Now;

                    _productCategoryService.Update(model);
                    _productCategoryService.Save();

                    var reponseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
                    response = request.CreateResponse(HttpStatusCode.Created, reponseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                   var oldProductCategory = _productCategoryService.Delete(id);
                    _productCategoryService.Save();

                    var reponseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }

                return response;
            });
        }
    }
}