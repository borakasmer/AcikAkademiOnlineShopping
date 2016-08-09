using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class ServiceController : ApiController
    {
        // GET: api/Service
        public List<Product> Get()
        {
            using (ShopContext context= new ShopContext())
            {
                return context.Product.ToList();
            }
        }

        // GET: api/Service/5
        public Product Get(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                return context.Product.Single(pr => pr.id == id);
            }
        }

        // POST: api/Service
        public bool Post(List<ShopHistory> shoppingList)
        {
            try
            {
                throw new Exception();
                using (ShopContext context = new ShopContext())
                {
                    context.ShopHistory.AddRange(shoppingList);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }               
    }
}
