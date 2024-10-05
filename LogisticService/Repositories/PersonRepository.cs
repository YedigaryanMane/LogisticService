using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Repositories
{
    class PersonRepository : IRepository<Person>
    {
        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog=PersonDataDb;Integrated Security=True;Encrypt=False";

        public void Add(Person person)
        {
            using(SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using(SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "insert into Person values(@Id,@Email,@PhoneNumber,@ԼeadTime)";
                    com.Parameters.Add(new SqlParameter("@Id", person.Id));
                    com.Parameters.Add(new SqlParameter("@Email",person.Email));
                    com.Parameters.Add(new SqlParameter("@PhoneNumber",person.PhoneNumber));
                    com.Parameters.Add(new SqlParameter("@ԼeadTime",person.ԼeadTime));

                    com.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
           using(SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
               con.Open(); 

                using(SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Delete from Person where @Id = id";
                    com.Parameters.Add(new SqlParameter("@Id", id));

                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Person> GetAll()
        {
            using(SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                List<Person> list = new List<Person>();
                using (SqlCommand  com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select * from Person";
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person p = new Person();
                            p.Id = int.Parse(reader["@Id"].ToString());
                            p.Email = reader["@Email"].ToString();
                            p.PhoneNumber = reader["@PhoneNumber"].ToString();
                            p.ԼeadTime = reader["@LeadTime"].ToString();
                            list.Add(p);
                        }
                    }
                }
                return list;
            }           
        }

        public Person GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                Person person = new Person();
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;

                    com.CommandText = "Select * from Person where  id = @Id";
                    com.Parameters.Add(new SqlParameter("@Id",id));
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            person.Id = int.Parse(reader["@Id"].ToString());
                            person.Email = reader["@Email"].ToString();
                            person.PhoneNumber = reader["@PhoneNumber"].ToString();
                            person.ԼeadTime = reader["@LeadTime"].ToString();                         
                        }
                    }
                }
                return person;
            }
        }

        public void Update(Person person)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "update Person set @Id = Id,@Email = Email,@PhoneNumber = PhoneNumber,@ԼeadTime = LeadTime";
                    com.Parameters.Add(new SqlParameter("@Id", person.Id));
                    com.Parameters.Add(new SqlParameter("@Email", person.Email));
                    com.Parameters.Add(new SqlParameter("@PhoneNumber", person.PhoneNumber));
                    com.Parameters.Add(new SqlParameter("@ԼeadTime", person.ԼeadTime));

                    com.ExecuteNonQuery();
                }
            }
        }
    }
}
