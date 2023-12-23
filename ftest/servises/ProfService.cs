using ftest.Data;
using ftest.VM;
using ftest.Models;
using System;

namespace ftest.servises
{
    public class ProfService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProfService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddBookWithAuthors(EtdVM etd)
        {
            var _book = new Etd()
            {
                Prenom = etd.Prenom,
                Nom = etd.Nom,
                Filiere = etd.Filiere,
                Niv = etd.Niv,
            };
            _dbContext.Etd.Add(_book);
            _dbContext.SaveChanges();

            foreach (var id in etd.ProfIds)
            {
                var _book_author = new EtdProf()
                {
                    EtdId = _book.Id,
                    ProfId = id
                };
                _dbContext.EtdProf.Add(_book_author);
                _dbContext.SaveChanges();
            }
        }

        public List<Etd> GetAllBooks() => _dbContext.Etd.ToList();
        public ProfEtdVM GetetdById(int etdId)
        {
            var _bookWithAuthors = _dbContext.Etd.Where(n => n.Id == etdId).Select(etd => new ProfEtdVM()
            {
                Prenom = etd.Prenom,
                Nom = etd.Nom,
                Filiere = etd.Filiere,
                Niv = etd.Niv,
                ProfNames = etd.EtdProfs.Select(n => n.Prof.Prenom).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }
        /*
        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }*/
    }
}
