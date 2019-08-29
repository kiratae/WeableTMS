using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public Task<bool> DeleteData(int? personId)
        {
            throw new NotImplementedException();
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

        public Task<List<Person>> GetList(PersonFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<Person> SaveData(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
