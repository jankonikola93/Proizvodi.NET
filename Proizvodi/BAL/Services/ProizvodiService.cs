using BAL.ViewModels;
using DAL.Models;
using DAL.Repository;
using DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BAL.Services
{
    public class ProizvodiService : IService<ProizvodViewModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Proizvod> proizvodiRepozitoryService;
        public ProizvodiService()
        {
            this.unitOfWork = new UnitOfWork();
            this.proizvodiRepozitoryService = unitOfWork.GenericRepository<Proizvod>();
        }

        public IEnumerable<ProizvodViewModel> GetAll()
        {
            var proizvodi = proizvodiRepozitoryService.GetAll();
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
            var p = proizvodiRepozitoryService.GetById(id);
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
            var entity = new Proizvod
            {
                Cena = t.Cena,
                Dobavljac = t.Dobavljac,
                Kategorija = t.Kategorija,
                Naziv = t.Naziv,
                Opis = t.Opis,
                Proizvodjac = t.Proizvodjac
            };
            try
            {
                proizvodiRepozitoryService.Create(entity);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                unitOfWork.LogError(e.ToString());
                return false;
            }
            return true;
        }

        public bool Update(ProizvodViewModel t)
        {
            var entity = new Proizvod
            {
                ID = t.ID,
                Cena = t.Cena,
                Dobavljac = t.Dobavljac,
                Kategorija = t.Kategorija,
                Naziv = t.Naziv,
                Opis = t.Opis,
                Proizvodjac = t.Proizvodjac
            };
            try
            {
                proizvodiRepozitoryService.Update(entity);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                unitOfWork.LogError(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                proizvodiRepozitoryService.Delete(id);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                unitOfWork.LogError(e.ToString());
                return false;
            }
            return true;
        }
    }
}
