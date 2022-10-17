using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_3
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }


        public static List<Venta> TraerVentas(int pIdUsuario)
        {

            var listaVentas = new List<Venta>();

            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "MPS001\\SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection conection = new SqlConnection(cs))
            {
                var query = @"SELECT Id
                                     ,Comentarios
                                     ,IdUsuario
                                FROM Venta
                               WHERE IdUsuario = @IdUsuario";

                conection.Open();

                using (SqlCommand cm = new SqlCommand(query, conection))
                {
                    cm.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = pIdUsuario });
                    var reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        var venta = new Venta();
                        venta.Id = Convert.ToInt32(reader.GetValue(0));
                        venta.Comentarios = reader.GetString(1);
                        venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                        listaVentas.Add(venta);
                    }
                }
                conection.Close();
            }
            return listaVentas;
        }



    }
}
