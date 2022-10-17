using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_3
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            Mail = string.Empty;
        }

        public static Usuario Traerusuario(string pNombreUsuario)
        {
            var usuario = new Usuario();

            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "MPS001\\SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection conection = new SqlConnection(cs))
            {
                var query = @"SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail
                               FROM Usuario
                              WHERE NombreUsuario = @nombreUsuario";

                conection.Open();

                using (SqlCommand cm = new SqlCommand(query, conection))
                {
                    cm.Parameters.Add(new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = pNombreUsuario });
                    var reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                    }
                }
                conection.Close();
            }
            return usuario;
        }

        public static Usuario InicioSesion(string pNombreUsuario,string pContrasena)
        {
            var usuario = new Usuario();

            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "MPS001\\SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection conection = new SqlConnection(cs))
            {
                var query = @"SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail
                               FROM Usuario
                              WHERE NombreUsuario = @nombreUsuario
                                AND Contraseña = @contrasena";

                conection.Open();

                using (SqlCommand cm = new SqlCommand(query, conection))
                {
                    cm.Parameters.Add(new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = pNombreUsuario });
                    cm.Parameters.Add(new SqlParameter("contrasena", SqlDbType.VarChar) { Value = pContrasena });
                    var reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                    }
                }
                conection.Close();
            }
            return usuario;
        }


    }
}
