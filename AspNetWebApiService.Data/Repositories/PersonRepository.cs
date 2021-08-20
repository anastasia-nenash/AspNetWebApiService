using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApiService.Data.Interfaces;
using AspNetWebApiService.Data.Models;

namespace AspNetWebApiService.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext dataContext;

        public PersonRepository(DataContext dataContext = null)
        {
            this.dataContext = dataContext;
        }

        public Person AddOrUpdatePerson(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            Person personForUpdate = dataContext.People.Where(x => x.FirstName == firstName
                                                              && x.MiddleName == middleName
                                                              && x.LastName == lastName)
                                                       .FirstOrDefault();
            if (personForUpdate != null)
            {
                personForUpdate.FirstName = firstName;
                personForUpdate.LastName = lastName;
                personForUpdate.MiddleName = middleName;
                personForUpdate.DateOfBirth = dateOfBirth;
                dataContext.Update(personForUpdate);
                dataContext.SaveChanges();
                return personForUpdate;
            }
            else
            {
                var person = new Person()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth
                };
                dataContext.Add(person);
                dataContext.SaveChanges();
                return person;
            }
        }

        public void DeletePersonById(Guid personId)
        {
            dataContext.Remove(dataContext.People.Find(personId));
            dataContext.SaveChanges();
        }

        public void DeletePersonByName(string lastName, string firstName, string middleName)
        {
            dataContext.Remove(dataContext.People.Where(x => x.LastName == lastName
                                                        && x.FirstName == firstName
                                                        && x.MiddleName == middleName)
                                                  .FirstOrDefault());
            dataContext.SaveChanges();
        }

        public ICollection<Book> GetAllBooksByPerson(Guid personId)
        {
            return dataContext.Books.Include(x => x.Genres)
                                    .Include(x => x.LibraryCards)
                                    .Include(x => x.Author)
                                    .Where(x => x.LibraryCards.Any(x => x.PersonId == personId))
                                    .ToList();
        }
       
    }
}
