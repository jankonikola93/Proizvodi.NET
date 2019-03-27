using DALzaJSON.ApiClient;
using DALzaJSON.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALzaJSON.Services
{
    public class ProizvodiJsonService : IJsonService<ProizvodDTO>
    {
        private readonly string jsonFilePath;
        private readonly IApiClient<ProizvodDTO> proizvodiClient;
        public ProizvodiJsonService(string jsonFilePath)
        {
            this.proizvodiClient = new ApiClient<ProizvodDTO>();
            this.jsonFilePath = jsonFilePath;
        }

        public bool Create(ProizvodDTO entity)
        {
            var list = proizvodiClient.GetMultipleItems(jsonFilePath);
            list.Add(entity);
            return proizvodiClient.Save(jsonFilePath, list);
        }

        public bool Delete(int id)
        {
            var list = proizvodiClient.GetMultipleItems(jsonFilePath);
            var entity = list.Where(p => p.ID == id).FirstOrDefault();
            if (entity != null)
            {
                list.Remove(entity);
                return proizvodiClient.Save(jsonFilePath, list);
            }
            return true;
        }

        public IList<ProizvodDTO> GetAll()
        {
            return proizvodiClient.GetMultipleItems(jsonFilePath);
        }

        public ProizvodDTO GetById(int id)
        {
            return proizvodiClient.GetMultipleItems(jsonFilePath).Where(p => p.ID == id).FirstOrDefault();
        }

        public bool Update(ProizvodDTO entity)
        {
            var list = proizvodiClient.GetMultipleItems(jsonFilePath);
            var old = list.Where(p => p.ID == entity.ID).FirstOrDefault();
            if (old != null)
                list.Remove(old);
            list.Add(entity);
            return proizvodiClient.Save(jsonFilePath, list);
        }
    }
}
