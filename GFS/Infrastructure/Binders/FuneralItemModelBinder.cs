using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GFS.Domain.Entities;

namespace GFS.Infrastructure.Binders
{
    public class FuneralItemModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session            
            FuneralItem cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (FuneralItem)controllerContext.HttpContext.Session[sessionKey];
        }

            // create the Cart if there wasn't one in the session data            
            if (cart == null)
            {
                cart = new FuneralItem();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // return the cart            
            return cart;
        }
    }
}