using APIAXMStore.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIAXMStore.Models
{
    public class Inventory
    {
        public int inventory_id { get; set; }
        public int product_id { get; set; }
        public int store_id { get; set; }
        public int quantity { get; set; }
        public DateTime date_create { get; set; }

        /**
         * Método que permite insertar un registro en la tabla inventario 
         */
        public static bool Registrar(Inventory inventory)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {

                string query = "insert into INVENTORY(product_id, store_id, quantity) values (" + inventory.product_id + ","+ inventory.store_id + "," + inventory.quantity +")";
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

        /**
         * Método que permite actualizar la cantidad de un producto 
         * que esta en una bodega y que se almacena como un registro
         * en la tabla inventario 
         */
        public static bool Modificar(Inventory inventor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                string query = "UPDATE INVENTORY SET quantity="+ inventor.quantity +
                    " WHERE product_id = "+ inventor.product_id +" and store_id=" + inventor.store_id;
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    int result= cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Respuesta> Validar(List<Inventory> list_inventory)
        {
            List<Respuesta> oListInventory = new List<Respuesta>();
            int acumulador = list_inventory[0].quantity;

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {

                string query = "SELECT * FROM INVENTORY WHERE product_id = " + list_inventory[0].product_id + " Order by date_create";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            int cantidadDB = Convert.ToInt32(dr["quantity"]);
                            if (acumulador > 0 && cantidadDB > 0)
                            {
                                oListInventory.Add(new Respuesta()
                                {
                                    product_id = Convert.ToInt32(dr["product_id"]),
                                    store_id = Convert.ToInt32(dr["store_id"]),
                                    quantity = Convert.ToInt32(dr["quantity"]),
                                    date_create = Convert.ToDateTime(dr["date_create"].ToString())


                                });
                                acumulador = acumulador - cantidadDB;

                            }
                            
                        }

                    }
                    return oListInventory;
                }
                catch (Exception ex)
                {
                    return oListInventory;
                }
            }

        }

    }

    public class Respuesta
    {
        public int product_id { get; set; }
        public int store_id { get; set; }
        public int quantity { get; set; }
        public DateTime date_create { get; set; }

    }
}