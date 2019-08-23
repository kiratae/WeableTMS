using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Model.RepositoryModel
{
    public interface IFileRepository
    {
        Task<bool> DeleteData(int fileId);
        Task<File> GetData(int fileId);
        Task<File> SaveData(File file);
    }
}
