using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Library.Services
{
    public interface ILibraryService<T> where T: class
    {
        bool GetById(int id); // получение одного объекта по id
        IActionResult Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        IActionResult Delete(int id); // удаление объекта по id
    }
}
