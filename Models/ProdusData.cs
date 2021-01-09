using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieProdus> CategoriiProdus { get; set; }
    }
}
