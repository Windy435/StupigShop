using StupigShop.Model.Models;
using StupigShop.Web.Models;

namespace StupigShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.CreateBy = postCategoryViewModel.CreateBy;
            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.Status = postCategoryViewModel.Status;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Alias = postViewModel.Alias;
            post.CategoryID = postViewModel.CategoryID;
            post.Content = postViewModel.Content;
            post.CreateBy = postViewModel.CreateBy;
            post.CreatedDate = postViewModel.CreatedDate;
            post.Description = postViewModel.Description;
            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.Image = postViewModel.Image;
            post.MetaDescription = postViewModel.MetaDescription;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.Name = postViewModel.Name;
            post.Status = postViewModel.Status;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.ViewCount = postViewModel.ViewCount;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.Alias = productViewModel.Alias;
            product.CategoryID = productViewModel.CategoryID;
            product.Content = productViewModel.Content;
            product.CreateBy = productViewModel.CreateBy;
            product.CreatedDate = productViewModel.CreatedDate;
            product.Description = productViewModel.Description;
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.Image = productViewModel.Image;
            product.MetaDescription = productViewModel.MetaDescription;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.MoreImages = productViewModel.MoreImages;
            product.Name = productViewModel.Name;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Status = productViewModel.Status;
            product.UpdatedBy = productViewModel.UpdatedBy;
            product.UpdatedDate = productViewModel.UpdatedDate;
            product.ViewCount = productViewModel.ViewCount;
            product.Warranty = productViewModel.Warranty;
            product.Tags = productViewModel.Tags;
            product.Quanity = productViewModel.Quanity;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.Alias = productCategoryViewModel.Alias;
            productCategory.CreateBy = productCategoryViewModel.CreateBy;
            productCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategory.Description = productCategoryViewModel.Description;
            productCategory.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Image = productCategoryViewModel.Image;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.ParentID = productCategoryViewModel.ParentID;
            productCategory.Status = productCategoryViewModel.Status;
            productCategory.UpdatedBy = productCategoryViewModel.UpdatedBy;
            productCategory.UpdatedDate = productCategoryViewModel.UpdatedDate;
        }
    }
}