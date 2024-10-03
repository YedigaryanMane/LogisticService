using ConsoleApp75.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Repositories
{
    class CarTypeRepository : IRepository<CarType>
    {

        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";
        List<CarType> carTypes = new List<CarType>();

        public void Add(CarType carType)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "insert into CarType values(@Id,@Model,@Price,@Coef)";
                    command.Parameters.Add(new SqlParameter("@Id", carType.Id));
                    command.Parameters.Add(new SqlParameter("@Model", carType.Model));
                    command.Parameters.Add(new SqlParameter("@Price", carType.Price));
                    command.Parameters.Add(new SqlParameter("@Coef", carType.Coef));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "Delete from CarType where id = @Id";
                    command.Parameters.Add(new SqlParameter("id", id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<CarType> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                List<CarType> cars = new List<CarType>();

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "select * from CarType ";

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarType car = new CarType();
                            car.Id = int.Parse(reader["@Id"].ToString());
                            car.Model = reader["@Model"].ToString();
                            car.Price = decimal.Parse(reader["@Price"].ToString());
                            car.Coef = float.Parse(reader["@Coef"].ToString());
                            cars.Add(car);
                        }
                    }
                }
                return cars;
            }
        }

        public CarType GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                CarType car = new CarType();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "select * from CarType where id = @Id ";
                    sqlCommand.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            car.Id = int.Parse(reader["@Id"].ToString());
                            car.Model = reader["@Model"].ToString();
                            car.Price = decimal.Parse(reader["@Price"].ToString());
                            car.Coef = float.Parse(reader["@Coef"].ToString());
                        }
                    }
                }
                return car;
            }
        }

        public void Update(CarType carType)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Update CarType set Id = @Id, Model = @Model,Price = @Price,Coef = @Coef";
                    cmd.Parameters.Add(new SqlParameter("@Id", carType.Id));
                    cmd.Parameters.Add(new SqlParameter("@Model", carType.Model));
                    cmd.Parameters.Add(new SqlParameter("@Price", carType.Price));
                    cmd.Parameters.Add(new SqlParameter("@Coef", carType.Coef));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
