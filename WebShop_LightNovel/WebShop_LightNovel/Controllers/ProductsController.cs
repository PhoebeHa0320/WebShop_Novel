using WebShopNovel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopNovel.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WebNovel _context;

        public ProductsController(WebNovel context)
        {
            _context = context;
        }
        //Novel Nhật
        [Route("JPNovel", Name = "Novel Nhật Bản")]
        public IActionResult JPNovel(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstLaptop = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a=>a.IsActived && a.UnitInStock >0 && a.CateId == 1)
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstLaptop, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }
        //Novel Trung
        [Route("CNNovel", Name = "Novel Trung Quốc")]
        public IActionResult CNNovel(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstSmartPhone = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a => a.IsActived && a.UnitInStock > 0 && a.Cate.CategoryName == "Novel Trung Quốc")
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstSmartPhone, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }

        [Route("Sales", Name = "Sales")]
        public IActionResult Sales(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstSale = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a => a.IsActived && a.Discount > 0 && a.UnitInStock > 0)
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstSale, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }
        //Novel Hàn
        [Route("KRNovel", Name = "Novel Hàn Quốc")]
        public IActionResult KRNovel(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstPhuKien = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a => a.IsActived && a.Cate.CategoryName == "Novel Hàn Quốc" && a.UnitInStock > 0)
                .Include(a => a.Publisher)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstPhuKien, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }



        [Route("/{Alias}-{id}", Name = "Details")]
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(a => a.Cate).Include(a => a.Publisher).FirstOrDefault(x => x.ProductId == id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Search( string searchStr, int? page)
        {
            var _product = from m in _context.Products.Include(p => p.Publisher).Include(p => p.Cate) select m;
            
            //Search
            ViewData["CurrentFilter"] = searchStr;
            if (!String.IsNullOrEmpty(searchStr))
            {
                _product = _product.Where(p => p.ProductName.Contains(searchStr) || p.ProductId.ToString().Contains(searchStr));
            }
            //Paginate
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            PagedList<Product> models = new PagedList<Product>(_product, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;

            return View(models);
        }
    }
}
