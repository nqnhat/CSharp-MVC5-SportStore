﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository _productInjection)
        {
            this.repository = _productInjection;
        }

        // GET: Product
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}