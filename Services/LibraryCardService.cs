using WebApplication.Library.Models;
using WebApplication.Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Library.Services
{
    public class LibraryCardService : ILibraryService<LibraryCard>
    {
        private readonly LibraryCardRepository _libraryCardRp;

        public LibraryCardService(LibraryCardRepository libraryCardRp)
        {
            _libraryCardRp = libraryCardRp;
        }

        /// <summary>
        /// Проверяет есть ли карточка пользователя
        /// </summary>
        public bool GetById(int libraryCardId)
        {
            LibraryCard libraryCard = _libraryCardRp.GetLibraryCard(libraryCardId);
             return (libraryCard != null);
        }

        /// <summary>
        /// Добавляет карточку пользователя
        /// </summary>
        public IActionResult Create(LibraryCard libraryCard)
        {
            _libraryCardRp.Create(libraryCard);
            return new OkObjectResult("Карточка добавлена");
        }

        /// <summary>
        /// Изменяет данные карточки
        /// </summary>
        public void Update(LibraryCard libraryCard)
        {
            if (GetById(libraryCard.LibraryCardId))
            {
                _libraryCardRp.Update(libraryCard);
            }
        }

        /// <summary>
        /// Удаляет карточку по ID
        /// </summary>
        public IActionResult Delete(int libraryCardId)
        {
            if (GetById(libraryCardId))
            {
                _libraryCardRp.Delete(libraryCardId);
                return new OkObjectResult("Карточка пользователя удалена");
            }
            else return new NotFoundObjectResult("Ошибка удаления");
        }
    }
}
