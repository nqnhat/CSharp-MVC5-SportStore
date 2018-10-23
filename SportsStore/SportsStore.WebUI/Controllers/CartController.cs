using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Diagnostics;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository Irepository;

        public CartController(IProductRepository _Irepository)
        {
            this.Irepository = _Irepository;
        }

        public ViewResult Index(Cart cart, string returnURL)
        {
            CartIndexViewModel modelForView = new CartIndexViewModel();
            modelForView.Cart = cart;
            modelForView.returnURL = returnURL;

            return View(modelForView);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productID, string returnURL)
        {
            Product product = this.Irepository.Products.FirstOrDefault(i => i.ProductID == productID);
            if (product != null)
            {
                cart.AddItem(product,1);
            }
            return RedirectToAction("Index", new { returnURL});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnURL)
        {
            Product product = this.Irepository.Products.FirstOrDefault(i => i.ProductID == productID);

            if (product != null)
            {
                cart.RemoveAllItemsOfAProduct(product);
            }

            return RedirectToAction("Index", new { returnURL });
        }

        // GET: Cart
        //public RedirectToRouteResult AddToCart(int productID, string returnURL)
        //{
        //    Product product = this.Irepository.Products.FirstOrDefault(i => i.ProductID == productID);

        //    if (product != null)
        //    {
        //        Debug.WriteLine("Hello world");
        //        // getCart().AddItem(product, 1);
        //        setCart(product, 1);
                
        //    }
            

        //    return RedirectToAction("Index", new { returnURL});
        //}

        //public RedirectToRouteResult RemoveFromCart(int _productID, string _returnURL)
        //{
        //    Product product = this.Irepository.Products.FirstOrDefault(i => i.ProductID == _productID);

        //    if (product != null)
        //    {
        //        getCart().RemoveAllItemsOfAProduct(product);
        //    }
        //    return RedirectToAction("Index", new { _returnURL});
        //}

        //public ViewResult Index(string returnURL)
        //{
        //    CartIndexViewModel modelForView = new CartIndexViewModel();
        //    modelForView.Cart = getCart();
        //    modelForView.returnURL = returnURL;

        //    return View(modelForView);
        //}

        //private void setCart(Product product, int quantity)
        //{
        //    Cart cart = (Cart)Session["Cart"];

        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //    }
        //    cart.AddItem(product, quantity);
        //    Session["Cart"] = cart;
        //}

        //private Cart getCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}