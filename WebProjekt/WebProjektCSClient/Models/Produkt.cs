using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProjektCSClient.Models
{
    public class Produkt
    {
        [Key]
        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }
    }
}