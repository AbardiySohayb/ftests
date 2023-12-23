using Azure;
using ftest.Data;
using ftest.Models;
using ftest.servises;
using ftest.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ftest.Controllers
{
    
    public class ProfController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpGet]
        public IActionResult ListeProf()
        {
            var listeProf = _dbContext.Prof.ToList();
            return View(listeProf);
        }

        

        [HttpGet]
        public IActionResult NewProf()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewProf(Prof stagiaire)
        {
            _dbContext.Prof.Add(stagiaire);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Hip));
        }

        public IActionResult Hip()
        {
            var dernierElement = _dbContext.Prof.OrderByDescending(p => p.Id).FirstOrDefault();

            return View(dernierElement);
        }

        [HttpGet]
        public IActionResult Supprimer(int id)
        {
            var stagaiare = _dbContext.Prof.Find(id);
            return View(stagaiare);
        }


        [HttpPost]
        public IActionResult Supprimer(Prof stagiare)
        {
            _dbContext.Prof.Remove(stagiare);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(ListeProf));
        }



        /*
         * 
         * private EtdService _Ps;
        public ProfController(EtdService authorsService)
        {
            _Ps = authorsService;
        }
         * [HttpPost("add-author")]
        public IActionResult AddBook([FromBody] ProfVM author)
        {
            _Ps.AddProf(author);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult Getetdprof(int Id)
        {
            var response = _Ps.Getetdprof(Id);
            return Ok(response);
        }
         * [HttpGet]
        public IActionResult Hip()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Hip(Prof f)
        {
            
            ViewData["profp"] = "Bonjour " + f.Prenom;
            return View();
        
        [HttpPost]
        public IActionResult HiP(Prof newStag)
        {
            var Op = _dbContext.Prof.Find(newStag.Id);
            string Pr = Request.Form["Prenom"];

            ViewData["profp"] = Pr;

            
            return View();


        }}*/


    }

}

