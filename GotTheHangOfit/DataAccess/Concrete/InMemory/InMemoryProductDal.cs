using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
                _products = new List<Product>() { 
                new Product{ProductId=1,ProductName="bardak",CategoryId=5,UnitPrice=15,UnitsInStock=8},
                new Product{ProductId=2,ProductName="kamera",CategoryId=4,UnitPrice=500,UnitsInStock=6},
                new Product{ProductId=3,ProductName="masa",CategoryId=5,UnitPrice=300,UnitsInStock=4}
                };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete=null;
            //foreach (var item in _products)
            //{
            //    if(product.ProductId== item.ProductId) 
            //    {
            //        productToDelete=item;
            //    }
            //}
            //_products.Remove(productToDelete);
            productToDelete = _products.SingleOrDefault(p=> p.ProductId==product.ProductId); //LINQ Language intagrated query
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return  _products.Where(p=> p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate=null;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //LINQ Language intagrated query
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.CategoryId= product.CategoryId;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;

        }
    }
}
