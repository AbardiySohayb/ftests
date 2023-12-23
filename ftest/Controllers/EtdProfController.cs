using ftest.Data;
using ftest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ftest.Controllers
{
    public class EtdProfController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EtdProfController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult AjouterEtdProf()
        {
            var viewModel = new AjoutEtdProfViewModel
            {
                Etudiants = _dbContext.Etd.ToList(),
                Professeurs = _dbContext.Prof.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AjouterEtdProf(AjoutEtdProfViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Récupérer l'étudiant et le professeur sélectionnés
                    var etudiant = _dbContext.Etd.Find(model.EtdId);
                    var professeur = _dbContext.Prof.Find(model.ProfId);

                    if (etudiant != null && professeur != null)
                    {
                        // Créer la relation
                        var profEtudiant = new EtdProf
                        {
                            EtdId = etudiant.Id,
                            ProfId = professeur.Id
                        };

                        _dbContext.EtdProf.Add(profEtudiant);
                        _dbContext.SaveChanges();
                        return RedirectToAction("Index", "Home");
                        
                    }
                }

                // Gérer le cas où les données ne sont pas valides
                // Vous pouvez rediriger vers une vue d'erreur ou afficher un message d'erreur dans la vue actuelle
                return View(model);
            }
            catch (Exception ex)
            {
                // Gérer l'exception (enregistrez ou affichez l'erreur, selon les besoins)
                // Vous pouvez également rediriger vers une vue d'erreur
                return View("Error");
            }
        }


        public ActionResult Dashboard()
        {
            var model = new Total
            {
                TotalEtudiants = _dbContext.Etd.Count(),
                TotalProfesseurs = _dbContext.Prof.Count()
            };

            return View(model);
        }

    }
}
