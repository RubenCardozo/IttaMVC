using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcDAO.Models
{
    public static class PersonneDaoDisco
    {
        static DataSet personnesDS = new DataSet("personnes");
        static SqlDataAdapter adapter;
        static PersonneDaoDisco()
        {
            String sql = "Select [Id], [Nom] ,[Prenom], [Salaire], [DateNaissance] from dbo.Personne";

            //String ittacours = ConfigurationManager.ConnectionStrings["ittacours"].ConnectionString;

            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["ittacours"].ConnectionString);
            adapter = new SqlDataAdapter(sql, cnx);
            adapter.Fill(personnesDS, "Personne");

            personnesDS.Tables["Personne"].PrimaryKey = new[] { personnesDS.Tables["Personne"].Columns["Id"] };
            
            new SqlCommandBuilder(adapter);
        }


        public static List<Personne> getPersonnes()
        {

            List<Personne> peuple = new List<Personne>();
            foreach (DataRow row in personnesDS.Tables["Personne"].Rows)
            {
                Personne p = new Personne();
                p.Id = (int)row["Id"];
                p.Nom = (String)row["Nom"];
                p.Prenom = (String)row["Prenom"];
                p.Salaire = row["Salaire"] != DBNull.Value ? (float)(decimal)row["Salaire"] : 0;
                p.DateNaissance = (DateTime?)(row["DateNaissance"] == DBNull.Value ? null : row["DateNaissance"]);
                peuple.Add(p);
            }
            return peuple;
        }


        public static Personne getPersonneById(int id)
        {
            DataRow row = personnesDS.Tables["Personne"].Rows.Find(id);
            Personne p = new Personne();
            p.Id = (int)row["Id"];
            p.Nom = (String)row["Nom"];
            p.Prenom = (String)row["Prenom"];
            p.Salaire = row["Salaire"] != DBNull.Value ? (float)(decimal)row["Salaire"] : 0;
            p.DateNaissance = (DateTime?)(row["DateNaissance"] == DBNull.Value ? null : row["DateNaissance"]);
            return p;
        }


        public static bool addOrUpdatePersonne(Personne personne)
        {

            DataRow row = personnesDS.Tables["Personne"].Rows.Find(personne.Id);

            if (row == null)
            {
                DataRow newrow = personnesDS.Tables["Personne"].NewRow();
                LoadPersonnelFromRow(personne, newrow);
                personnesDS.Tables["Personne"].Rows.Add(newrow);

                bool b = adapter.Update(personnesDS.Tables["Personne"]) == 1;
                if (b)
                {
                    personnesDS.Tables["Personne"].Clear();
                    adapter.Fill(personnesDS, "Personne");
                }


                return b;

            }
            else
            {
                return Update(personne, row);
            }
        }


        public static bool Update(Personne personne, DataRow row = null)
        {
            if (row == null)
            {
                row = personnesDS.Tables["Personne"].Rows.Find(personne.Id);
            }

            LoadPersonnelFromRow(personne, row);

            return adapter.Update(personnesDS.Tables["Personne"]) == 1;
        }



        public static bool deletePersonne(int id)
        {
            DataRow row = personnesDS.Tables["Personne"].Rows.Find(id);
            row.Delete();
            personnesDS.AcceptChanges();
            return adapter.Update(personnesDS.Tables["Personne"]) == 1;
        }



        private static void LoadPersonnelFromRow(Personne personne, DataRow row)
        {
            row["Id"]=personne.Id;
            row["Nom"] = personne.Nom;
            row["Prenom"] = personne.Prenom;
            row["Salaire"] = personne.Salaire;
            row["DateNaissance"] = (object)personne.DateNaissance ?? DBNull.Value;
        }
    }
}