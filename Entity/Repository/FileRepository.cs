using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IFileRepository> _logger;
        public FileRepository(TMSDBContext context, ILogger<IFileRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> DeleteData(int fileId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var file = await _context.File.FindAsync(fileId);
                _context.File.Remove(file);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<File> GetData(int fileId)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _context.File.FindAsync(fileId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<File> SaveData(File file)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (file.FileId == 0)
                {
                    _context.File.Add(file);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.File.Update(file);
                    await _context.SaveChangesAsync();
                }
                return file;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
