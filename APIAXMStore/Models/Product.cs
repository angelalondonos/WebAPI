using APIAXMStore.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIAXMStore.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        
        public static bool Registrar(Product product)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                string query = "insert into PRODUCT(code, name) values ('"+ product.code +"', '" + product.name +"')";
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