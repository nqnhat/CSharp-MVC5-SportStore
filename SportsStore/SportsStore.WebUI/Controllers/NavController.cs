using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository Irepository;

        public NavController(IProductRepository _Irepository)
        {
            Irepository = _Irepository;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = Irepository.Products.Select(i => i.Category).Distinct().OrderBy(i => i);
            return PartialView(categories);
        }
      
    }
}