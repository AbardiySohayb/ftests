using ftest.Data;
using ftest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Authorization;
using ftest.servises;
using ftest.VM;

namespace ftest.Controllers
{
    public class EtdController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EtdController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ListeEtd(string searchBy, string search)
        {
            if (searchBy == "Matiere")
            {
                return View(_dbContext.Etd.Where(x => x.Filiere == search || search == null).ToList());
            }
            else
                return View(_dbContext.Etd.Where(x => x.Prenom.StartsWith(search) || search == null).ToList());

        }

        public ActionResult Profs(int id)
        {
            // Récupérer les EtdProf associés à l'étudiant spécifié
            var etdProfList = _dbContext.EtdProf.Where(ep => ep.EtdId == id).ToList();

            var profIds = etdProfList.Select(ep => ep.ProfId).ToList();
            var professeurs = _dbContext.Prof.Where(p => profIds.Contains(p.Id)).ToList();

            // Vous pouvez maintenant utiliser la liste 'professeurs' dans votre vue
            return View(professeurs);
        }

        [HttpGet]
        public IActionResult Newetd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Newetd(Etd stagiaire)
        {
            _dbContext.Etd.Add(stagiaire);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Hi));
        }

        [HttpGet]
        public IActionResult Afficher(int id)
        {
            var stag = _dbContext.Etd.SingleOrDefault(i => i.Id == id);
            return View(stag);
        }


        public IActionResult Tofb()
        {

            return View();
        } 
        /*
        [HttpGet]
        public IActionResult or()
        {
            // Action pour afficher le formulaire de recherche
            return View();
        }

        [HttpPost]
        public IActionResult or(string nomProfesseur)
        {
            var etudiants = _dbContext.Prof
                .Where(e => e.Matiere == nomProfesseur)
                .ToList();

            return View(etudiants);


        
        }
         [HttpGet]
        public IActionResult ListeEtd()
        {
            var listeEtd = _dbContext.Etd.ToList();
            return View(listeEtd);
        }
         public async  Task<IActionResult> ListeEtd(string ser) 
        {
          var Etd = await _dbContext.Etd.ToListAsync();
            if (!String.IsNullOrEmpty(ser))
            {
                Etd=Etd.Where(n=>n.Filiere.Contains(ser))
                .ToList();
            }
            return View();
        
        }
        }*/
        [HttpGet]
        public IActionResult Ens(int id) 
        {
            var ens = _dbContext.Prof.Find(id);
            return View(ens);
        }


        [HttpPost]
        public IActionResult Ens(Etd stagiare)
        {
            var p = _dbContext.Prof.FirstOrDefault(i => i.Id == stagiare.Id);

            if (p != null)
            {
                // Assurez-vous que votre modèle Etd a une propriété pour contenir la liste de professeurs
               // stagiare.EtdProfs = new List<Prof> { p };

                _dbContext.SaveChanges();
            }
            return View();
        }


        public IActionResult Hi()
        {

            return View();
        }
        /*
        public ProfService _Es;
        public EtdController(ProfService booksService)
        {
            _Es = booksService;
        }
        
        

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] EtdVM book)
        {
            _Es.AddBookWithAuthors(book);
            return Ok();
        }*/
        


    }

}
