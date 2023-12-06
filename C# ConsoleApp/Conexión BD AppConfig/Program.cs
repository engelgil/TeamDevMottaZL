using System;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ConsoleAppConexionDbSetting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///*Utilizando autenticación: Usuario de Windows*/
                //using (SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCnAutentiWindows"].ConnectionString))

                /*Utilizando autenticación: Usuario de BD*/
                using (SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCnAutentiUserSql"].ConnectionString))
                {
                    // Abrimos la conexión
                    conexión.Open();

                    Console.WriteLine("Conexión abierta");
                    Console.WriteLine("Inicio\n\n");

                    SqlCommand cmd = conexión.CreateCommand();
                    cmd.CommandText = "SELECT @@VERSION, @@SERVERNAME, @@SERVICENAME";

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("SERVIDOR: " + reader.GetString(1));
                        Console.WriteLine("TIPO BD : " + reader.GetString(2));
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No pudimos abrir la conexión");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\nFin");
            Console.ReadLine();

        }
    }
}
