using MobixWebShop.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mobix.EntityModels
{
    [Table("KorpaStavke")]
    public class KorpaStavke
    {
        public int ID { get; set; }

        public int? KorpaId { get; set; }
        public Korpa? Korpa { get; set; }
        public int? ProizvodID { get; set; }
        public Proizvod? Proizvod { get; set; }
        public int? Kolicina { get; set; }
    }
}
