using Microsoft.AspNetCore.Mvc;
using Portfolio_BackFront.DAL;
using Portfolio_BackFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_BackFront.Areas.Manage.Controllers
{
    [Area("manage")]
    public class Page1Controller : Controller
    {
        private AppDbContext _contex { get; }
        public Page1Controller(AppDbContext context)
        {
            _contex = context;
        }
        public IActionResult Index()
        {
            List<Page1> Page1s = _contex.page1s.ToList();
            return View(Page1s);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page1 page1)
        {
            await _contex.page1s.AddAsync(page1);
            await _contex.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delet(int Id)
        {
            Page1 page1 = _contex.page1s.Find(Id);
            if (page1==null)
            {
                return NotFound();

            }
            if (page1!=null)
            {
                _contex.page1s.Remove(page1);
                _contex.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public  IActionResult Edit(int Id)
        {
            Page1 page1 = _contex.page1s.FirstOrDefault(t => t.Id == Id);
            if (page1==null)
            {
                return NotFound();
            }
            return View(page1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Page1 page1)
        {
            Page1 page11 = _contex.page1s.FirstOrDefault(n => n.Id == page1.Id);
            if (page11==null)
            {
                return NotFound();
            }
            page11.Name = page1.Name;
            page11.Surname = page1.Surname;
            page11.Email = page1.Email;
            page11.Namber = page1.Namber;
            page11.Description = page1.Description;
            _contex.SaveChanges();
            return RedirectToAction();
        }
        
    }
}
