using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Library.Repositories
{
    public class LibraryCardRepository
    {
        private readonly LibraryContext _db;

        public LibraryCardRepository(LibraryContext db)
        {
            _db = db;
        }

        public LibraryCard GetLibraryCardList(int libraryCardId)
        {

            return _db.LibraryCards.Find(libraryCardId);
        }

        public LibraryCard GetLibraryCard(int id)
        {
            return _db.LibraryCards.Find(id);
        }

        public void Create(LibraryCard libraryCard)
        {
            _db.LibraryCards.Add(libraryCard);
        }

        public void Update(LibraryCard libraryCard)
        {
            _db.Entry(libraryCard).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            LibraryCard libraryCard = _db.LibraryCards.Find(id);
            if (libraryCard != null)
                _db.LibraryCards.Remove(libraryCard);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
