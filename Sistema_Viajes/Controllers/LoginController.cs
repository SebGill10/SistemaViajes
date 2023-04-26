using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Sistema_Viajes.Models;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_Viajes.Controllers
{
    public class LoginController : Controller
    {
        static string conexion = "Server=localhost;Database=SistemaDeViajes; Trusted_Connection=true;MultipleActiveResultSets=true";

		public object Session { get; private set; }

		// GET: Acceso
		public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View(); 
        }

		[HttpPost]
		public ActionResult Login(Usuario usuario)
		{
			usuario.Password = ConvertirSha256(usuario.Password);

			using (SqlConnection con = new SqlConnection(conexion))
			{

				SqlCommand sqlCommand = new SqlCommand("Validar_Usuario", con);
				sqlCommand.Parameters.AddWithValue("Correo", usuario.Correo);
				sqlCommand.Parameters.AddWithValue("Password", usuario.Password);
				sqlCommand.CommandType = CommandType.StoredProcedure;

				con.Open();

				usuario.IdUsuario = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());

			}

			if (usuario.IdUsuario != 0)
			{
				Session = conexion;
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewData["Mensaje"] = "usuario no encontrado";
				return View();
			}


		}

		public static string ConvertirSha256(string texto)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(texto));

                foreach (byte b in result) 
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

    }
}
