using System;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Web;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class VulnerableCode
    {
        // Credenciales en texto plano (Hardcoded credentials)
        private static string connectionString = "Server=myServer;Database=myDB;User Id=admin;Password=1234;";

        public static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su usuario:");
            string userInput = Console.ReadLine();
/*
            // Inyección SQL
            string query = "SELECT * FROM Users WHERE Username = '" + userInput + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
*/
/*
            // Deserialización insegura
            Console.WriteLine("Ingrese datos serializados:");
            string serializedInput = Console.ReadLine();
            byte[] data = Convert.FromBase64String(serializedInput);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(data))
            {
                object obj = formatter.Deserialize(stream);
            }

            // Ejecución de comandos del sistema
            Console.WriteLine("Ingrese un comando para ejecutar:");
            string commandInput = Console.ReadLine();
            Process.Start(commandInput);

            // Cross-Site Scripting (XSS)
            HttpContext context = HttpContext.Current;
            string userQuery = context.Request.QueryString["q"];
            context.Response.Write("<html><body>" + userQuery + "</body></html>");

            // Uso de algoritmos criptográficos débiles
            Console.WriteLine("Ingrese un texto para cifrar:");
            string textToEncrypt = Console.ReadLine();
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(textToEncrypt));
            Console.WriteLine("Hash MD5: " + Convert.ToBase64String(hash));
*/
        }
    }
}
