using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IAttendeeRepository
    {
        Task<List<Attendee>> GetList(AttendeeFilter filter);
        Task<Attendee> GetData(int? attendeeId);
        Task<Attendee> SaveData(Attendee course);
        Task<bool> DeleteData(int? attendeeId);
    }
}
