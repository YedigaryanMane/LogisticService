using LogisticService.Menues;
using LogisticService.Models;
using LogisticService.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LogisticService.Repositories
{
    public class CrashedRepository : IRepository<Crashed, CrashedRequest>
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

                    command.CommandText = "insert into Crashed values(@IsCrashed,@Coef)";

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

        public Crashed Find(CrashedRequest request)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                Crashed crashed = new Crashed();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;

                    cmd.CommandText = "select * from Crashed where IsCrashed = @IsCrashed ";

                    cmd.Parameters.AddWithValue("@IsCrashed", request.IsCrashed);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            crashed.Coef = float.Parse(reader["Coef"].ToString());
                            crashed.Id = int.Parse(reader["Id"].ToString());
                            crashed.IsCrashed = bool.Parse(reader["IsCrashed"].ToString());
                        }
                    }
                }
                return crashed;
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

                    cmd.CommandText = "select * from Crashed";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Crashed crashed = new Crashed();

                            crashed.Id = int.Parse(reader["Id"].ToString());
                            crashed.Coef = float.Parse(reader["Coef"].ToString());
                            crashed.IsCrashed = bool.Parse(reader["IsCrashed"].ToString());

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

                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            crashed1.Coef = float.Parse(reader["Coef"].ToString());
                            crashed1.Id = int.Parse(reader["Id"].ToString());
                            crashed1.IsCrashed = bool.Parse(reader["IsCrashed"].ToString());
                        }
                    }
                }
                return crashed1;
            }
        }

        public void Update(Crashed crashed, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;

                    Console.WriteLine("Indicate which one you choose to modify");
                    Console.WriteLine("1.IsCrashed || 2.Coef || 3.All ");

                    int n;

                    Console.ReadLine().IsValid(out n);

                    if (n == 1)
                    {
                        cmd.CommandText = "Update Crashed set IsCrashed = @IsCrashed where id = @Id";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));
                        cmd.Parameters.Add(new SqlParameter("@IsCrashed", crashed.IsCrashed));
                    }
                    else if (n == 2)
                    {
                        cmd.CommandText = "Update Crashed set Coef = @Coef where id =@Id";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));
                        cmd.Parameters.Add(new SqlParameter("@Coef", crashed.Coef));
                    }
                    else if (n == 3)
                    {
                        cmd.CommandText = "Update Crashed set Coef = @Coef,IsCrashed = @IsCrashed where id = @Id ";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));
                        cmd.Parameters.Add(new SqlParameter("@IsCrashed", crashed.IsCrashed));
                        cmd.Parameters.Add(new SqlParameter("@Coef", crashed.Coef));
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
