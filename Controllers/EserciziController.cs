using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System.Linq;

namespace _5I_jovanovicS_progettoInformatica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EserciziController : ControllerBase
{
    private readonly DbEsercizi _context;

    public EserciziController(DbEsercizi context)
    {
        _context = context;
    }

    [EnableCors("MyPolicy")]
    [HttpGet("Muscoli")]
    public async Task<ActionResult<IEnumerable<MuscoloDTO>>> GetMuscoli()
    {
        List<Muscolo> elencoMuscoli = await _context.Muscoli.ToListAsync();
        List<MuscoloDTO> elencoDTO = new List<MuscoloDTO>();
        foreach(Muscolo muscolo in elencoMuscoli) {
            elencoDTO.Add(muscolo.GetDTO());
        }
        return elencoDTO;
    }

    [EnableCors("MyPolicy")]
    [HttpGet("{idMuscolo}")]
    public async Task<ActionResult<IEnumerable<EsercizioDTO>>> GetEsercizi(int idMuscolo)
    {
        List<Esercizio> elencoEsercizi = await _context.Esercizi.Where(x => x.MuscoloID == idMuscolo).ToListAsync();

        if(!elencoEsercizi.Any()) return BadRequest("IDMuscolo non trovato");

        List<EsercizioDTO> elencoDTO = new List<EsercizioDTO>();

        foreach(Esercizio esercizio in elencoEsercizi) {
            elencoDTO.Add(await esercizio.GetDTO(_context));
        }
        return elencoDTO;
    }

    [EnableCors("MyPolicy")]
    [HttpGet("Random")]
    public async Task<ActionResult<EsercizioDTO>> GetEsercizioRandom()
    {
        List<Esercizio> elencoEsercizi = await _context.Esercizi.ToListAsync();
        return await elencoEsercizi.OrderBy(o => Guid.NewGuid()).First().GetDTO(_context);
    }



}

