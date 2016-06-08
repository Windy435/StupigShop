using StupigShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StupigShop.Model.Models;
using StupigShop.Web.Models;
using System.Web;
using StupigShop.Web.Infrastructure.Extensions;
using StupigShop.Web.Infrastructure.Core;
using AutoMapper;
using System.Web.Script.Serialization;

namespace StupigShop.Web.API
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        #region Initialize

        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        #endregion

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;
                IEnumerable<Product> model = _productService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                IEnumerable<ProductViewModel> modelVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);
                                
                var paginationSet = new PaginationSet<ProductViewModel>()
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
                var model = _productService.GetById(id);
                var modelVM = Mapper.Map<Product, ProductViewModel>(model);

                HttpResponseMessage respone = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return respone;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel modelVM)
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
                    var model = new Product();
                    model.UpdateProduct(modelVM);

                    model.CreatedDate = DateTime.Now;
                    model.CreateBy = User.Identity.Name;

                    _productService.Add(model);
                    _productService.Save();

                    var reponseData = Mapper.Map<Product, ProductViewModel>(model);
                    response = request.CreateResponse(HttpStatusCode.Created, reponseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel modelVM)
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
                    var model = _productService.GetById(modelVM.ID);
                    model.UpdateProduct(modelVM);

                    model.UpdatedDate = DateTime.Now;
                    model.UpdatedBy = User.Identity.Name;

                    _productService.Update(model);
                    _productService.Save();

                    var reponseData = Mapper.Map<Product, ProductViewModel>(model);
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
                    var oldProduct = _productService.Delete(id);
                    _productService.Save();

                    var reponseData = Mapper.Map<Product, ProductViewModel>(oldProduct);
                    response = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
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
                    var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                    foreach (var item in listProduct)
                    {
                        _productService.Delete(item);
                    }
                    _productService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);
                }

                return response;
            });
        }
    }
}
