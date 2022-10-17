using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_3
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }

        public static List<Producto> TraerProductosVendidos(int pIdUsuario)
        {

            var listaProductosVendidos = new List<Producto>();

            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "MPS001\\SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;



            var listaProductos = new List<Producto>();

            listaProductos = Producto.TraerProductos(1);


            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection conection = new SqlConnection(cs))
            {



                var query = @"SELECT pv.Id
                                     ,pv.Stock
                                     ,pv.IdProducto
                                     ,pv.IdVenta
                                     ,v.IdUsuario
                                FROM ProductoVendido pv
                                JOIN Venta v ON v.id = pv.IdVenta
                               WHERE v.IdUsuario = @IdUsuario
                                 AND pv.IdProducto = @IdProducto";

                conection.Open();

                foreach (var item in listaProductos)
                {
                    using (SqlCommand cm = new SqlCommand(query, conection))
                    {
                        cm.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = item.IdUsuario });
                        cm.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = item.Id });
                        var reader = cm.ExecuteReader();
                        while (reader.Read())
                        {
                            if (item.Id == Convert.ToInt32(reader.GetValue(2)) &&  item.IdUsuario == Convert.ToInt32(reader.GetValue(4)))
                            {
                               listaProductosVendidos.Add(item);
                            }
                            
                        }
                        reader.Close();
                    }
                }

                conection.Close();
            }
            return listaProductosVendidos;
        }



    }
}
