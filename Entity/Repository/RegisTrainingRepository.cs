using Microsoft.EntityFrameworkCore;
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

        public RegisTraining CheckRepeat(string citizenId, int? trainingId)
        {
            const string func = "Authentication";
            try
            {
                Attendee attendee = null;
                if (trainingId.HasValue)
                {
                    attendee = _context.Attendee.Where(t => t.CitizenId == citizenId && t.TrainingId == trainingId).FirstOrDefault();
                }

                RegisTraining regisTraining = new RegisTraining
                {
                    Attendee = attendee
                };

                return regisTraining;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public RegisTraining Authentication(string identification, string verifyCode, int? trainingId)
        {
            const string func = "Authentication";
            try
            {
                TargetGroupMember targetGroupMember = null;
                if (trainingId.HasValue)
                {
                    var training = _context.Training.Find(trainingId);
                    if (training.TargetGroupId.HasValue)
                    {
                        targetGroupMember = _context.TargetGroupMember.Where(t => t.TargetGroupId == training.TargetGroupId && t.Identification == identification && t.VerifyCode == verifyCode).FirstOrDefault();
                    }
                }

                RegisTraining regisTraining = new RegisTraining
                {
                    TargetGroupMember = targetGroupMember
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

        public int GetAttendeeQty(int trainingId)
        {
            const string func = "GetAttendeeQty";
            try
            {
                return _context.Attendee.Where(a => a.TrainingId == trainingId).Count();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public RegisTraining GetRegisTraining(string citizenId, int? targetGroupId)
        {
            const string func = "GetRegisTraining";
            try
            {
                TargetGroupMember targetGroupMember = null;
                Person person = _context.Person.Where(p => p.CitizenId == citizenId).SingleOrDefault();
                if (targetGroupId.HasValue)
                {
                    targetGroupMember = _context.TargetGroupMember.Where(t => t.TargetGroupId == targetGroupId && t.CitizenId == citizenId).FirstOrDefault();
                }

                RegisTraining regisTraining = new RegisTraining
                {
                    Person = person,
                    TargetGroupMember = targetGroupMember
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
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (regisTraining == null)
                            throw new ArgumentException("regisTraining is null.");

                        if (regisTraining.Person.PersonId == 0)
                            _context.Person.Add(regisTraining.Person);
                        else
                            _context.Person.Update(regisTraining.Person);

                        _context.SaveChanges();

                        Attendee attendee = new Attendee()
                        {
                            CitizenId = regisTraining.Person.CitizenId,
                            Registeration = DateTime.Now,
                            PersonId = regisTraining.Person.PersonId,
                            TrainingId = regisTraining.Training.TrainingId,
                            AtdStatusId = 1,
                            TrainingResultId = 1
                        };

                        _context.Attendee.Add(attendee);

                        _context.SaveChanges();

                        var training = _context.Training.Find(regisTraining.Training.TrainingId);
                        training.AttendeeQty = regisTraining.Training.AttendeeQty;

                        _context.Training.Update(training);

                        _context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

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
