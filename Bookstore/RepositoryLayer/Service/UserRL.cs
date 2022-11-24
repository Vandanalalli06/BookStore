using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly string ConnectionString;
        public UserRL(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("BookStoresql");
        }
        public UserModel userRegistration(UserModel usermodel)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SpUserRegistration", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Fullname", usermodel.FullName);
                    command.Parameters.AddWithValue("@Email", usermodel.Email);
                    command.Parameters.AddWithValue("@Password", usermodel.Password);
                    command.Parameters.AddWithValue("@MobileNumber", usermodel.MobileNumber);
                    connection.Open();
                   var result = command.ExecuteNonQuery();
                    connection.Close();

                if (result != 0)
                    {
                        return usermodel;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
        }
    }
}
