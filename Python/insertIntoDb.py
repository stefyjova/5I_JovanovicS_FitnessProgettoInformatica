import collections
import json
import sqlite3

esercizi = []
with open("esercizi.json", "r") as f:
    esercizi = json.load(f)

muscoli = []
with open("muscoli.json", "r") as f:
    muscoli = json.load(f)

connection = sqlite3.connect('Data/DbEsercizi.db')
cursor = connection.cursor()

for m in muscoli:
    query = f"INSERT INTO Muscoli VALUES({m['MuscoloID']}, '{m['Descrizione']}');"
    cursor.execute(query)

for e in esercizi:
    query = f"INSERT INTO Esercizi VALUES({e['EsercizioID']}, '{e['NomeEsercizio']}', '{e['Descrizione']}', {e['NumeroSerie']}, {e['NumeroRipetizioni']}, {e['SecondiRecupero']}, {e['MuscoloID']}, {e['VideoURL']});"
    cursor.execute(query)

connection.commit()
connection.close()