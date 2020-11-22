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
        private SQLiteConnection database;
        private Funzioni func = new Funzioni();
        private string percorsoDB;
        public GestoreDatabase(string percorsoalternativo = "", bool preinit = false)
        {
            string percorsoAppdata = func.getPercorsoAppdata();

            if(percorsoalternativo != "")
            {
                percorsoDB = Path.Combine(percorsoAppdata, percorsoalternativo);
            }
            else
            {
                percorsoDB = Path.Combine(percorsoAppdata, "orario.db");
            }

            if (preinit)
            {
                database = new SQLiteConnection("Data Source=" + percorsoDB);
            }
        }
        
        public string getPercorsoFileDatabase()
        {
            return percorsoDB;
        }

        public void forceClose()
        {
            database.Close();
            database.Dispose();
            SQLiteConnection.ClearAllPools();
        }

        public int initDatabase()
        {
            database = new SQLiteConnection("Data Source=" + percorsoDB);
            var check = database.CreateCommand();
            check.CommandText = "pragma quick_check";
            try
            {
                //codice di test database
                database.Open();
                check.ExecuteNonQuery();
                database.Close();
            }
            catch (SQLiteException)
            {
                var res = MessageBox.Show("File di database corrotto o non valido! Eliminare il database esistente per ricrearlo?",
                    "Errore Critico", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res == DialogResult.Yes)
                {
                    forceClose();
                    File.Delete(percorsoDB);
                    database = new SQLiteConnection("Data Source=" + percorsoDB);
                }
                else
                {
                    forceClose();
                    Environment.FailFast("Il file database non è valido!"); //termina immediatamente
                    //System.Windows.Forms.Application.Exit();
                }
            }

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
                        Materia text,
                        Link text);

                    CREATE TABLE IF NOT EXISTS materie(
                        Id integer PRIMARY KEY,
                        NomeMateria text,
                        NomeProf text);

                    COMMIT;
                    ";
                comandoInitTabelle.CommandText = comando;
                comandoInitTabelle.ExecuteNonQuery();
            }catch(SQLiteException)
            {
                database.Close();
                return 1;
            }
            database.Close();
            return 0;
        }

        public bool aggiungiRiga(string giorno, int inizio, int fine, string materia, string link)
        {
            var comandoInserisci = database.CreateCommand();
            comandoInserisci.CommandText =
                "INSERT INTO orario(GiornoSettimana, IntervalloInizio, IntervalloFine, Materia, Link)VALUES($giorno, $inizio, $fine, $materia, $link);";
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

        public DataTable getTabella()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Giorno", typeof(string)));
            dt.Columns.Add(new DataColumn("Ora Inizio", typeof(string)));
            dt.Columns.Add(new DataColumn("Ora Fine", typeof(string)));
            dt.Columns.Add(new DataColumn("Materia", typeof(string)));
            dt.Columns.Add(new DataColumn("Link", typeof(string)));
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT * FROM orario;";
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
                        dr[1] = func.convertiGiorno(leggi.GetString(1), true);
                        dr[2] = func.secondiAdUmano(leggi.GetInt32(2));
                        dr[3] = func.secondiAdUmano(leggi.GetInt32(3));
                        dr[4] = leggi.GetString(4);
                        dr[5] = leggi.GetString(5);
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (SQLiteException)
            {
                //catch eccezione
            }
            database.Close();
            return dt;
        }
        
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

        public List<string> getListaMaterieCombo()
        {
            List<string> listaMatCombo = new List<string>();
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT * FROM materie;";
            try
            {
                database.Open();
                string buf;
                using (var leggi = cmd.ExecuteReader())
                {
                    while (leggi.Read())
                    {
                        buf = leggi.GetString(1) + " (" + leggi.GetString(2) + ")";
                        listaMatCombo.Add(buf);
                    }
                }
            }
            catch (SQLiteException)
            {

            }
            database.Close();
            return listaMatCombo;
        }

        public string[] trovaLinkAttivo()
        {
            string[] buf;
            var cmd = database.CreateCommand();
            cmd.CommandText = "SELECT Materia, Link FROM orario WHERE GiornoSettimana = $giorno AND IntervalloInizio <= $ct AND IntervalloFine > $ct";
            string giorno = func.dtToDatabaseFormat(DateTime.Today.DayOfWeek);
            int ct = func.calcolaIntervalloSecondi(DateTime.Now.Hour, DateTime.Now.Minute);
            cmd.Parameters.AddWithValue("$giorno", giorno);
            cmd.Parameters.AddWithValue("$ct", ct);
            try
            {
                database.Open();
                var leggi = cmd.ExecuteReader();
                leggi.Read();
                try
                {
                    buf = new string[] {
                        leggi.GetString(0),
                        leggi.GetString(1)
                    };
                }
                catch(InvalidOperationException)
                {
                    buf = new string[] {null, null};
                }
            }
            catch (SQLiteException)
            {
                buf = new string[] {null, null};
            }
            database.Close();
            return buf;
        }
    }
}
