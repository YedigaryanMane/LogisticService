using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Repositories
{
    public class DirectionRepository : IRepository<Direction>
    {
        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";
        List<Direction> directions = new List<Direction>();
        public void Add(Direction direction)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                List<Direction> directions = new List<Direction>();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "insert into Direction values(@To1 ,@From1,@Price,@Distance )";
                    command.Parameters.Add(new SqlParameter("@To1", direction.To));
                    command.Parameters.Add(new SqlParameter("@From1", direction.From));
                    command.Parameters.Add(new SqlParameter("@Price", direction.Price));
                    command.Parameters.Add(new SqlParameter("@Distance", direction.Distance));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "Delete from Direction where id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Direction direction)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Direction set Id = @Id,To1 =@To1,From1 = @From1,Price = @Price,Distance = @Distance";
                    command.Parameters.Add(new SqlParameter("@Id", direction.Id));
                    command.Parameters.Add(new SqlParameter("@To1", direction.To));
                    command.Parameters.Add(new SqlParameter("@From1", direction.From));
                    command.Parameters.Add(new SqlParameter("@Price", direction.Price));
                    command.Parameters.Add(new SqlParameter("@Distance", direction.Distance));

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Direction> GetAll()
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                List<Direction> list = new List<Direction>();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "select * from Direction";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Direction direction = new Direction();

                        while (reader.Read())
                        {
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.To = reader["To1"].ToString();
                            direction.From = reader["From1"].ToString();
                            direction.Price = decimal.Parse(reader["Price"].ToString());
                            direction.Distance = int.Parse(reader["Distance"].ToString());
                            list.Add(direction);
                        }
                    }
                }
                return list;
            }
        }

        public Direction GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                Direction direction = new Direction();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "select * from Direction where id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.To = reader["To1"].ToString();
                            direction.From = reader["From1"].ToString();
                            direction.Price = decimal.Parse(reader["Price"].ToString());
                            direction.Distance = int.Parse(reader["Distance"].ToString());
                        }
                    }
                }
                return direction;
            }
        }

        public Direction Find(Direction t1)
        {
            throw new NotImplementedException();
        }
    }
}
