using DAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ShopListController : Controller
    {
        // GET: ShopList
        public async Task<ActionResult> Shopping()
        {
            Session["UserID"] = 1;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:1813/api/service");
                var model = JsonConvert.DeserializeObject<List<Product>>(
                    response.Content.ReadAsStringAsync().Result);
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Buy(FormCollection form)
        {
            bool result = false;
            if (form.Count > 1)
            {
                List<ShopHistory> shopList = new List<ShopHistory>();
                for (var i = 1; i < form.Count; i++)
                {
                    ShopHistory _shopHistory = new ShopHistory();
                    _shopHistory.ProductID = int.Parse(form[i]);
                    _shopHistory.UserID = (int)Session["UserID"];
                    _shopHistory.CreatedDateTime = DateTime.Now;
                    shopList.Add(_shopHistory);
                }
                using (HttpClient client = new HttpClient())
                {
                    var data = JsonConvert.SerializeObject(shopList);
                    HttpContent content = new StringContent(data,
                        System.Text.Encoding.UTF8, "application/json");

                    var returnResult=await client.PostAsync("http://localhost:1813/api/service", content);
                    result = bool.Parse(returnResult.Content.ReadAsStringAsync().Result);
                }
            }
            return result;
        }

        public string Message()
        {
            return "<h1>Acik Akademi Mvc Semineri</h1>";
        }
    }
}