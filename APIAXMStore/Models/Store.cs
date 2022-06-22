using APIAXMStore.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIAXMStore.Models
{
    public class Store
    {
        public int store_id { get; set; }
        public string name { get; set; }

        public static bool Registrar(Store store)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                string query = "insert into STORE(name) values('"+ store.name + "')";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

    }
}