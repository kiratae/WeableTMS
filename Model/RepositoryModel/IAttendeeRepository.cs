using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IAttendeeRepository
    {
        PagedResult<Attendee> GetList(AttendeeFilter filter, Paging paging);
        Task<Attendee> GetData(int? attendeeId);
        Task<Attendee> SaveData(Attendee attendee);
        Task<bool> DeleteData(int? attendeeId);
    }
}
