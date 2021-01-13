/* 
Copyright 2020 Vittorio Lo Mele
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file 
except in compliance with the License. You may obtain a copy of the License at
   http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under the 
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
either express or implied. See the License for the specific language governing permissions 
and limitations under the License.
*/
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace OrarioVideolezioni
{
    class GestoreDatabase
    {
        private SQLiteConnection database; //oggetto db
        private Funzioni func = new Funzioni(); //classe funzioni
        private string percorsoDB; //percorso completo del file di database
        /*
         Costruttore della classe: è possibile specificare un percorso alternativo oppure richiedere
        che il database venga caricato senza eseguire le operazioni di init. Quest'ultima variabile assicura 
        che le finestre secondarie possano accedere al database senza dover eseguire di nuovo le operazioni
        di init, dato che si suppone siano già state eseguite dalla finestra principale. La prima variabile,
        invece, non è utilizzata, ma è stata predisposta per utilizzi futuri.
         */
        public GestoreDatabase(string percorsoalternativo = "", bool preinit = false)
        {
            //ottieni percorso appdata dedicato all'applicazione
            string percorsoAppdata = func.getPercorsoAppdata();

            //se è stato specificato un percorso alternativo imposta quello come sorgente dati per SQLite
            if(percorsoalternativo != "")
            {
                percorsoDB = percorsoalternativo;
            }
            else
            {
                //utilizza il percorso di default, ovvero "%AppData%/OrarioVideolezioni/orario.db"
                percorsoDB = Path.Combine(percorsoAppdata, "orario.db");
            }

            if (preinit)
            {
                //se l'opzione di preinit è stata specificata, carica il database immediatamente...
                //...senza effettuare nessuna operazione di controllo.

                //ATTENZIONE! - Se usato impropriamente causerà crash e perdita di dati.
                database = new SQLiteConnection("Data Source=" + percorsoDB);
            }
        }
        
        public string getPercorsoFileDatabase()
        {
            return percorsoDB;
        }

        public void forceClose()
        {
            //chiude la connessione al database dell'istanza corrente
            database.Close();
            //libera tutte le risorse sul file database dell'istanza corrente
            database.Dispose();
            //ripulisci tutte le pool dati dell'app
            SQLiteConnection.ClearAllPools();
        }

        //funzione di inzializzazione database
        public bool initDatabase()
        {
            //apri la sorgente dati (al primo avvio il file non esiste, la libreria lo crea in automatico)
            database = new SQLiteConnection("Data Source=" + percorsoDB);
            //creazione comando di check
            var check = database.CreateCommand();
            check.CommandText = "pragma quick_check"; //comando di controllo, se il database è valido non restituisce errori
            try
            {
                //codice di test database
                database.Open(); //apri conn.
                check.ExecuteNonQuery(); //esegui query ignorando la risposta
                database.Close(); //chiudi conn.
            }
            catch (SQLiteException)
            {
                //eccezione generata: il file database è corrotto, mostra messaggio di errore
                var res = MessageBox.Show("File di database corrotto o non valido! Eliminare il database esistente per ricrearlo?",
                    "Errore Critico", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res == DialogResult.Yes)
                {
                    //in caso l'utente sceglie di rigenerare da zero il db
                    forceClose(); //libera tutte le risorse
                    File.Delete(percorsoDB); //elimina il file corrotto
                    database = new SQLiteConnection("Data Source=" + percorsoDB); //ricrea la connessione su nuovo file
                }
                else
                {
                    //in caso l'utente sceglie di mantenere il file libera tutte le risorse
                    forceClose();
                    Environment.FailFast("Il file database non è valido!"); // e termina immediatamente l'app
                    //System.Windows.Forms.Application.Exit();
                }
            }
            //il check di integrità è andato a buon fine
            try
            {
                database.Open(); //riapri connessione
                var comandoInitTabelle = database.CreateCommand();
                //inizializza le tabelle del database
                string comando =
                    @"BEGIN TRANSACTION;                  

                    CREATE TABLE IF NOT EXISTS orario(
                        Id integer PRIMARY KEY,
                        GiornoSettimana text,
                        IntervalloInizio integer,
                        IntervalloFine integer,
                        Materia text,
                        Link text);

                    CREATE TABLE IF NOT EXISTS materie(
                        Id integer PRIMARY KEY,
                        NomeMateria text,
                        NomeProf text);

                    COMMIT;
                    "; //N.B: se le tabelle esistono non vengono ricreate (CREATE TABLE IF NOT EXISTS)
                comandoInitTabelle.CommandText = comando;
                comandoInitTabelle.ExecuteNonQuery(); //esegui comando ignorando risposta
            }catch(SQLiteException)
            {
                //in caso di errore chiudi connessione
                database.Close();
                return false;
            }
            //tutto ok, chiudi conn. e ritorna 
            database.Close();
            return true;
        }

        //funzione di aggiunta riga all'orario
        public bool aggiungiRiga(string giorno, int inizio, int fine, string materia, string link)
        {
            //crea comando
            var comandoInserisci = database.CreateCommand();
            comandoInserisci.CommandText =
                "INSERT INTO orario(GiornoSettimana, IntervalloInizio, IntervalloFine, Materia, Link)VALUES($giorno, $inizio, $fine, $materia, $link);";
            //binda i parametri
            comandoInserisci.Parameters.AddWithValue("$giorno", giorno);
            comandoInserisci.Parameters.AddWithValue("$inizio", inizio);
            comandoInserisci.Parameters.AddWithValue("$fine", fine);
            comandoInserisci.Parameters.AddWithValue("$materia", materia);
            comandoInserisci.Parameters.AddWithValue("$link", link);
            try
            {
                database.Open();
                comandoInserisci.ExecuteNonQuery();
                database.Close();
            }catch(SQLiteException)
            {
                return false;
            }
            return true;
        }

        //funzione di modifica riga all'orario
        public bool modificaRigaMatiera(string giorno, int inizio, int fine, string materia, string link)
        {
            //crea comando
            var comandoInserisci = database.CreateCommand();
            comandoInserisci.CommandText =
                "UPDATE orario SET GiornoSettimana = $giorno, IntervalloInizio = $inizio, IntervalloFine = $fine, Materia = $materia, Link = $link);";
            //binda i parametri
            comandoInserisci.Parameters.AddWithValue("$giorno", giorno);
            comandoInserisci.Parameters.AddWithValue("$inizio", inizio);
            comandoInserisci.Parameters.AddWithValue("$fine", fine);
            comandoInserisci.Parameters.AddWithValue("$materia", materia);
            comandoInserisci.Parameters.AddWithValue("$link", link);
            try
            {
                database.Open();
                comandoInserisci.ExecuteNonQuery();
                database.Close();
            }
            catch (SQLiteException)
            {
                return false;
            }
            return true;
        }

        //aggiunta riga alla tabella delle materie
        public bool aggRigaMateria(string nomemat, string nomeprof)
        {
            var comandoInserisciMat = database.CreateCommand();
            comandoInserisciMat.CommandText = "INSERT INTO materie(NomeMateria, NomeProf) VALUES ($nomemateria, $nomeprof);";
            comandoInserisciMat.Parameters.AddWithValue("$nomemateria", nomemat);
            comandoInserisciMat.Parameters.AddWithValue("$nomeprof", nomeprof);
            try
            {
                database.Open();
                comandoInserisciMat.ExecuteNonQuery();
                database.Close();
            }
            catch (SQLiteException)
            {
                return false;
            }
            return true;
        }

        //rimuovi riga dall'orario
        public bool rimuoviRiga(int id)
        {
            var comandoRimuovi = database.CreateCommand();
            comandoRimuovi.CommandText = "DELETE FROM orario WHERE Id = $id";
            comandoRimuovi.Parameters.AddWithValue("$id", id);
            try
            {
                database.Open();
                comandoRimuovi.ExecuteNonQuery();
                database.Close();
            }catch(SQLiteException)
            {
                return false;
            }
            return true;
        }

        //rimuovi riga materia
        public bool rimRigaMateria(int id)
        {
            var comandoRimuoviMat = database.CreateCommand();
            comandoRimuoviMat.CommandText = "DELETE FROM materie WHERE Id = $id";
            comandoRimuoviMat.Parameters.AddWithValue("$id", id);
            try
            {
                database.Open();
                comandoRimuoviMat.ExecuteNonQuery();
                database.Close();
            }
            catch (SQLiteException)
            {
                return false;
            }
            return true;
        }

        //ottieni tabella principale
        public DataTable getTabella()
        {
            //creo una nuova struttura nella tabella dt
            DataTable dt = new DataTable();
            //inserisco tutte le colonne ed i relativi tipi
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Giorno", typeof(string)));
            dt.Columns.Add(new DataColumn("Ora Inizio", typeof(string)));
            dt.Columns.Add(new DataColumn("Ora Fine", typeof(string)));
            dt.Columns.Add(new DataColumn("Materia", typeof(string)));
            dt.Columns.Add(new DataColumn("Link", typeof(string)));
            //creo la query di selezione
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT * FROM orario;";
            try
            {
                //apro il database e creo un buffer riga 
                database.Open();
                DataRow dr;
                //creo la variabile leggi come lettore risposte SQL
                using(var leggi = cmd.ExecuteReader())
                {
                    //finchè non arrivo alla fine delle righe
                    while (leggi.Read())
                    {
                        dr = dt.NewRow(); //ripulisci il buffer riga e ricrealo secondo la struttura della tabella principale
                        //copio tutti i dati nel buffer
                        dr[0] = leggi.GetInt32(0); 
                        dr[1] = func.convertiGiorno(leggi.GetString(1), true);
                        dr[2] = func.secondiAdUmano(leggi.GetInt32(2));
                        dr[3] = func.secondiAdUmano(leggi.GetInt32(3));
                        dr[4] = leggi.GetString(4);
                        dr[5] = leggi.GetString(5);
                        //aggiugo la riga buffer alla tabella principale e ripeto
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (SQLiteException)
            {
                //catch eccezione
            }
            database.Close();
            //ritorno la tabella finita
            return dt;
        }
        
        //stesso funzionamento della funzione precedente
        //preleva i dati dalla tabella della lista materie
        public DataTable getListaMaterie()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Nome Materia", typeof(string)));
            dt.Columns.Add(new DataColumn("Nome Professore", typeof(string)));
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT * FROM materie;";
            try
            {
                database.Open();
                DataRow dr;
                using(var leggi = cmd.ExecuteReader())
                {
                    while (leggi.Read())
                    {
                        dr = dt.NewRow();
                        dr[0] = leggi.GetInt32(0);
                        dr[1] = leggi.GetString(1);
                        dr[2] = leggi.GetString(2);
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (SQLiteException)
            {
                
            }
            database.Close();
            return dt;
        }

        //ottiene la lista materie in un formato utilizzabile dai menù a tendina
        public List<string> getListaMaterieCombo()
        {
            //creo la lista di stringhe che conterrà le materie
            List<string> listaMatCombo = new List<string>();
            //comando di selezione
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT * FROM materie;";
            try
            {
                //apro il database e creo una stringa di buffer
                database.Open();
                string buf;
                //creo un lettore SQL
                using (var leggi = cmd.ExecuteReader())
                {
                    //finchè non arrivo alla fine della lista materie
                    while (leggi.Read())
                    {
                        //ripulisco il buffer stringa e compongo la stringa finale
                        //esempio: $riga[1] ( $riga[2] ) ---> "Nome Materia (Nome Prof)"
                        buf = leggi.GetString(1) + " (" + leggi.GetString(2) + ")";
                        listaMatCombo.Add(buf); //aggiungo la stringa appena creata alla lista finale
                    }
                }
            }
            catch (SQLiteException)
            {

            }
            //ritorna la lista finale
            database.Close();
            return listaMatCombo;
        }

        //funzione per trovare il link attivo in base all'ora corrente
        public LinkAttivo trovaLinkAttivo()
        {
            //creo la variabile di tipo LinkAttivo che conterrà le informazioni (vedi LinkAttivo.cs)
            LinkAttivo la = new LinkAttivo();
            //creo comando di selezione dal DB
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT Id, Materia, Link FROM orario WHERE GiornoSettimana = $giorno AND IntervalloInizio <= $ct AND IntervalloFine > $ct";
            //prelevo data ed ora dal computer
            string giorno = func.dtToDatabaseFormat(DateTime.Today.DayOfWeek);
            int ct = func.calcolaIntervalloSecondi(DateTime.Now.Hour, DateTime.Now.Minute);
            //bind parametri
            cmd.Parameters.AddWithValue("$giorno", giorno);
            cmd.Parameters.AddWithValue("$ct", ct);
            //N.B.: Si potrebbe implementare la possibilità di leggere più righe aventi lo stesso orario
            //ma al momento non è stato fatto (tengo in considerazione per feature futura)
            try
            {
                //apri il database
                database.Open();
                //leggi solo la prima riga (n.b. sopra)
                var leggi = cmd.ExecuteReader();
                leggi.Read();
                try
                {
                    //prova a leggere i valori
                    la.Id = leggi.GetInt32(0);
                    la.NomeMat = leggi.GetString(1);
                    la.Link = leggi.GetString(2);
                }
                catch(InvalidOperationException)
                {
                    //in caso nessun link è attivo chiudi e ritorna NULL

                    //N.B.: Il null se non viene gestito correttamente dalla funzione chiamante potrrebbe causare...
                    //...crash inaspettati. Usare con cautela e controllare sempre i valori ritornati dalla seguente funzione.
                    database.Close();
                    return null;
                }
            }
            catch (SQLiteException)
            {
                database.Close();
                return null;
            }
            //link trovato, ritorna
            database.Close();
            return la;
        }

        //aggiorna riga materia
        public bool aggiornaRigaMateria(int id, string nuovonome)
        {
            var comandoAggiornaMat = database.CreateCommand();
            comandoAggiornaMat.CommandText = "UPDATE materie SET NomeProf = $nuovonome WHERE Id = $id";
            comandoAggiornaMat.Parameters.AddWithValue("$nuovonome", nuovonome);
            comandoAggiornaMat.Parameters.AddWithValue("$id", id);
            try
            {
                database.Open();
                comandoAggiornaMat.ExecuteNonQuery();
                database.Close();
            }
            catch (SQLiteException)
            {
                return false;
            }
            return true;
        }
    }
}
