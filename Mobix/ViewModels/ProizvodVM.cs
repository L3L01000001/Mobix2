using System.ComponentModel.DataAnnotations;

namespace Mobix.ViewModels
{
    public class ProizvodVM
    {

        public string? Naziv { get; set; }
        public string? Stanje { get; set; }
        public int? Kolicina { get; set; }
        public int? Cijena { get; set; }
        public string? Opis { get; set; }

        public string? SlikaProizvoda { get; set; }

        public IFormFile SlikaFile { get; set; }
        public int? DobavljacProizvodaID { get; set; }

    }
}
