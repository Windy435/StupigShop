using StupigShop.Web.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StupigShop.Web.Models
{
    public class ProductCategoryViewModel:AuditableViewModel
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Require enter the category name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Require enter the seo tittle")]
        public string Alias { set; get; }
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<ProductViewModel> Products { set; get; }
    }
}