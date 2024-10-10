using LogisticService.Menues;
using LogisticService.Models;
using LogisticService.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LogisticService.Repositories
{
    public class ContainerRepository : IRepository<Container, ContainerRequest>
    {
        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";

        List<Container> containerList = new List<Container>();
        public void Add(Container container)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "insert into Container values(@Coef,@IsClosed)";

                    command.Parameters.Add(new SqlParameter("@Coef", container.Coef));
                    command.Parameters.Add(new SqlParameter("@IsClosed", container.IsClosed));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;

                    cmd.CommandText = "Delete from  Container where id = @id ";

                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Container Find(ContainerRequest request)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                Container container = new Container();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;

                    com.CommandText = "Select * from Container where IsClosed = @IsClosed";

                    com.Parameters.AddWithValue("@IsClosed", request.IsClosed);

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.Coef = float.Parse(reader["Coef"].ToString());
                            container.IsClosed = bool.Parse(reader["IsClosed"].ToString());
                        }
                    }
                }
                return container;
            }
        }

        public List<Container> GetAll()
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                List<Container> container = new List<Container>();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;

                    com.CommandText = "select * from Container";

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Container container1 = new Container();

                            container1.Id = int.Parse(reader["Id"].ToString());
                            container1.Coef = float.Parse(reader["Coef"].ToString());
                            container1.IsClosed = bool.Parse(reader["IsClosed"].ToString());

                            container.Add(container1);
                        }
                    }
                }
                return container;
            }
        }

        public Container GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                Container container = new Container();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;

                    com.CommandText = "Select *from Container where id = @Id";

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.Coef = float.Parse(reader["Coef"].ToString());
                            container.IsClosed = bool.Parse(reader["IsClosed"].ToString());

                        }
                    }
                }
                return container;
            }
        }

        public void Update(Container container, int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;

                    Console.WriteLine("Indicate which one you choose to modify");
                    Console.WriteLine("1.IsClosed || 2.Coef || 3.All ");

                    int n;

                    Console.ReadLine().IsValid(out n);

                    if (n == 1)
                    {
                        com.CommandText = "Update Container set IsClosed = @IsClosed where id = @Id";

                        com.Parameters.Add(new SqlParameter("@Id", id));
                        com.Parameters.Add(new SqlParameter("@IsClosed", container.IsClosed));

                    }
                    else if (n == 2)
                    {
                        com.CommandText = "Update Container set Coef = @Coef where id  = @Id";

                        com.Parameters.Add(new SqlParameter("@Id", id));
                        com.Parameters.Add(new SqlParameter("@Coef", container.Coef));
                    }
                    else if (n == 3)
                    {
                        com.CommandText = "Update Container set Coef = @Coef,IsClosed = @IsClosed where id = @Id";

                        com.Parameters.Add(new SqlParameter("@Id", id));
                        com.Parameters.Add(new SqlParameter("@Coef", container.Coef));
                        com.Parameters.Add(new SqlParameter("@IsClosed", container.IsClosed));
                    }

                    com.ExecuteNonQuery();
                }
            }
        }
    }
}
