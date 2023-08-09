using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VotoElectronico
{
    class VotanteDAL
    {
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

                    string insertQuery = $"INSERT INTO VotosPartidos (Partido, Votos) VALUES ('{partido}', {votos})";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
