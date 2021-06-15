using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Library.Repositories
{
    public interface IAuthorRepository
    {
        public IQueryable<Author> GetAuthorList();

        public Author GetAuthor(int id);
        
        public IQueryable<Author> GetBookList(int authorId);
        public bool Create(Author author);

        public void Update(Author newAuthor);

        public bool DeleteAuthor(int authorId);
        
    }
}
