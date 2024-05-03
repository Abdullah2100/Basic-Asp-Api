using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace FackData
{
    public class clsFackData
    {
        static string connectionUrl = clsConnectionUrl.connectionUrl["Configurations:urlConnection"];
        public static async Task<DataTable> getFacks()
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
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
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
    }


}
