using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string Libelle { get; set; }
        public float Prix { get; set; }

        public List<Vente> Ventes { get; set; }
    }
}
