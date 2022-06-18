using APITecsup.Models.Request;
using APITecsup.Models.Response;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APITecsup.Controllers
{
    public class ProductController : ApiController
    {
        public List<ProductResponse> Get()
        {

            var service = new ProductService();
            var product = service.Get();

            //Convert Domaint to Response
            var response = product.Select(x => new ProductResponse
            {
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();

            return response;
        }
        [HttpPost]
        public bool Insert(ProductRequest request)
        {
            var response = true;
            try
            {
                var service = new ProductService();
                service.Insert(new Domain.Product
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion

                });
            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return response;
        }
    }
}