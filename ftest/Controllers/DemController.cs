using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Authorization;
using ftest.servises;
using ftest.VM;
using Microsoft.AspNetCore.Mvc;
using ftest.Data;
using ftest.Models;

namespace ftest.Controllers
{
    
    public class DemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Newdem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Newdem(Dem model, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    model.ImageData = memoryStream.ToArray();
                }
            }
            model.Id = null;

            _dbContext.Dem.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
           


        }
        public IActionResult DemList()
        {
            var demList = _dbContext.Dem.ToList();
            return View(demList);
        }
        public IActionResult AfficherDemListe()
        {
            var demList = _dbContext.Dem.ToList();
            return View("DemList", demList);
        }


    }
}
