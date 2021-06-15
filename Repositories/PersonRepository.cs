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
    public class PersonRepository
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
            _db.SaveChanges();
        }

        public void AddBook(int personId, Book book)
        {
            GetPerson(personId).APerson.Books.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int personId, Book book)
        {
            GetPerson(personId).APerson.Books.Remove(book);
            _db.SaveChanges();
        }
        public Person Update(Person newPerson)
        {
            Person person = GetPerson(newPerson.PersonId);
            person.FirstName = newPerson.FirstName;
            person.LastName = newPerson.LastName;
            person.Patronymic = newPerson.Patronymic;
            person.BirthDay = newPerson.BirthDay;
            _db.Entry(person).State = EntityState.Modified;
            _db.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            Person person = _db.People.Find(id);
            _db.People.Remove(person);
            _db.SaveChanges();
        }

        public void DeleteByName(Person newPerson)
        {
            Person person = _db.People.Find(newPerson.PersonId);
            _db.People.Remove(person);
            _db.SaveChanges();
        }
    }
}
