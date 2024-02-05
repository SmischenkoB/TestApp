using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    internal interface IService<T>
    {
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
        public Task DeleteById(int id);

    }
}
