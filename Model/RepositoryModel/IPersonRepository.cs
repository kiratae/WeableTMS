using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetList(PersonFilter filter);
        Task<Person> GetData(int? personId);
        Task<Person> SaveData(Person person);
        Task<bool> DeleteData(int? personId);
    }
}
