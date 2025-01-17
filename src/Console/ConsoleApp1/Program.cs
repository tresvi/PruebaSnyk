using System;
using System.IO;
using System.Net;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using ConsoleApp1.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            // Hardcoded credentials (CWE-798)
            string hardcodedPassword = "SuperSecret123";
            if (password == hardcodedPassword)
            {
                Console.WriteLine("Access granted!");
            }

            // SQL Injection (CWE-89)
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";
            using (SqlConnection conn = new SqlConnection("Server=myserver;Database=mydb;User Id=sa;Password=mypassword;")) // Hardcoded connection string
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
            }

            // Insecure cryptography (CWE-327)
            MD5 md5 = MD5.Create(); // Deprecated algorithm
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Insecure file handling (CWE-22 - Path Traversal)
            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();
            string filePath = "/logs/" + filename;
            string logData = File.ReadAllText(filePath); // No validation of user input
            Console.WriteLine(logData);

            // Unvalidated URL redirection (CWE-601)
            Console.WriteLine("Enter URL to redirect:");
            string url = Console.ReadLine();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.GetResponse();

            //Serializacion insegura
            Console.Write("Ingrese el archivo de usuario a cargar: ");
            string ruta = Console.ReadLine();

            /*using (FileStream fs = new FileStream(ruta, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Usuario usuario = (Usuario)formatter.Deserialize(fs); // 🚨 VULNERABILIDAD: Deserialización insegura
                Console.WriteLine($"Usuario cargado: {usuario.Nombre}");
            }*/


            // Uncontrolled Resource Consumption (CWE-400)
            while (true)
            {
                new Thread(() => Console.WriteLine("Thread running...")).Start(); // Spawns infinite threads
            }
        }
    }
}
