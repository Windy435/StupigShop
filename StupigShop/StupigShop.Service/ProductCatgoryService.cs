using StupigShop.Data.Infrastructure;
using StupigShop.Data.Repositories;
using StupigShop.Model.Models;
using System.Collections.Generic;

namespace StupigShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        void Update(ProductCategory productCategory);

        ProductCategory Delete(ProductCategory productCategory);

        ProductCategory Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepositoy _productCateroryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepositoy productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _productCateroryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCateroryRepository.Add(productCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _productCateroryRepository.Delete(id);
        }

        public ProductCategory Delete(ProductCategory productCategory)
        {
            return _productCateroryRepository.Delete(productCategory);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCateroryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCateroryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _productCateroryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory productCategory)
        {
            _productCateroryRepository.Update(productCategory);
        }
    }
}