using AutoMapper;
using StupigShop.Model.Models;
using StupigShop.Service;
using StupigShop.Web.Infrastructure.Core;
using StupigShop.Web.Infrastructure.Extensions;
using StupigShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StupigShop.Web.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorSerice, IPostCategoryService postCategoryService) : base(errorSerice)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage reponse = null;

                IEnumerable<PostCategory> model = _postCategoryService.GetAll();

                IEnumerable<PostCategoryViewModel> modelVM = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(model);

                reponse = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return reponse;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVM);
                    var categoryPost = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.Created, categoryPost);
                }
                return reponse;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVM);
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    reponse = request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            });
        }
    }
}