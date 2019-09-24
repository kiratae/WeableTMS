using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.ServiceModel
{
    public interface IPersonService
    {
        PagedResult<Person> GetList(PersonFilter filter, Paging paging);
        Task<Person> GetData(int? personId);
        Task<Person> SaveData(Person person);
        Task<bool> DeleteData(int? personId);
    }
}
