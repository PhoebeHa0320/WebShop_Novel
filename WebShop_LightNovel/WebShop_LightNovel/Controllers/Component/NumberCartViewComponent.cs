using WebShopNovel.Extension;
using WebShopNovel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopNovel.Controllers.Component
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
            int soluong = 0;
            if(carts != null)
            {
                soluong = carts.Count();
            }
            return View(carts);
        }
    }
}
