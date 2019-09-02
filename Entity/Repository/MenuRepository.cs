using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IMenuRepository> _logger;
        public MenuRepository(TMSDBContext context, ILogger<IMenuRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Menu> GetData()
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return _context.Menu.AsEnumerable();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public IEnumerable<Menu> GetData(string UserRole)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return _context.Menu.Where(m => m.UserRole == UserRole).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
