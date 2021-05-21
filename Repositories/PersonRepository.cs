using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.ModelsDTO;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace WebApplication.Library.Repositories
{
    public class PersonRepository : IDisposable
    {
        private readonly LibraryContext _db;

        public PersonRepository(LibraryContext db)
        {
            _db = db;
        }

        public IQueryable<BookDto> GetBookByPersonId(int personId)
        {
            var mapperBooks = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<Genre, GenreDto>();
            }).CreateMapper();

            var allBooks = mapperBooks.Map<IQueryable<BookDto>>(GetPerson(personId).APerson.Books);

            return allBooks;
        }

            public IEnumerable<Person> GetPersonList()
        {
            return _db.People;
        }

        public Person GetPerson(int id)
        {
            return _db.People.Find(id);
        }

        public void Create(Person person)
        {
            _db.People.Add(person);
        }

        public void AddBook(int personId, Book book)
        {
            GetPerson(personId).APerson.Books.Add(book);
        }

        public void DeleteBook(int personId, Book book)
        {
            GetPerson(personId).APerson.Books.Remove(book);
        }
        public Person Update(int personId, Person newPerson)
        {
            Person person = GetPerson(personId);
            person.FirstName = newPerson.FirstName;
            person.LastName = newPerson.LastName;
            person.Patronymic = newPerson.Patronymic;
            person.BirthDay = newPerson.BirthDay;
            _db.Entry(person).State = EntityState.Modified;
            return person;
        }

        public void Delete(int id)
        {
            Person person = _db.People.Find(id);
            if (person != null)
                _db.People.Remove(person);
        }

        public void DeleteByName(Person newPerson)
        {
            Person person = _db.People.Find(newPerson);
            if (person != null)
                _db.People.Remove(person);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
