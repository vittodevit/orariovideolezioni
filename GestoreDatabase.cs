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

namespace OrarioVideolezioni
{
    class GestoreDatabase
    {
        private SQLiteConnection database;
        private Funzioni func = new Funzioni();
        public GestoreDatabase(string percorsoalternativo = "")
        {
            string percorsoDB;
            string percorsoAppdata = func.getPercorsoAppdata();

            if(percorsoalternativo != "")
            {
                percorsoDB = percorsoalternativo;
            }
            else
            {
                percorsoDB = Path.Combine(percorsoAppdata, "orario.db");
            }

            database = new SQLiteConnection(
                "Data Source=" +
                percorsoDB
            ); //new=false impedisce di ricreare il database, di conseguenza perdendo tutte le tabelle.
        }
        
        

        public int initDatabase()
        {
            try
            {
                database.Open();
                var comandoInitTabelle = database.CreateCommand();
                //inizializza database con file di init
                string comando =
                    @"BEGIN TRANSACTION;

                    CREATE TABLE IF NOT EXISTS orario(
                        Id integer PRIMARY KEY,
                        GiornoSettimana text,
                        IntervalloInizio integer,
                        IntervalloFine integer,
                        Link text);

                    COMMIT;
                    ";
                comandoInitTabelle.CommandText = comando;
                comandoInitTabelle.ExecuteNonQuery();
                database.Close();
            }catch(SQLiteException e)
            {
                return 1;
            }
            return 0;
        }

        public int aggiungiRiga(string giorno, int inizio, int fine, string link)
        {
            var comandoInserisci = database.CreateCommand();
            comandoInserisci.CommandText =
                "INSERT INTO orario(GiornoSettimana, IntervalloInizio, IntervalloFine, Link)VALUES($giorno, $inizio, $fine, $link);";
            comandoInserisci.Parameters.AddWithValue("$giorno", giorno);
            comandoInserisci.Parameters.AddWithValue("$inizio", inizio);
            comandoInserisci.Parameters.AddWithValue("$fine", fine);
            comandoInserisci.Parameters.AddWithValue("$link", link);
            try
            {
                database.Open();
                comandoInserisci.ExecuteNonQuery();
                database.Close();
            }catch(SQLiteException e)
            {
                return 1;
            }
            return 0;
        }

        public int rimuoviRiga(int id)
        {
            var comandoRimuovi = database.CreateCommand();
            comandoRimuovi.CommandText = "DELETE FROM orario WHERE Id = $id";
            comandoRimuovi.Parameters.AddWithValue("$id", id);
            try
            {
                database.Open();
                comandoRimuovi.ExecuteNonQuery();
                database.Close();
            }catch(SQLiteException e)
            {
                return 1;
            }
            return 0;
        }

        public DataTable getTabella()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Giorno", typeof(string)));
            dt.Columns.Add(new DataColumn("Ora Inizio", typeof(string)));
            dt.Columns.Add(new DataColumn("Ora Fine", typeof(string)));
            dt.Columns.Add(new DataColumn("Link", typeof(string)));
            try
            {
                SQLiteCommand cmd;
                database.Open();
                cmd = database.CreateCommand();
                cmd.CommandText = "SELECT * FROM orario;";
                DataRow dr;
                using(var leggi = cmd.ExecuteReader())
                {
                    while (leggi.Read())
                    {
                        dr = dt.NewRow();
                        dr[0] = leggi.GetInt32(0);
                        dr[1] = func.convertiGiorno(leggi.GetString(1), true);
                        dr[2] = func.secondiAdUmano(leggi.GetInt32(2));
                        dr[3] = func.secondiAdUmano(leggi.GetInt32(3));
                        dr[4] = leggi.GetString(4);
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (SQLiteException e)
            {
                //catch eccezione
            }
            database.Close();
            return dt;
        }
    
    }
}
