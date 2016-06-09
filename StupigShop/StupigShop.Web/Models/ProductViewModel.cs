using StupigShop.Web.Models.Abstract;
using System.Collections.Generic;

namespace StupigShop.Web.Models
{
    public class ProductViewModel : AuditableViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public int CategoryID { set; get; }
        public string Image { set; get; }
        public string MoreImages { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        public int Quanity { set; get; }
        public virtual ProductCategoryViewModel ProductCategory { set; get; }
        public virtual IEnumerable<ProductTagViewModel> ProductTags { set; get; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { set; get; }
    }
}