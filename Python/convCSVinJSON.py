import json

muscoli = []
with open("tabellaMuscoli.csv", "r") as f:
    f.readline()
    muscoli = f.readlines()

esercizi = []
with open("tabellaEsercizi.csv", "r") as f:
    f.readline()
    esercizi = f.readlines()

elencoMuscoli = []
elencoEsercizi = []
for m in muscoli:
    campi = m.split(";")
    elencoMuscoli.append({
        "MuscoloID": int(campi[0]),
        "Descrizione": campi[1].replace("\n", "").replace("'","&apos;")
    })

for e in esercizi:
    campi = e.split(";")
    elencoEsercizi.append({
        "EsercizioID": int(campi[0]),
        "NomeEsercizio": campi[1].replace("'","&apos;"),
        "Descrizione": campi[2].replace("'","&apos;"),
        "NumeroSerie": int(campi[3]),
        "NumeroRipetizioni": int(campi[4]),
        "SecondiRecupero": int(campi[5]),
        "MuscoloID": int(campi[6]),
        "VideoURL": campi[7].replace("\n", "")
    })

with open("muscoli.json", "w") as f:
    json.dump(elencoMuscoli, f, indent=2)

with open("esercizi.json", "w") as f:
    json.dump(elencoEsercizi, f, indent=2)
