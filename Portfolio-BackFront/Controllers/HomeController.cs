using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio_BackFront.DAL;
using Portfolio_BackFront.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_BackFront.Controllers
{
    public class HomeController : Controller
    {
      private AppDbContext _contex { get; }
        public HomeController(AppDbContext contex)
        {
            _contex = contex;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                page1s = _contex.page1s.ToList(),
                page2s=_contex.page2s.ToList(),
                page3s=_contex.page3s.ToList()
            };
            return View(homeVM);
        }
    }
}
