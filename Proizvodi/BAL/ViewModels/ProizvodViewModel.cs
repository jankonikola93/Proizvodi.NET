using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModels
{
    public class ProizvodViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Naziv je obavezno polje!")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Opis je obavezno polje!")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Kategorija je obavezno polje!")]
        public string Kategorija { get; set; }
        [Required(ErrorMessage = "Proizvodjac je obavezno polje!")]
        public string Proizvodjac { get; set; }
        [Required(ErrorMessage = "Dobavljac je obavezno polje!")]
        public string Dobavljac { get; set; }
        [Required(ErrorMessage = "Cena je obavezno polje!")]
        [Range(1, double.MaxValue)]
        public double Cena { get; set; }
    }
}
