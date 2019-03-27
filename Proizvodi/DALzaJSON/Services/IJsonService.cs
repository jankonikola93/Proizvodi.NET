using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALzaJSON.Services
{
    public interface IJsonService<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
