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

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0) {
                context.Products.Add(product);
            }

            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.description = product.description;
                    dbEntry.Price = product.Price;
                    dbEntry.category = product.category;
                    dbEntry.quantity = product.quantity;
                    dbEntry.supplier = product.supplier;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}