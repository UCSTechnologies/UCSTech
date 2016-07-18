using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GFS.Domain.Abstract;

namespace GFS.Controllers
{
    public class PrNavController : Controller
    {
        private IProductRepository repository;

        public PrNavController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: PrNav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                .Select(x => x.category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}