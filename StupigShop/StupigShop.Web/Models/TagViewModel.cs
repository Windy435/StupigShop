using System.Collections.Generic;

namespace StupigShop.Web.Models
{
    public class TagViewModel
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public virtual IEnumerable<ProductTagViewModel> ProductTags { set; get; }
        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
    }
}