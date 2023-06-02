using WebShopNovel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopNovel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebNovel _context;

        public HomeController(ILogger<HomeController> logger, WebNovel context)
        {
            _context = context;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var lstNewProduct = _context.Products
                .Include(n => n.Cate)
                .Where(n => n.IsActived && n.UnitInStock > 5)
                .OrderByDescending(n => n.DateCreated);
            ViewBag.ListNPD = lstNewProduct;

            var lstBestSeller = _context.Products
                .Include(n => n.Cate)
                .Include(n=>n.OrderDetails)
                .Where(n => n.IsActived && n.UnitInStock > 5 && n.IsBestsellers == true)
                .OrderByDescending(n => n.DateCreated);
            ViewBag.BestSeller = lstBestSeller;
            return View();
        }

        public ActionResult NPPartial()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("CNNovelColection", Name = "CNNovelColection")]
        public IActionResult CNNovelColection(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstSmartPhone = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a => a.IsActived && a.UnitInStock > 0 && a.Cate.CategoryName == "Novel Trung Quốc" && a.Homeflag == true)
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstSmartPhone, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }

        [Route("KRNovelColection", Name = "KRNovelColection")]
        public IActionResult KRNovelColection(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstPhuKien = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a => a.IsActived && a.Cate.CategoryName == "Novel Hàn Quốc" && a.UnitInStock > 0 && a.Homeflag == true)
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstPhuKien, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }

        [Route("JPNovelColection", Name = "JPNovelColection")]
        public IActionResult JPNovelColection(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstLaptop = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a => a.IsActived && a.UnitInStock > 0 && a.Cate.CategoryName == "Novel Nhật Bản" && a.Homeflag == true)
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstLaptop, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }

    }
}
