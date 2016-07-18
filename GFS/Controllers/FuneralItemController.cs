using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GFS.Domain.Abstract;
using GFS.Domain.Entities;
using GFS.Models;

namespace GFS.Controllers
{
    public class FuneralItemController : Controller
    {
        private IProductRepository repository;
        private IFuneralFormProcessor orderProcessor;

        public FuneralItemController(IProductRepository repo, IFuneralFormProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        public ViewResult Index(FuneralItem cart, string returnUrl)
        {
            return View(new FuneralItemIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToFuneralItems(FuneralItem cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(FuneralItem cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(FuneralItem cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new Claims());
        }

        [HttpPost]
        public ViewResult Checkout(FuneralItem cart, Claims shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        //private FuneralItem GetCart()
        //{
        //    FuneralItem cart = (FuneralItem)Session["Cart"];

        //    if (cart == null)
        //    {
        //        cart = new FuneralItem();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}