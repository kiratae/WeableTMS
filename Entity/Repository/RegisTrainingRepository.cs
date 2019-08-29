using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class RegisTrainingRepository : BaseRepository, IRegisTrainingRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<IRegisTrainingRepository> _logger;

        public RegisTrainingRepository(TMSDBContext context, ILogger<IRegisTrainingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<bool> CheckIsStudent(string citizenId, string StudentCode)
        {
            throw new NotImplementedException();
        }

        public RegisTraining CheckRepeatRegis(string citizenId, int? trainingId)
        {
            const string func = "CheckRepeatRegis";
            try
            {
                var attendees = from a in _context.Attendee
                                select a;

                if (trainingId.HasValue)
                    attendees = attendees.Where(atd => atd.CitizenId == citizenId && atd.TrainingId == trainingId);
                else
                    attendees = attendees.Where(atd => atd.CitizenId == citizenId);

                RegisTraining regisTraining = new RegisTraining
                {
                    Attendee = attendees.FirstOrDefault()
                };

                return regisTraining;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public bool CheckTrnPrerequisite(string citizenId, int? trainingId)
        {
            const string func = "CheckTrnPrerequisite";
            try
            {
                var result = (from tp in _context.TrnPrerequisite
                              join t in _context.Training on tp.CourseId equals t.CourseId
                              join a in _context.Attendee.Where(a => a.CitizenId == citizenId && a.TrainingResultId == 3) on t.TrainingId equals a.TrainingId
                              select tp
                                ).Where(tp => tp.TrainingId == trainingId);

                bool isAlready = result.Count() > 0;
                return isAlready;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public RegisTraining GetRegisTraining(string citizenId)
        {
            const string func = "SaveRegisTraining";
            try
            {
                Person person = _context.Person.Where(p => p.CitizenId == citizenId).SingleOrDefault();

                RegisTraining regisTraining = new RegisTraining
                {
                    Person = person
                };

                return regisTraining;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<RegisTraining> SaveRegisTraining(RegisTraining regisTraining)
        {
            const string func = "SaveRegisTraining";
            try
            {
                if (regisTraining == null)
                    throw new ArgumentException("regisTraining is null.");

                if (regisTraining.Person.PersonId == 0)
                    await _context.Person.AddAsync(regisTraining.Person);
                else
                    _context.Person.Update(regisTraining.Person);

                await _context.Attendee.AddAsync(regisTraining.Attendee);

                _context.Training.Update(regisTraining.Training);

                await _context.SaveChangesAsync();

                return regisTraining;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }
    }
}
