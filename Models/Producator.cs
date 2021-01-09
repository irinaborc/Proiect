using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Producator
    {
        public int ID { get; set; }
        public string NumeProducator { get; set; }
        public ICollection<Produs> Produse { get; set; }
    }
}
