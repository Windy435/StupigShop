using System;
using System.Collections.Generic;

namespace StupigShop.Web.Models
{
    public class OrderViewModel
    {
        public int ID { set; get; }
        public string CustomerName { set; get; }

        public string CustomerAddress { set; get; }

        public string CustomerEmail { set; get; }

        public string CustomerMobile { set; get; }

        public string CustomerMessage { set; get; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}