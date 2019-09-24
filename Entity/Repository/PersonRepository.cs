using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Extension;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {

        private readonly TMSDBContext _context;
        private readonly ILogger<IPersonRepository> _logger;
        public PersonRepository(TMSDBContext context, ILogger<IPersonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeleteData(int? personId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var person = await _context.Person.FindAsync(personId);
                _context.Person.Remove(person);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Person> GetData(int? personId)
        {
            const string func = "GetData";
            try
            {
                return await _context.Person.FindAsync(personId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public PagedResult<Person> GetList(PersonFilter filter, Paging paging)
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var persons = _context.Person.Select(p => new Person(){
                    PersonId = p.PersonId,
                    CitizenId = p.CitizenId,
                    Prefix = p.Prefix,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    Email = p.Email,
                    MobilePhone = p.MobilePhone,
                    TrainingAmount = _context.Attendee.Where(a => a.CitizenId == p.CitizenId).Count()
                });
                if (!string.IsNullOrEmpty(filter.CitizenId))
                    persons = persons.Where(p => p.CitizenId.ToLower().Contains(filter.CitizenId.ToLower()));
                if (!string.IsNullOrEmpty(filter.FullName))
                    persons = persons.Where(p => p.FirstName.ToLower().Contains(filter.FullName.ToLower()) ||
                    p.LastName.ToLower().Contains(filter.FullName.ToLower()));

                // Not paging
                if (paging == null)
                {
                    paging = new Paging()
                    {
                        CurrentPage = 1,
                        PageSize = int.MaxValue
                    };
                }

                var result = persons.GetPaged(paging.CurrentPage, paging.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Person> SaveData(Person person)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (person.PersonId == 0)
                {
                    _context.Person.Add(person);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Person.Update(person);
                    await _context.SaveChangesAsync();
                }
                return person;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
