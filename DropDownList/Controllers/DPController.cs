using DataLayer;
using DropDownList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownList.Controllers
{
    public class DPController : Controller
    {
        // GET: DP
        public ActionResult Index()
        {
            DropDownViewModel model = new DropDownViewModel
            {
                NameDropDownProperty = GetDetailsForDropDown(),
                DiscountDropDownProperty = GetDiscountDropDown()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DropDownViewModel mod)
        {
                     
            mod.units = Convert.ToInt32(Request["units"]);
            mod.withoutDiscount = Convert.ToInt32(Request["withoutdiscount"]) ;
            decimal discountPrice = 0;

            if (mod.Discount.Equals("1"))
            {
                discountPrice = mod.withoutDiscount - Decimal.Multiply(mod.withoutDiscount, Convert.ToDecimal(0.3));
            }
            else if (mod.Discount.Equals("2"))
            {
                if (mod.units < 100)
                {
                    discountPrice = mod.withoutDiscount - Decimal.Multiply(mod.withoutDiscount, Convert.ToDecimal(0.1));
                }
                else if (mod.units >= 100)
                {
                    discountPrice = mod.withoutDiscount - Decimal.Multiply(mod.withoutDiscount, Convert.ToDecimal(0.25));
                }
            }
            else if (mod.Discount.Equals("3"))
            {
                discountPrice = mod.withoutDiscount - Decimal.Multiply(mod.withoutDiscount, Convert.ToDecimal(0.5));
            }
            else
            {
                discountPrice = mod.withoutDiscount;
            }

          
            string output =  "<br /> Price with discount: " + String.Format("{0:0.00}", discountPrice);

            return Content(output);
        }

      
        public List<NameDropDown> GetDetailsForDropDown()
        {
            DiscountPageEntities2 context = new DiscountPageEntities2();
            List<NameDropDown> result = new List<NameDropDown>();
            

            var obj = context.Customers.Select(u => u).ToList();
            if (obj != null && obj.Count() > 0)
            {
                foreach(var data in obj)
                {
                    NameDropDown model = new NameDropDown();
                    model.ID = data.ID;
                    model.company_name = data.company_name;
                    result.Add(model);
                }
            }

            return result;
        }

        public List<DiscountDropDown> GetDiscountDropDown()
        {
            DiscountPageEntities2 context = new DiscountPageEntities2();
            List<DiscountDropDown> result = new List<DiscountDropDown>();

            
            var obj = context.Customers.Select(u => u).ToList();
            if (obj != null && obj.Count() > 0)
            {
                foreach (var data in obj)
                {
                    DiscountDropDown model = new DiscountDropDown();
                    model.ID = data.ID;
                    model.Discount = data.Discount;
                    result.Add(model);
                }
            }

            return result;
        }

      
    }

    
}