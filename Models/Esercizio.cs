using System.ComponentModel.DataAnnotations.Schema;
public class Esercizio {

    public int EsercizioID { get; set; }

    public string NomeEsercizio { get; set; }

    public string Descrizione { get; set; }
    
    public int NumeroSerie { get; set; }

    public int NumeroRipetizioni { get; set; }
    public int SecondiRecupero { get; set; }

    public string VideoURL { get; set; }

    
    [ForeignKey("MuscoloID")]
    public int MuscoloID { get; set; }
    public Muscolo Muscolo { get; set; }


    public async Task<EsercizioDTO> GetDTO(DbEsercizi context) {

        Muscolo muscolo = await context.Muscoli.FindAsync(this.MuscoloID);
        return new EsercizioDTO(){
            NomeEsercizio = this.NomeEsercizio,
            Descrizione = this.Descrizione,
            NumeroSerie = this.NumeroSerie,
            NumeroRipetizioni = this.NumeroRipetizioni,
            SecondiRecupero = this.SecondiRecupero,
            Muscolo = (muscolo != null) ? muscolo.Descrizione : null,
            VideoURL = this.VideoURL
        };

    }

}
