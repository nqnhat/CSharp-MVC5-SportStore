using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SportsStore.Domain.Entities;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext _controllerContext, ModelBindingContext _bindingContext)
        {
            Cart cart = null;
            if (_controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)_controllerContext.HttpContext.Session[sessionKey];
            }

            if (cart == null)
            {
                cart = new Cart();
                if (_controllerContext.HttpContext.Session != null)
                {
                    _controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}