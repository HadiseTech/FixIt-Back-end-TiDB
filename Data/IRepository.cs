using System.Collections.Generic;
using System.Threading.Tasks;
using fixit.DTO;

namespace fixit.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> GetData();
        Task<T> GetDataById(int id);
        Task<T> UpdateData(T student);
        Task<bool> DeleteData(T student);
        Task<T> PutJob(T job);
    }
}