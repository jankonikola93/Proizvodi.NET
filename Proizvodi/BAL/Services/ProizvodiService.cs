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
    public class ProizvodiService : IProizvodiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Proizvod> _proizvodiRepozitoryService;
        public ProizvodiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _proizvodiRepozitoryService = unitOfWork.GenericRepository<Proizvod>();
        }

        public IEnumerable<ProizvodViewModel> GetAll()
        {
            var proizvodi = _proizvodiRepozitoryService.GetAll();
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
            var p = _proizvodiRepozitoryService.GetById(id);
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
                _proizvodiRepozitoryService.Create(entity);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                _unitOfWork.LogError(e.ToString());
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
                _proizvodiRepozitoryService.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                _unitOfWork.LogError(e.ToString());
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _proizvodiRepozitoryService.Delete(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                _unitOfWork.LogError(e.ToString());
                return false;
            }
            return true;
        }
    }
}
