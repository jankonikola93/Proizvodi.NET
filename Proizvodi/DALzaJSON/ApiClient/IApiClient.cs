using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALzaJSON.ApiClient
{
    public interface IApiClient<T> where T : class
    {
        #region REST API
        ////Ove metode bi se koristile za preuzimanje podataka sa rest api-a
        ////Pretpostavljam da bi se u realnom problemu podaci preuzimali sa api-a a ne iz json fajla na racunaru
        //IEnumerable<T> GetMultipleItems(string apiString);
        //T GetSingleItem(string apiString, object id);
        //bool Put(string apiString, T entity);
        //bool Post(string apiString, T entity);
        //bool Delete(string apiString, object id);
        #endregion
        #region JSON
        IList<T> GetMultipleItems(string jsonFilePath);
        bool Save(string jsonFilePath, IList<T> list);
        #endregion
    }
}
