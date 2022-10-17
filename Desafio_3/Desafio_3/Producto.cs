using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_3
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public float Costo { get; set; }
        public float PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
            Id = 0; 
            Descripciones = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }

        public static List<Producto> TraerProductos(int pIdUsuario)
        {
            
            var listaProductos = new List<Producto>();


            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "MPS001\\SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection conection = new SqlConnection(cs))
            {
                var query = @"SELECT Id
                                     ,Descripciones
                                     ,Costo
                                     ,PrecioVenta
                                     ,Stock
                                     ,IdUsuario
                                FROM Producto
                               WHERE IdUsuario = @IdUsuario";

                conection.Open();

                using (SqlCommand cm = new SqlCommand(query, conection))
                {
                    cm.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = pIdUsuario });
                    var reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        var producto = new Producto();
                        producto.Id = Convert.ToInt32(reader.GetValue(0));
                        producto.Descripciones = reader.GetString(1);
                        producto.Costo = Convert.ToSingle(reader.GetValue(2));
                        producto.PrecioVenta = Convert.ToSingle(reader.GetValue(3));
                        producto.Stock = Convert.ToInt32(reader.GetValue(4));
                        producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                        listaProductos.Add(producto);
                    }
                }
                conection.Close();
            }
            return listaProductos;
        }



    }
}
