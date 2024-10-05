using ConsoleApp75.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Repositories
{
    class CrashedRepository : IRepository<Crashed>
    {

        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";

        public void Add(Crashed crashed)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "insert onto Crashed vsalues(@Coef,@IsCrashed)";
                    command.Parameters.Add(new SqlParameter("@IsCrashed", crashed.IsCrashed));
                    command.Parameters.Add(new SqlParameter("@Coef", crashed.Coef));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from Crashed where id = @Id";
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Crashed> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                List<Crashed> crasheds = new List<Crashed>();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from mCrashed";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Crashed crashed = new Crashed();
                            crashed.Coef = float.Parse(reader["@Coef"].ToString());
                            crashed.Id = int.Parse(reader["@Id"].ToString());
                            crashed.IsCrashed = bool.Parse(reader["@IsCrashed"].ToString());

                            crasheds.Add(crashed);
                        }
                    }
                }
                return crasheds;
            }
        }

        public Crashed GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                Crashed crashed1 = new Crashed();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from mCrashed where id = @Id";
                    cmd.Parameters.Add(new SqlParameter("@Id",id));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            crashed1.Coef = float.Parse(reader["@Coef"].ToString());
                            crashed1.Id = int.Parse(reader["@Id"].ToString());
                            crashed1.IsCrashed = bool.Parse(reader["@IsCrashed"].ToString());
                        }
                    }
                }
                return crashed1;
            }
        }

        public void Update(Crashed crashed)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Update Crashed set Id = @Id,Coef = @Coef,IsCrashed = @IsCrashed ";
                    cmd.Parameters.Add(new SqlParameter("@Id", crashed.Id));
                    cmd.Parameters.Add(new SqlParameter("@IsCrashed", crashed.IsCrashed));
                    cmd.Parameters.Add(new SqlParameter("@Coef", crashed.Coef));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
