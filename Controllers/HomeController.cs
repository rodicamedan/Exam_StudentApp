using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models.StudViewModels;
namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentContext _context;
        public HomeController(StudentContext context)
        {
            _context = context;
        }
        

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Chat()
        {
            return View();
        }
    }
}
