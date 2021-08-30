using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_api.Services
{
    public class ProductService
    {
        private List<Product> m_product;

        public ProductService()
        {
            m_product = new List<Product>();
        }

        public bool AddProduct(Product prodcut)
        {
            if(m_product.Any(p=> p.Id == prodcut.Id))
            {
                return false;
            }
            m_product.Add(prodcut);
            return true;
        }

        public bool RemoveProduct(int productId)
        {
            var product = m_product.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                return false;
            }
            m_product.Remove(product);
            return true;
        }

        public Product FindProduct(int productId)
        {
            var product = m_product.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return new Product();
            }

            return product;
        }


        public List<Product> GetList()
        {
            return m_product;
        }
    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
