using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetWebApiService.Data.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private DataContext dataContext;

        public LibraryCardRepository(DataContext dataContext = null)
        {
            this.dataContext = dataContext;
        }

        public string PersonTakeBook(Guid bookId, Guid personId)
        {
            
            if (!dataContext.LibraryCards.Where(x => x.PersonId == personId).Where(x => x.DateOfReturnBook < DateTime.Now).Any())
            {
                dataContext.LibraryCards.Add(new LibraryCard()
                {
                    Id = Guid.NewGuid(),
                    BookId = bookId,
                    PersonId = personId,
                    DateOfReturnBook = DateTime.Now.AddDays(7)
                });
                dataContext.SaveChanges();
                return "Книга получена";
            }
            else
            {
                return "Нельзя получить новую книгу, пока не вернёшь старую!";
            }
        }

        public void PersonReturnedBook(Guid bookId, Guid personId)
        {
            var libraryCard = dataContext.LibraryCards.FirstOrDefault(x => x.PersonId == personId && x.PersonId == personId);
            dataContext.LibraryCards.Remove(libraryCard);
            dataContext.SaveChanges();
        }

        public ICollection<object> GetAllDebtors()
        {
            var cards = dataContext.LibraryCards.Where(x => x.DateOfReturnBook < DateTime.Now).ToList();
            
            List<object> debtors = new List<object>();
            foreach (var card in cards)
            {
                var person = dataContext.People.FirstOrDefault(x => x.Id == card.PersonId);
                var book = dataContext.Books.FirstOrDefault(x => x.Id == card.BookId);
                var timeOfDelay = (DateTime.Now - card.DateOfReturnBook).Days;
                debtors.Add(new
                {
                    PersonName = person.FirstName,
                    PersonMiddleName = person.MiddleName,
                    PersonLastName = person.LastName,
                    Book = book.Name,
                    TimeOfDelay = timeOfDelay
                });
            }
            return debtors;
        }

        public void ExtendDeadlineReturnBook(Guid bookId, Guid personId, int days)
        {
            var libraryCard = dataContext.LibraryCards.FirstOrDefault(x => x.BookId == bookId && x.PersonId == personId);
            if (libraryCard != null)
            {
                libraryCard.DateOfReturnBook = libraryCard.DateOfReturnBook.AddDays(days);
                dataContext.Update(libraryCard);
                dataContext.SaveChanges();
            }
        }
    }
}
