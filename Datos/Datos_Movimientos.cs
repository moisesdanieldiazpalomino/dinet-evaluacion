using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public static class Datos_Movimientos
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public static bool RegistrarMovimiento(Movimiento objMovimiento)
        {
            bool resultado = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_REGISTRAR_MOVIMIENTOS", connection))
                    {
                        cmd.Parameters.AddWithValue("@codCia", objMovimiento.codCia);
                        cmd.Parameters.AddWithValue("@companiaVenta", objMovimiento.companiaVenta);
                        cmd.Parameters.AddWithValue("@almacenVenta", objMovimiento.almacenVenta);
                        cmd.Parameters.AddWithValue("@tipoMovimiento", objMovimiento.tipoMovimiento);
                        cmd.Parameters.AddWithValue("@tipoDocumento", objMovimiento.tipoDocumento);
                        cmd.Parameters.AddWithValue("@nroDocumento", objMovimiento.nroDocumento);
                        cmd.Parameters.AddWithValue("@codItem", objMovimiento.codItem);
                        cmd.Parameters.AddWithValue("@proveedor", objMovimiento.proveedor);
                        cmd.Parameters.AddWithValue("@almacenDestino", objMovimiento.almacendestino);
                        cmd.Parameters.AddWithValue("@cantidad", objMovimiento.cantidad);
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                            resultado = true;
                    }
                }

                return resultado;

            }
            catch(Exception ex)
            {
                return resultado;
            }

            
        }

        public static List<Movimiento> Buscar(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string numeroDocumento )
        {
            List<Movimiento> movimientos = new List<Movimiento>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("USP_BUSQUEDA_INVENTARIO", connection))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", (object)fechaInicio??DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechafin", (object)fechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoMovimiento", (object)tipoMovimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@numeroDocumento", (object)numeroDocumento ?? DBNull.Value);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();


                    using(SqlDataReader reader= cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Movimiento movimiento = new Movimiento
                            {
                                codCia = reader["COD_CIA"].ToString(),
                                companiaVenta = reader["COMPANIA_VENTA_3"].ToString(),
                                almacenVenta = reader["ALMACEN_VENTA"].ToString(),
                                tipoMovimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                                tipoDocumento = reader["TIPO_DOCUMENTO"].ToString(),
                                nroDocumento = reader["NRO_DOCUMENTO"].ToString(),
                                codItem = reader["COD_ITEM_2"].ToString(),
                                proveedor = reader["PROVEEDOR"].ToString(),
                                almacendestino = reader["ALMACEN_DESTINO"].ToString(),
                                cantidad = reader["CANTIDAD"].ToString(),
                                fechaTransaccion = Convert.ToDateTime(reader["FECHA_TRANSACCION"].ToString()),

                            };

                            movimientos.Add(movimiento);


                        }
                    }
                }
            }

            return movimientos;


        }
        
    }
}
