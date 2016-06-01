using StupigShop.Data.Infrastructure;
using StupigShop.Data.Repositories;
using StupigShop.Model.Models;
using System.Collections.Generic;
using System;

namespace StupigShop.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        PostCategory Delete(PostCategory postCategory);

        PostCategory Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void Save();
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

        public  PostCategory Add(PostCategory postCategory)
        {
            return _postCateroryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return _postCateroryRepository.Delete(id);
        }

        public PostCategory Delete(PostCategory postCategory)
        {
            return _postCateroryRepository.Delete(postCategory);
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

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCateroryRepository.Update(postCategory);
        }
    }
}