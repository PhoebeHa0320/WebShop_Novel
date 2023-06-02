using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShopNovel.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Globalization;
using System.IO;
using WebShopNovel.Helpper;
using PagedList.Core;

namespace WebShopNovel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPublishersController : Controller
    {
        private readonly WebNovel _context;
        public static string image;
        public INotyfService _notyfService { get; }
        public AdminPublishersController(WebNovel context, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _context = context;
        }

        // GET: Admin/AdminPublishers
        public IActionResult Index(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            var _publisher = from m in _context.Publishers select m;
            //Sort
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            switch (sortOrder)
            {
                case "id_desc":
                    _publisher = _publisher.OrderByDescending(p => p.PublisherId);
                    break;
                case "Name":
                    _publisher = _publisher.OrderBy(p => p.PublisherName);
                    break;
                case "name_desc":
                    _publisher = _publisher.OrderByDescending(p => p.PublisherName);
                    break;
                default:
                    _publisher = _publisher.OrderBy(p => p.PublisherId);
                    break;
            }

            //Search
            ViewData["CurrentFilter"] = searchStr;
            if (!String.IsNullOrEmpty(searchStr))
            {
                _publisher = _publisher.Where(p => p.PublisherId.ToString().Contains(searchStr) || p.PublisherName.Contains(searchStr));
            }

            //Paginate
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            ViewBag.CurrentPage = pageNo;
            PagedList<Publisher> models = new PagedList<Publisher>(_publisher, pageNo, pageSize);
            return View(models);
        }

        // GET: Admin/AdminPublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Admin/AdminPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Logo")] Publisher publisher, Microsoft.AspNetCore.Http.IFormFile fLogo)
        {
            if (ModelState.IsValid)
            {
                var _publisher = from m in _context.Publishers select m;
                if (_publisher.Any(a => a.PublisherName == publisher.PublisherName))
                {
                    _notyfService.Error("Nhà xuất bản này đã có trong Cơ sở dữ liệu!");
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    publisher.PublisherName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(publisher.PublisherName);
                    if (fLogo != null)
                    {
                        string extennsion = Path.GetExtension(fLogo.FileName);
                        image = Utilities.ToUrlFriendly(publisher.PublisherName) + extennsion;
                        publisher.Logo = await Utilities.UploadFile(fLogo, @"publishers", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(publisher.Logo)) publisher.Logo = "thumb-6.jpg";
                    _notyfService.Success("Thêm thành công!");
                    _context.Add(publisher);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(publisher);
        }

        // GET: Admin/AdminPublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Admin/AdminPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublisherId,PublisherName,Logo")] Publisher publisher, Microsoft.AspNetCore.Http.IFormFile fLogo)
        {
            if (id != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _publisher = from m in _context.Publishers select m;
                    if (_publisher.Any(a => a.PublisherName == publisher.PublisherName && a.Logo == publisher.Logo))
                    {
                        _notyfService.Error("Nhãn hàng này đã có trong Cơ sở dữ liệu!");
                        return RedirectToAction(nameof(Edit));
                    }
                    else
                    {
                        publisher.PublisherName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(publisher.PublisherName);
                        if (fLogo != null)
                        {
                            string extennsion = Path.GetExtension(fLogo.FileName);
                            image = Utilities.ToUrlFriendly(publisher.PublisherName) + extennsion;
                            publisher.Logo = await Utilities.UploadFile(fLogo, @"publishers", image.ToLower());
                        }
                        if (string.IsNullOrEmpty(publisher.Logo)) publisher.Logo = "thumb-6.jpg";
                        _notyfService.Success("Sửa thành công!");
                        _context.Update(publisher);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        _notyfService.Error("Lỗi!!!!!!!!!!!!!");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Admin/AdminPublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (Publisher == null)
            {
                return NotFound();
            }

            return View(Publisher);
        }

        // POST: Admin/AdminPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}
