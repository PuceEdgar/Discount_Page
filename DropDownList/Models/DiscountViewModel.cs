using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropDownList.Models
{
    public class DiscountViewModel
    {

        public int DiscountID { get; set; }
        public string Discount_Name { get; set; }
        public List<DiscountDrop> DiscountDropDownProperty { get; set; }
    }

    public class DiscountDrop
    {
        public int DiscountID { get; set; }
        public string Discount_Name { get; set; }
    }
}