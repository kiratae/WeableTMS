using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.Model.ServiceModel
{
    public interface IFileService
    {
        Task<bool> DeleteData(int fileId);
        Task<File> GetData(int fileId);
        Task<File> SaveData(File file);
    }
}
