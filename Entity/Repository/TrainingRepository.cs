using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Infrastructure.Extension;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class TrainingRepository : BaseRepository, ITrainingRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<ITrainingRepository> _logger;
        public TrainingRepository(TMSDBContext context, ILogger<ITrainingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public PagedResult<Training> GetList(TrainingFilter filter, Paging paging)
        {
            const string func = "GetList";
            try
            {
                var trainings = _context.Training.AsQueryable();
                if (filter.CourseId.HasValue)
                {
                    trainings = trainings.Where(t => t.CourseId == filter.CourseId.Value);
                }
                trainings = trainings.Include(t => t.Course);

                if (!string.IsNullOrEmpty(filter.Name))
                    trainings = trainings.Where(t => t.Name.ToLower().Contains(filter.Name.ToLower()));

                // Not paging
                if (paging == null)
                {
                    paging = new Paging()
                    {
                        CurrentPage = 1,
                        PageSize = trainings.Count() + 1
                    };
                }

                var result = trainings.GetPaged(paging.CurrentPage, paging.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Training> GetData(int? trainingId)
        {
            const string func = "GetData";
            try
            {
                return await _context.Training.Include(t => t.Course).Where(t => t.TrainingId == trainingId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Training> SaveData(Training training)
        {
            const string func = "SaveData";
            try
            {
                if (training.TrainingId == 0)
                {
                    _context.Training.Add(training);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Training.Update(training);
                    await _context.SaveChangesAsync();
                }
                return training;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<bool> DeleteData(int? trainingId)
        {
            const string func = "DeleteData";
            try
            {
                var training = await _context.Training.FindAsync(trainingId);
                _context.Training.Remove(training);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

    }
}
