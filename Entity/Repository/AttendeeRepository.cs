using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class AttendeeRepository : BaseRepository, IAttendeeRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IAttendeeRepository> _logger;
        public AttendeeRepository(TMSDBContext context, ILogger<IAttendeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Task<bool> DeleteData(int? attendeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Attendee> GetData(int? attendeeId)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Attendee> GetList(AttendeeFilter filter, Paging paging)
        {
            throw new NotImplementedException();
        }

        public Task<Attendee> SaveData(Attendee attendee)
        {
            throw new NotImplementedException();
        }
    }
}
