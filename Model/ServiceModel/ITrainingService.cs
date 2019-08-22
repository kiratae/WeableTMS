using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Infrastructure.Model;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.ServiceModel
{
    public interface ITrainingService
    {
        PagedResult<Training> GetList(TrainingFilter filter, Paging paging);
        Task<Training> GetData(int? trainingId);
        Task<Training> SaveData(Training training);
        Task<bool> DeleteData(int? trainingId);
    }
}
