using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Name.model;

namespace Name.Data
{
    public class InfoData
    {
        string _connectionString = "Data Source=DESKTOP-N5OCNK2\\SQLEXPRESS;Initial Catalog=NameDb;Integrated Security=True;";

        public List<Info> GetInfos()
        {
            List<Info> infos = new List<Info>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Name, Description FROM Recipes";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Info info = new Info
                    {
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    infos.Add(info);
                }
                connection.Close();
            }

            return infos;
        }

        public int AddInfo(Info info)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Infos (Name, Description) VALUES (@Name, @Description)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", info.Name);
                command.Parameters.AddWithValue("@Description", info.Description);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

        public int UpdateInfo(Info info)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Infos SET Description = @Description WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", info.Name);
                command.Parameters.AddWithValue("@Description", info.Description);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

        public int DeleteInfo(string infoName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Infos WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", infoName);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                return rowsAffected;
            }
        }

    }
}
