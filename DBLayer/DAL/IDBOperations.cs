using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.DAL
{
    public interface IDBOperations<T>
    {
        public Task<T> AddValueToDb(T value);
        public Task RemoveValueFromDb(T value);
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
    }
}
