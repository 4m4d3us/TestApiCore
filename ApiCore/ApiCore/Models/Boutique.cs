using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class Boutique
    {
        public int BoutiqueId { get; set; }
        public string Nom { get; set; }
        public List<Client> Clients { get; set; }
        public List<Vente> Ventes { get; set; }
    }
}
