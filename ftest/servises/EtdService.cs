using ftest.Data;
using ftest.Models;
using ftest.VM;
using System;

namespace ftest.servises
{
    public class EtdService
    {
        private readonly ApplicationDbContext _dbContext;
        public EtdService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProf(ProfVM prf)
        {
            var _author = new Prof()
            {
                Prenom = prf.Prenom
            };
            _dbContext.Prof.Add(_author);
            _dbContext.SaveChanges();
        }

        public EtdProfVM Getetdprof(int Id)
        {
            var _author = _dbContext.Etd.Where(n => n.Id == Id).Select(n => new EtdProfVM()
            {
                Prenom = n.Prenom,
                EtdL = n.EtdProfs.Select(n => n.Etd.Prenom).ToList()
            }).FirstOrDefault();

            return _author;
        }


    









}

}
