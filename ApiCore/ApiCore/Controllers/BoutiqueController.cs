using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoutiqueController : ControllerBase
    {
        BoutiqueContexte boutiqueContexte;
        public BoutiqueController(BoutiqueContexte boutiqueContexte)
        {
            this.boutiqueContexte = boutiqueContexte;
            boutiqueContexte.Database.EnsureCreated();
        }
        // GET: api/<BoutiqueController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = boutiqueContexte.Boutiques.Select(
                b => new { 
                    b.Nom,
                    Ventes = b.Ventes.Select(
                        v => new {
                            v.Client. Nom,
                            v.Client.Prenom,
                            v.Produit.Libelle,
                            v.Quantite,
                            v.Produit.Prix }) });
            return Ok(result);
        }       
    }
}
