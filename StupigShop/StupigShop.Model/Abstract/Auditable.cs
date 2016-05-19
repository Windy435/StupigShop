using System;
using System.ComponentModel.DataAnnotations;

namespace StupigShop.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        [MaxLength(256)]
        public string CreateBy
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        }

        [MaxLength(256)]
        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime? UpdatedDate
        {
            get; set;
        }

        //Seoable
        [MaxLength(256)]
        public string MetaKeyword { set; get; }

        [MaxLength(256)]
        public string MetaDescription { set; get; }

        //Switchable
        public bool Status { set; get; }
    }
}