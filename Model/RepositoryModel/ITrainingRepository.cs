using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface ITrainingRepository
    {
        PagedResult<Training> GetList(TrainingFilter filter, Paging paging);
        Task<Training> GetData(int? trainingId);
        Task<Training> SaveData(Training training);
        Task<bool> DeleteData(int? trainingId);
    }
}
