using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcDAO.Models
{
    public class PersonneDAO
    {
        String ittacours = ConfigurationManager.ConnectionStrings["ittacours"].ConnectionString;
        List<MyPersonne> peuple =new List<MyPersonne>();

        public List<MyPersonne> getPersonnes()
        {

            
            try
            {
                using (SqlConnection cnx = new SqlConnection(ittacours))
                {
                    
                    peuple.Clear();
                    
                    cnx.Open();
                    string sql = @"Select [Id], [Nom] ,[Prenom], [Salaire], [DateNaissance] from dbo.Personne";
                    SqlCommand command = new SqlCommand(sql, cnx);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MyPersonne p = new MyPersonne();
                        p.Id = (int)reader["Id"];
                        p.Nom = (String)reader["Nom"];
                        p.Prenom = (String)reader["Prenom"];
                        p.Salaire = reader["Salaire"] == null ? (float)reader["Salaire"] : 0;
                        p.DateNaissance = (DateTime?)(reader["DateNaissance"] == DBNull.Value ? null : reader["DateNaissance"]);
                        peuple.Add(p);
                    }
                    return peuple;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("select all pas potible", ex);
            }
        }

        public MyPersonne getPersonneById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(ittacours))
            {
                peuple.Clear();
                cnx.Open();
                string sql = @"Select [Id], [Nom] ,[Prenom], [Salaire], [DateNaissance] from dbo.Personne
                                where [Id] = @id";
                SqlCommand command = new SqlCommand(sql, cnx);
                SqlParameter sp = new SqlParameter("@id", id);
                command.Parameters.Add(sp);
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        MyPersonne p = new MyPersonne();
                        p.Id = (int)reader["Id"];
                        p.Nom = (String)reader["Nom"];
                        p.Prenom = (String)reader["Prenom"];
                        Object o = reader["Salaire"];
                        p.Salaire = (float)(o != DBNull.Value ? (decimal)o : 0);
                        p.DateNaissance = (DateTime?)(reader["DateNaissance"] == DBNull.Value ? null : reader["DateNaissance"]);

                        return p;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("get by ID pas potible", ex);
                }
                return null;
            }

        }

        public bool addOrUpdatePersonne(MyPersonne personne)
        {
            MyPersonne person;
            if ((person = getPersonneById(personne.Id)) == null)
            {
                try
                {

                    using (SqlConnection cnx = new SqlConnection(ittacours))
                    {
                        cnx.Open();
                        string sql = @"Insert dbo.Personne ([Nom] ,[Prenom], [Salaire], [DateNaissance])
                                       values ( @nom, @prenom, @salaire, @datenaissance)";
                        SqlCommand command = new SqlCommand(sql, cnx);
                        SqlParameter sp = new SqlParameter("@nom", personne.Nom);
                        SqlParameter sp1 = new SqlParameter("@prenom", personne.Prenom);
                        SqlParameter sp2 = new SqlParameter("@salaire", personne.Salaire);
                        sp2.DbType = System.Data.DbType.Double;

                        SqlParameter sp3 = new SqlParameter("@datenaissance", (object)personne.DateNaissance ?? DBNull.Value);
                        command.Parameters.Add(sp);
                        command.Parameters.Add(sp1);
                        command.Parameters.Add(sp2);
                        command.Parameters.Add(sp3);
                        return command.ExecuteNonQuery() == 1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("add pas potible", ex);
                }
            }
            else
            {
                return Update(personne);
            }



        }

        public bool Update(MyPersonne personne)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ittacours))
                {
                    cnx.Open();
                    string sql = @"update dbo.Personne
                        set nom= @nom, prenom= @prenom, salaire= @salaire, datenaissance= @datenaissance
                        where id=@id";
                    SqlCommand command = new SqlCommand(sql, cnx);
                    SqlParameter sp = new SqlParameter("@nom", personne.Nom);
                    SqlParameter sp1 = new SqlParameter("@prenom", personne.Prenom);
                    SqlParameter sp2 = new SqlParameter("@salaire", personne.Salaire);
                    sp2.DbType = System.Data.DbType.Double;
                    SqlParameter sp3 = new SqlParameter("@datenaissance", (object)personne.DateNaissance ?? DBNull.Value);
                    sp3.DbType = System.Data.DbType.DateTime2;
                    SqlParameter sp4 = new SqlParameter("@id", personne.Id);
                    command.Parameters.Add(sp);
                    command.Parameters.Add(sp1);
                    command.Parameters.Add(sp2);
                    command.Parameters.Add(sp3);
                    command.Parameters.Add(sp4);
                    return command.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("update pas potible", ex);
            }
        }

        public bool deletePersonne(int id)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ittacours))
                {
                    cnx.Open();
                    string sql = @"delete dbo.Personne where id=@id";
                    SqlCommand command = new SqlCommand(sql, cnx);
                    SqlParameter sp = new SqlParameter("@id", id);

                    command.Parameters.Add(sp);
                    return command.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("delete pas potible", ex);
            }

        }


    }
}