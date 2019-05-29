using BAL.ViewModels;
using DALzaJSON.DTO;
using DALzaJSON.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ProizvodiServiceJson : IProizvodiServiceJson
    {
        private readonly IJsonService<ProizvodDTO> _proizvodiJsonService;
        //private readonly string jsonFilePath;
        public ProizvodiServiceJson(IJsonService<ProizvodDTO> proizvodiJsonService)
        {
            //this.jsonFilePath = ConfigurationManager.AppSettings["JsonFilePath"].ToString();
            _proizvodiJsonService = proizvodiJsonService;
        }
        public IEnumerable<ProizvodViewModel> GetAll()
        {
            var proizvodi = _proizvodiJsonService.GetAll();
            if (proizvodi == null)
                return null;
            var viewModel = from p in proizvodi
                            select (new ProizvodViewModel
                            {
                                Cena = p.Cena,
                                Dobavljac = p.Dobavljac,
                                ID = p.ID,
                                Kategorija = p.Kategorija,
                                Naziv = p.Naziv,
                                Opis = p.Opis,
                                Proizvodjac = p.Proizvodjac
                            });
            return viewModel;
        }

        public ProizvodViewModel GetById(int id)
        {
            var p = _proizvodiJsonService.GetById(id);
            if (p == null)
                return null;
            var viewModel = new ProizvodViewModel
            {
                Cena = p.Cena,
                Dobavljac = p.Dobavljac,
                ID = p.ID,
                Kategorija = p.Kategorija,
                Naziv = p.Naziv,
                Opis = p.Opis,
                Proizvodjac = p.Proizvodjac
            };
            return viewModel;
        }

        public bool Create(ProizvodViewModel t)
        {
            var list = _proizvodiJsonService.GetAll();
            int poslednjiId = 1;
            if(list.Count > 0)
                poslednjiId = list.Max(p => p.ID) + 1;
            
            var entity = new ProizvodDTO
            {
                Cena = t.Cena,
                Dobavljac = t.Dobavljac,
                ID = poslednjiId,
                Kategorija = t.Kategorija,
                Naziv = t.Naziv,
                Opis = t.Opis,
                Proizvodjac = t.Proizvodjac
            };
            return _proizvodiJsonService.Create(entity);
        }

        public bool Update(ProizvodViewModel t)
        {
            var entity = new ProizvodDTO
            {
                ID = t.ID,
                Cena = t.Cena,
                Dobavljac = t.Dobavljac,
                Kategorija = t.Kategorija,
                Naziv = t.Naziv,
                Opis = t.Opis,
                Proizvodjac = t.Proizvodjac
            };
            return _proizvodiJsonService.Update(entity);
        }

        public bool Delete(int id)
        {
            return _proizvodiJsonService.Delete(id);
        }
    }
}
