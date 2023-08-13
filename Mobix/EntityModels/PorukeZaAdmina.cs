using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mobix.EntityModels
{
    [Table("PorukeZaAdmina")]
    public class PorukeZaAdmina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
    }
}
