using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Library.Services
{
    public interface ILibraryService<T> where T: class
    {
        bool FindById(int id); // проверка существования объекта по id
        IActionResult Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        IActionResult Delete(int id); // удаление объекта по id
    }
}
