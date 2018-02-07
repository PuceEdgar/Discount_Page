using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropDownList.Models
{
    public class DropDownViewModel
    {
        public int ID { get; set; }
        public string company_name { get; set; }
        public string Discount { get; set; }
        public double units { get; set; }
        public decimal withoutDiscount { get; set; }
        public List<NameDropDown> NameDropDownProperty { get; set; }
        public List<DiscountDropDown> DiscountDropDownProperty { get; set; }

    }

    public class NameDropDown
    {
        public int ID { get; set; }
        public string company_name { get; set; }
    }

    public class DiscountDropDown
    {
        public int ID { get; set; }
        public string Discount { get; set; }
    }

}