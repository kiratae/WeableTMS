using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface ITrainingRepository
    {
        Task<List<Training>> GetList(TrainingFilter filter);
        Task<Training> GetData(int? trainingid);
        Task<Training> SaveData(Training training);
        Task<bool> DeleteData(int? trainingid);
    }
}
