﻿using System;

namespace StupigShop.Web.Models.Abstract
{
    public class AuditableViewModel : IAuditableViewModel
    {
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

        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime? UpdatedDate
        {
            get; set;
        }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}