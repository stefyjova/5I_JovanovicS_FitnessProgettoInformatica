public class Muscolo {

    public int MuscoloID { get; set; }

    public string Descrizione { get; set; }

    public ICollection<Esercizio> Esercizi {get; set;}

    public MuscoloDTO GetDTO() => new MuscoloDTO() {
        MuscoloID = this.MuscoloID,
        Descrizione = this.Descrizione
        };


}