using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);

        

        Task< List<T>> GetAll();


        Task AddAsync (T model);

        Task UpdateAsync (T model);

        Task DeleteAsync (int id);

        Task SaveChange();
    }
}
