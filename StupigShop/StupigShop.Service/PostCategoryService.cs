using StupigShop.Data.Infrastructure;
using StupigShop.Data.Repositories;
using StupigShop.Model.Models;
using System.Collections.Generic;

namespace StupigShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(PostCategory postCategory);

        void Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCateroryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            _postCateroryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _postCateroryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCateroryRepository.Delete(id);
        }

        public void Delete(PostCategory postCategory)
        {
            _postCateroryRepository.Delete(postCategory);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCateroryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postCateroryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCateroryRepository.GetSingleById(id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCateroryRepository.Update(postCategory);
        }
    }
}