using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository _productInjection)
        {
            this.repository = _productInjection;
        }

        // GET: Product
        // Default page 1
        public ViewResult List(string category , int page = 1)
        {
            IEnumerable<Product> productPerPage = this.repository.Products.Where(i => category == null || i.Category == category)
                                                                        .OrderBy(i => i.ProductID)
                                                                        .Skip((page - 1) * PageSize)
                                                                        .Take(PageSize);

            PagingInfo pageInfo = new PagingInfo();
            pageInfo.CurrentPage = page;
            pageInfo.ItemsPerPage = this.PageSize;

            if (category == null)
            {
                pageInfo.TotalItems = repository.Products.Count();
            }
            else
            {
                pageInfo.TotalItems = repository.Products.Where(i => i.Category == category).Count();
            }


            ProductListViewModel model = new ProductListViewModel();
            model.Products = productPerPage;
            model.PagingInfo = pageInfo;
            model.CurrentCategory = category;

            return View(model);
        }
    }
}