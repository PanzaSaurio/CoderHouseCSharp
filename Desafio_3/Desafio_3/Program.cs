using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Desafio_3
{
    class Program
    {
        static void Main(String[] args)
        {

            var usuario = new Usuario();
            var usuarioLogin = new Usuario();
            var usuarioLoginVacio = new Usuario();
            var listaProductos = new List<Producto>();
            var listaVentas = new List<Venta>();
            var listaProductosVendidos = new List<Producto>();


            Console.WriteLine("\r\n###################################################################################################################");
            Console.WriteLine(@"Punto A: Traer Usuario:  Recibe como parámetro un nombre del usuario, 
                         buscarlo en la base de datos y devolver el objeto con todos 
                         sus datos (Esto se hará para la página en la que se mostrara los datos del 
                         usuario y en la página para modificar sus datos).");
            Console.WriteLine("####################################################################################################################\r\n");

            usuario = Usuario.Traerusuario("eperez");

            Console.WriteLine("Usuario Id: " + usuario.Id);
            Console.WriteLine("Nombre: " + usuario.Nombre);
            Console.WriteLine("Apellido: " + usuario.Apellido);
            Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario);
            Console.WriteLine("Contraseña: " + usuario.Contraseña);
            Console.WriteLine("Mail: " + usuario.Mail);


            Console.WriteLine("\r\n###################################################################################################################");
            Console.WriteLine(@"Punto B: Traer Producto: Recibe un número de IdUsuario como parámetro, debe traer 
                         todos los productos cargados en la base de este usuario en particular..");
            Console.WriteLine("####################################################################################################################\r\n");

            listaProductos = Producto.TraerProductos(1);

            foreach (var item in listaProductos)
            {
                Console.WriteLine("Producto Id: " + item.Id);
                Console.WriteLine("Descripciones: " + item.Descripciones);
                Console.WriteLine("Costo: " + item.Costo);
                Console.WriteLine("Precio de Venta: " + item.PrecioVenta);
                Console.WriteLine("Stock: " + item.Stock);
                Console.WriteLine("Usuario Id: " + item.IdUsuario);
                Console.WriteLine("====================================================\r\n");

            }

            Console.WriteLine("\r\n###################################################################################################################");
            Console.WriteLine(@"Punto C: Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario, cuya información está en su 
                         producto (Utilizar dentro de esta función el ""Traer Productos"" anteriormente hecho 
                         para saber que productosVendidos ir a buscar).");
            Console.WriteLine("####################################################################################################################\r\n");

            listaProductosVendidos = ProductoVendido.TraerProductosVendidos(1);

            foreach (var item in listaProductosVendidos)
            {
                Console.WriteLine("Producto Id: " + item.Id);
                Console.WriteLine("Descripciones: " + item.Descripciones);
                Console.WriteLine("Costo: " + item.Costo);
                Console.WriteLine("Precio de Venta: " + item.PrecioVenta);
                Console.WriteLine("Stock: " + item.Stock);
                Console.WriteLine("Usuario Id: " + item.IdUsuario);
                Console.WriteLine("====================================================\r\n");
            }

            Console.WriteLine("\r\n###################################################################################################################");
            Console.WriteLine(@"Punto D: Traer Ventas: Recibe como parámetro un IdUsuario, debe traer todas las ventas de la base asignados al usuario particular.");
            Console.WriteLine("####################################################################################################################\r\n");


            listaVentas = Venta.TraerVentas(1);

            foreach (var item in listaVentas)
            {
                Console.WriteLine("Venta Id: " + item.Id);
                Console.WriteLine("Comentarios: " + item.Comentarios);
                Console.WriteLine("Id Usuario: " + item.IdUsuario);
                Console.WriteLine("====================================================\r\n");
            }

            Console.WriteLine("\r\n###################################################################################################################");
            Console.WriteLine(@"Punto E: Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña, buscar en la base de 
                           datos si el usuario existe y si coincide con la contraseña lo devuelve (el objeto Usuario), 
                           caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0). ");
            Console.WriteLine("####################################################################################################################\r\n");



            Console.WriteLine("====================================================");
            Console.WriteLine("========= Usuario y Contraseña correctos ===========");
            Console.WriteLine("====================================================");

            usuarioLogin = Usuario.InicioSesion("tcasazza", "SoyTobiasCasazza");

            Console.WriteLine("Usuario Id: " + usuarioLogin.Id);
            Console.WriteLine("Nombre: " + usuarioLogin.Nombre);
            Console.WriteLine("Apellido: " + usuarioLogin.Apellido);
            Console.WriteLine("Nombre de Usuario: " + usuarioLogin.NombreUsuario);
            Console.WriteLine("Contraseña: " + usuarioLogin.Contraseña);
            Console.WriteLine("Mail: " + usuarioLogin.Mail);

            Console.WriteLine("\r\n====================================================");
            Console.WriteLine("========= Usuario y Contraseña incorrectos==========");
            Console.WriteLine("====================================================");

            usuarioLoginVacio = Usuario.InicioSesion("Admin", "Admin1234");

            Console.WriteLine("Usuario Id: " + usuarioLoginVacio.Id);
            Console.WriteLine("Nombre: " + usuarioLoginVacio.Nombre);
            Console.WriteLine("Apellido: " + usuarioLoginVacio.Apellido);
            Console.WriteLine("Nombre de Usuario: " + usuarioLoginVacio.NombreUsuario);
            Console.WriteLine("Contraseña: " + usuarioLoginVacio.Contraseña);
            Console.WriteLine("Mail: " + usuarioLoginVacio.Mail);


        }
    }
}
