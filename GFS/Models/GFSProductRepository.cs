using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GFS.Domain.Abstract;
using GFS.Domain.Entities;

namespace GFS.Models
{
    public class GFSProductRepository : IProductRepository 
    {
        private GFSContext context = new GFSContext();

        public IEnumerable<Product> Products { get { return context.Products; } }
    }
}