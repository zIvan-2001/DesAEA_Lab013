using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Service
{
    public class ProductService
    {
        public List<Product> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Products.Where(x => x.EstaActivo == true).ToList();
            }
        }
        public Product GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Products.Find(id);
            }
        }


        public void Insert(Product producto)
        {
            using (var context = new ExampleContext())
            {

                producto.EstaActivo = true;
                producto.FechaCreacion = DateTime.Today;
                context.Products.Add(producto);
                context.SaveChanges();
            }
        }

    }
}
