using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IRegisTrainingRepository
    {
        RegisTraining GetRegisTraining(string citizenId, int? targetGroupId);
        Task<RegisTraining> SaveRegisTraining(RegisTraining regisTraining);
        RegisTraining Authentication(string identification, string verifyCode, int? trainingId);
        bool CheckTrnPrerequisite(string citizenId, int? trainingId);
        int GetAttendeeQty(int trainingId);

        Task<bool> CheckIsStudent(string citizenId, string StudentCode);
    }
}
