using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Produs
    {
        public int ID { get; set; }
        [Display(Name = "Nume Produs")]
        
        public string Nume { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Cantitate { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Total { get; set; }
        public int ProducatorID { get; set; }
        public Producator Producator { get; set; }
        public ICollection<CategorieProdus> CategoriiProdus { get; set; }
    }
}
