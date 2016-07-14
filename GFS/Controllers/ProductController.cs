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
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

         public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

         public ViewResult List(string category, int page = 1)
         {
             ProductsListViewModel model = new ProductsListViewModel
             {
                 Products = repository.Products
                 .Where(p => category == null || p.category == category)
                 .OrderBy(p => p.ProductID)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                 PagingInfo = new PagingInfo
                 {
                     CurrentPage = page,
                     ItemsPerPage = PageSize,
                     TotalItems = repository.Products.Count()
                 },
                 CurrentCategory = category
             };

             return View(model);
             //return View(repository.Products
             //    .OrderBy(p => p.ProductID)
             //    .Skip((page - 1) * PageSize)
             //    .Take(PageSize));
         }
    }
}