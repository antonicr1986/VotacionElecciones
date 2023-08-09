﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VotoElectronico
{
    class VotanteDAL
    {
        public static void CrearTabla(SqlConnection Conn)
        {
            if (!ComprobarExistenciaTabla(Conn))
            {
                using (Conn = BDComun.ObtenerConexion())
                {
                    string createTableQuery = @"
                    CREATE TABLE VotosElecciones (
                        Partido varchar(20),
                        Votos int
                    )";

                    using (SqlCommand command = new SqlCommand(createTableQuery, Conn))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tabla VotosElecciones creada exitosamente.");
                    }
                }
            }        
        }

        public static bool ComprobarExistenciaTabla(SqlConnection Conn)
        {
            string tableName = "VotosElecciones";

            using (Conn = BDComun.ObtenerConexion())
            {
                string checkTableQuery = @"
                    SELECT COUNT(*)
                    FROM INFORMATION_SCHEMA.TABLES
                    WHERE TABLE_NAME = @TableName";

                using (SqlCommand command = new SqlCommand(checkTableQuery, Conn))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        Console.WriteLine($"La tabla {tableName} existe en la base de datos.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"La tabla {tableName} no existe en la base de datos.");
                        return false;
                    }
                }
            }
        }

        public static int Agregar(Votante votante)
        {
            int retorno = 0;
            using (SqlConnection Conn = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("insert into Votos (Nombre, Apellidos, Edad) values ('{0}','{1}','{2}')",
                    votante.Nombre, votante.Apellidos, votante.Edad), Conn);

                retorno = Comando.ExecuteNonQuery();

                return retorno;
            }
        }

        public static void GuardarVotos(Dictionary<string, int> votosPorPartido)
        {
            using (SqlConnection connection = BDComun.ObtenerConexion())
            {
                foreach (var kvp in votosPorPartido)
                {
                    string partido = kvp.Key;
                    int votos = kvp.Value;

                    string updateQuery = $"UPDATE VotosElecciones SET Votos = {votos} WHERE Partido = '{partido}'";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        int rowsUpdated = updateCommand.ExecuteNonQuery();
                        if (rowsUpdated == 0)
                        {
                            string insertQuery = $"INSERT INTO VotosElecciones (Partido, Votos) VALUES ('{partido}', {votos})";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        public static void CargarVotos()
        {
            Dictionary<string, int> votosPorPartido = new Dictionary<string, int>();

            using (SqlConnection connection = BDComun.ObtenerConexion())
            {
                string query = "SELECT Partido, Votos FROM VotosElecciones";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();

                    SqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    while (reader.Read()&& votosPorPartido.Count>i)
                    {
                        string partido = reader["Partido"].ToString();
                        int votos = Convert.ToInt32(reader["Votos"]);

                        votosPorPartido[partido] = votos;
                        i++;
                    }

                    reader.Close();
                }
            }
            // Ahora tienes los datos en el diccionario votosPorPartido
            GuardarVotos(votosPorPartido);
            foreach (var kvp in votosPorPartido)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} votos");
            }
        }
    }
}
