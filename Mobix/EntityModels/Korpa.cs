using System.ComponentModel.DataAnnotations.Schema;

namespace Mobix.EntityModels
{
    [Table("Korpa")]
    public class Korpa
    {
        public int ID { get; set; }
        public int? KorisnikId { get; set; }
        public Korisnik? Korisnik { get; set; }

        public List<KorpaStavke>? KorpaStavke { get; set; }
    }
}
