using Mobix.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobixWebShop.EntityModels
{
    [Table("Proizvodi")]
    public class Proizvod
    {
        [Key]
        public int ProizvodID { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public string? Stanje { get; set; }
        public int? Cijena { get; set; }
        public string? SlikaProizvoda { get; set; }
        public int? Kolicina { get; set; }
        [ForeignKey(nameof(DobavljacProizvoda))]
        public int? DobavljacProizvodaID { get; set; }
        public Dobavljac? DobavljacProizvoda { get; set; }

    }
}
