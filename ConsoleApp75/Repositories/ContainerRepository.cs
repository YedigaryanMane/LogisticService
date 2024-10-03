using ConsoleApp75.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Repositories
{
    class ContainerRepository : IRepository<Container>
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
                    command.CommandText = "insert into Container values(@Id,@Coef,@IsClosed)";
                    command.Parameters.Add(new SqlParameter("@Id", container.Id));
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

        public List<Container> GetAll()
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                List<Container> container = new List<Container>();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select * from Container";

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Container container1 = new Container();
                            container1.Id = int.Parse(reader["@Id"].ToString());
                            container1.Coef = float.Parse(reader["@Coef"].ToString());
                            container1.IsClosed = bool.Parse(reader["@IsClosed"].ToString());

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
                            com.CommandText = "insert into Container values(@Id,@Coef,@IsClosed)";
                            container.Id = int.Parse(reader["@Id"].ToString());
                            container.Coef = float.Parse(reader["@Coef"].ToString());
                            container.IsClosed = bool.Parse(reader["@IsClosed"].ToString());

                        }
                    }
                }
                return container;
            }
        }

        public void Update(Container container)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Update Container set id = @Id,Coef = @Coef,IsClosed = @IsClosed where id = @Id";

                    com.Parameters.Add(new SqlParameter("@Id", container.Id));
                    com.Parameters.Add(new SqlParameter("@Coef", container.Coef));
                    com.Parameters.Add(new SqlParameter("@IsClosed", container.IsClosed));

                    com.ExecuteNonQuery();
                }
            }
        }
    }
}
