﻿using LogisticService.Menues;
using LogisticService.Models;
using LogisticService.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LogisticService.Repositories
{
    public class CarTypeRepository : IRepository<CarType, CarTypeRequest>
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

                    command.CommandText = "insert into CarType values(@Model,@Coef)";

                    command.Parameters.Add(new SqlParameter("@Model", carType.Model));
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

                    command.Parameters.Add(new SqlParameter("@Id", id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public CarType Find(CarTypeRequest request)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                CarType car = new CarType();

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;

                    sqlCommand.CommandText = "select * from CarType where Model = @Model";

                    sqlCommand.Parameters.AddWithValue("@Model", request.Type);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            car.Id = int.Parse(reader["Id"].ToString());
                            car.Model = reader["Model"].ToString();
                            car.Coef = float.Parse(reader["Coef"].ToString());
                        }
                    }
                }
                return car;
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

                            car.Id = int.Parse(reader["Id"].ToString());
                            car.Model = reader["Model"].ToString();
                            car.Coef = float.Parse(reader["Coef"].ToString());

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
                            car.Id = int.Parse(reader["Id"].ToString());
                            car.Model = reader["Model"].ToString();
                            car.Coef = float.Parse(reader["Coef"].ToString());
                        }
                    }
                }
                return car;
            }
        }

        public void Update(CarType carType, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;

                    Console.WriteLine("Indicate which one you choose to modify");
                    Console.WriteLine("1.Model || 2.Coef || 3.All ");

                    int n;

                    Console.ReadLine().IsValid(out n);

                    if (n == 1)
                    {

                        cmd.CommandText = "Update CarType set Model = @Model where id = @Id";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        cmd.Parameters.Add(new SqlParameter("@Model", carType.Model));

                    }
                    else if (n == 2)
                    {
                        cmd.CommandText = "Update CarType set Coef = @Coef where id  = @Id";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        cmd.Parameters.Add(new SqlParameter("@Coef", carType.Coef));
                    }
                    else if (n == 3)
                    {
                        cmd.CommandText = "Update CarType set  Model = @Model,Price = @Price,Coef = @Coef where id = @Id";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));
                        cmd.Parameters.Add(new SqlParameter("@Model", carType.Model));
                        cmd.Parameters.Add(new SqlParameter("@Coef", carType.Coef));
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
