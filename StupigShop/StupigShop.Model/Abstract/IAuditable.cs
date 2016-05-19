using System;

namespace StupigShop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        string CreateBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        string UpdatedBy { set; get; }
        
        //Seoable
        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }

        //Switchable
        bool Status { set; get; }
    }
}