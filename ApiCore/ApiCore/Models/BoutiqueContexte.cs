using Microsoft.EntityFrameworkCore;

namespace ApiCore.Models
{
    public class BoutiqueContexte : DbContext
    {
        public DbSet<Boutique> Boutiques { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<Produit> Produits { get; set; }

        public BoutiqueContexte(DbContextOptions<BoutiqueContexte> options)
           : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vente>()
                .HasOne(v => v.Boutique)
                .WithMany(b=>b.Ventes)
                .HasForeignKey(v=>v.BoutiqueId);

            builder.Entity<Vente>()
                .HasOne(v => v.Produit)
                .WithMany(p => p.Ventes)
                .HasForeignKey(v=>v.ProduitId);

            builder.Entity<Vente>()
                .HasOne(v => v.Client)
                .WithMany(c => c.Ventes)
                .HasForeignKey(v=>v.ClientId);

            InitialiseData(builder);
        }

        private void InitialiseData(ModelBuilder builder)
        {
            builder.Entity<Boutique>().HasData(Rule, Zala, Ralio, Snack);

            builder.Entity<Client>().HasData(Jean, Fred, Kaya, Ahmed);

            builder.Entity<Produit>().HasData(Basket, Console, Ordinateur, Pneu, Lampe);

            builder.Entity<Vente>()
                .HasData(
                new Vente { VenteId = 1,  BoutiqueId = 1,  ProduitId = 4,  ClientId = 1, Quantite = 4 },
                new Vente { VenteId = 2,  BoutiqueId = 1, ProduitId = 2,  ClientId = 3, Quantite = 1 },
                new Vente { VenteId = 3,  BoutiqueId =3, ProduitId = 4,  ClientId = 4, Quantite = 7 },
                new Vente { VenteId = 4,  BoutiqueId =4, ProduitId = 1,  ClientId = 3, Quantite = 2 },
                new Vente { VenteId = 5,  BoutiqueId = 1, ProduitId = 3,  ClientId = 3, Quantite = 1 },
                new Vente { VenteId = 6,  BoutiqueId = 1,  ProduitId = 5,  ClientId = 4, Quantite = 8 },
                new Vente { VenteId = 7,  BoutiqueId =3, ProduitId = 3,  ClientId = 3, Quantite = 4 },
                new Vente { VenteId = 8,  BoutiqueId =4, ProduitId = 4,  ClientId = 1, Quantite = 30 },
                new Vente { VenteId = 9,  BoutiqueId = 1, ProduitId = 2,  ClientId = 1, Quantite = 3 },
                new Vente { VenteId = 10,  BoutiqueId = 2, ProduitId = 4,  ClientId = 3, Quantite = 14 },
                new Vente { VenteId = 11,  BoutiqueId =4,  ProduitId = 5,  ClientId = 3, Quantite = 10 },
                new Vente { VenteId = 12,  BoutiqueId = 2, ProduitId = 4,  ClientId = 3, Quantite = 4 },
                new Vente { VenteId = 13,  BoutiqueId = 1, ProduitId = 1,  ClientId = 3, Quantite = 45 },
                new Vente { VenteId = 14,  BoutiqueId =4, ProduitId = 4,  ClientId = 1, Quantite = 4 },
                new Vente { VenteId = 15,  BoutiqueId = 1, ProduitId = 4,  ClientId = 1, Quantite = 4 },
                new Vente { VenteId = 16,  BoutiqueId = 2, ProduitId = 3,  ClientId = 3, Quantite = 8 },
                new Vente { VenteId = 17,  BoutiqueId = 1,  ProduitId = 5,  ClientId = 1, Quantite = 4 },
                new Vente { VenteId = 18,  BoutiqueId =4, ProduitId = 4,  ClientId = 3, Quantite = 8 },
                new Vente { VenteId = 19,  BoutiqueId = 2, ProduitId = 1,  ClientId = 1, Quantite = 4 },
                new Vente { VenteId = 20,  BoutiqueId =3, ProduitId = 3,  ClientId = 2, Quantite = 4 },
                new Vente { VenteId = 21,  BoutiqueId = 2, ProduitId = 2,  ClientId = 2, Quantite = 4 },
                new Vente { VenteId = 22,  BoutiqueId = 2, ProduitId = 1,  ClientId = 2, Quantite = 10 },
                new Vente { VenteId = 23,  BoutiqueId = 1, ProduitId = 4,  ClientId = 2, Quantite = 4 },
                new Vente { VenteId = 24,  BoutiqueId =3, ProduitId = 3,  ClientId = 4, Quantite = 2 },
                new Vente { VenteId = 25,  BoutiqueId = 1, ProduitId = 4,  ClientId = 4, Quantite = 12 },
                new Vente { VenteId = 26,  BoutiqueId = 2,  ProduitId = 5,  ClientId = 4, Quantite = 3 },
                new Vente { VenteId = 27,  BoutiqueId =4,  ProduitId = 5,  ClientId = 4, Quantite = 4 }
                );
        }

        Boutique Rule = new Boutique { BoutiqueId = 1, Nom = "Rule" };
        Boutique Zala = new Boutique { BoutiqueId = 2, Nom = "Zala" };
        Boutique Ralio = new Boutique { BoutiqueId = 3, Nom = "Ralio" };
        Boutique Snack = new Boutique { BoutiqueId = 4, Nom = "Snack" };

        Client Jean = new Client { ClientId = 1 , Nom = "Pierre", Prenom = "Jean" };
        Client Fred = new Client { ClientId = 2, Nom = "Pierre", Prenom = "Frédéric" };
        Client Kaya = new Client { ClientId = 3, Nom = "Zaki", Prenom = "Kaya" };
        Client Ahmed = new Client { ClientId = 4, Nom = "Hassan", Prenom = "Ahmed" };

        Produit Basket = new Produit { ProduitId = 1, Libelle = "Basket", Prix = 100 };
        Produit Console = new Produit { ProduitId = 2, Libelle = "Console", Prix = 400 };
        Produit Ordinateur = new Produit { ProduitId = 3, Libelle = "Ordinateur", Prix = 1000 };
        Produit Pneu = new Produit { ProduitId = 4, Libelle = "Pneu", Prix = 120 };
        Produit Lampe = new Produit { ProduitId = 5, Libelle = "Console", Prix = 80 };
    }
}
