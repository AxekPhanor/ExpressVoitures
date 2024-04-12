using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IAnnonceService annonceService;
        private readonly IVoitureService voitureService;
        private readonly IVoitureEnregistreService voitureEnregistreService;
        public DataController(
            IAnnonceService annonceService,
            IVoitureService voitureService,
            IVoitureEnregistreService voitureEnregistreService)
        {
            this.annonceService = annonceService;
            this.voitureService = voitureService;
            this.voitureEnregistreService = voitureEnregistreService;
        }

        [HttpGet("ImportTxt")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> ImportTxt()
        {
            using (var sr = new StreamReader("data.txt"))
            {
                string? line = ".";
                string[] elements = new string[20];
                while (!String.IsNullOrEmpty(line))
                {
                    line = sr.ReadLine();
                    if (line is not null)
                    {
                        elements = line.Split(";");
                        var voiture = await voitureService
                            .Create(new VoitureInputModel
                            {
                                Marque = elements[0],
                                Annee = int.Parse(elements[1]),
                                Modele = elements[2],
                                Finition = elements[3]
                            });
                        var voitureEnregistreId = await voitureEnregistreService
                            .Create(new VoitureEnregistreInputModel
                            {
                                VoitureId = voiture.Id,
                                Reparations = elements[4],
                                CoutReparations = int.Parse(elements[5]),
                                DateAchat = new DateTime(
                                int.Parse(elements[6]),
                                int.Parse(elements[7]),
                                int.Parse(elements[8])),
                                PrixAchat = int.Parse(elements[9]),
                            });
                        var result = await annonceService
                            .Create(new AnnonceInputModel
                            {
                                VoitureEnregistreId = voitureEnregistreId,
                                Description = elements[10],
                                Photos = [],
                                PrixVente = int.Parse(elements[5]) + int.Parse(elements[9]) + 500,
                            });
                        if(!result)
                        {
                            return BadRequest("Erreur lors de la création d'une annonce");
                        }
                    }
                }
            }
            return Ok();
        }
    }
}
