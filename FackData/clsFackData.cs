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

                    string query = @"select fackID,name,job ,
                                     case when image is null then ' ' else image end as image,
                                      isDeleted
                                     from Facks";
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
                Console.WriteLine("Error is : " + ex.Message);
            }
            return dtFacks;
        }

        public static bool findFack(int id, ref string name, ref string job, ref bool isDeleted, ref string image)
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
                                if (reader["image"] != DBNull.Value)
                                    image = (string)reader["image"];
                                isFound = true;

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isFound;
        }

        public static int createFack(string name, string job, string image)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = @"insert into Facks (name,job,image)
                                     values(@name,@job,@image);
                                     select SCOPE_IDENTITY();    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@job", job);
                        if (!string.IsNullOrEmpty(image))
                            cmd.Parameters.AddWithValue("@image", image);
                        else
                            cmd.Parameters.AddWithValue("@image", DBNull.Value);
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
                Console.WriteLine("Error is : " + ex.Message);
            }
            return id;
        }
        public static bool updateFack(int id, string name, string job, bool? isDeleted, string image)
        {
            bool isUpdate = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();

                    string query = @"update Facks 
                                     set name = @name,
                                     job = @id,
                                     isDeleted = @isDeleted,
                                     image = @image
                                     where fackID = @id;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        if (!string.IsNullOrEmpty(name))
                            cmd.Parameters.AddWithValue("@name", name);
                        else
                            cmd.Parameters.AddWithValue("@name", DBNull.Value);

                        if (!string.IsNullOrEmpty(job))
                            cmd.Parameters.AddWithValue("@job", job);
                        else
                            cmd.Parameters.AddWithValue("@job", DBNull.Value);

                        if (isDeleted != null)
                            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
                        else
                            cmd.Parameters.AddWithValue("@isDeleted", DBNull.Value);

                        if (!string.IsNullOrEmpty(image))
                            cmd.Parameters.AddWithValue("@image", image);
                        else
                            cmd.Parameters.AddWithValue("@image", DBNull.Value);
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
                Console.WriteLine("Error is : " + ex.Message);
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
                Console.WriteLine("Error is : " + ex.Message);
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
