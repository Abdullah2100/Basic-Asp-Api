using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace FackData
{
    public class clsFackData
    {
        static string connectionUrl = clsConnectionUrl.connectionUrl["Configurations:urlConnection"];
        public static DataTable getFacks()
        {
            DataTable dtFacks = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = "select * from Facks";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtFacks.Load(reader);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtFacks;
        }

        public static bool findFack(int id, ref string name, ref string job, ref bool isDeleted)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = "select * from Facks where fackID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                name = (string)reader["name"];
                                job = (string)reader["job"];
                                isDeleted = (bool)reader["isDeleted"];
                                isFound = true;

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isFound;
        }

        public static int createFack(string name, string job)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = @"insert into Facks (name,job)
                                     values(@name,@job);
                                     select SCOPE_IDENTITY();    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@job", job);
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int resultID))
                        {
                            id = resultID;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        public static bool updateFack(int id, string name, string job, bool? isDeleted)
        {
            bool isUpdate = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = @"update Facks 
                                     set name=@name,job=@id,isDeleted=@isDeleted
                                     where fackID = @id;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        if (!string.IsNullOrEmpty(name))
                            cmd.Parameters.AddWithValue("@name", name);
                        if (!string.IsNullOrEmpty(job))
                            cmd.Parameters.AddWithValue("@job", job);
                        if (isDeleted != null)
                            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {

                            isUpdate = true; ;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdate;
        }
        public static bool delete(int id)
        {
            bool isDeleted = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = "delete from  Facks where fackID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isDeleted = true;

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isDeleted;
        }

        public static bool isFackExistById(int id)
        {
            bool isExist = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = "select found=1 from Facks where fackID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isExist = true;

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isExist;
        }

    }


}
