using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class Vente
    {
        public int VenteId { get; set; }
        public int BoutiqueId { get; set; }
        public int ClientId { get; set; }
        public int ProduitId { get; set; }
        public Boutique Boutique { get; set; }
        public Client Client { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
    }
}
