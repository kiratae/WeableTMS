using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IRegisTrainingRepository
    {
        RegisTraining GetRegisTraining(string citizenId);
        Task<RegisTraining> SaveRegisTraining(RegisTraining regisTraining);
        RegisTraining CheckRepeatRegis(string citizenId, int? trainingId);
        bool CheckTrnPrerequisite(string citizenId, int? trainingId);

        Task<bool> CheckIsStudent(string citizenId, string StudentCode);
    }
}
