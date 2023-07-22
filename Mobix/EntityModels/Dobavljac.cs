using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobix.EntityModels
{
    [Table("Dobavljaci")]
    public class Dobavljac
    {
        public int DobavljacID { get; set; }
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
    }
}
