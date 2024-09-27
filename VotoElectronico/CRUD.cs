using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotoElectronico
{
    public class CRUD
    {
        private const string MensajeErrorGeneral = "Error: ";

        //FORMREGISTRO
        public static bool VotanteExiste(string nombre, string apellidos, int edad)
        {
            try
            {
                using (var context = new DBonlineAntonioEF())
                {
                    // Verificar si existe un votante con el nombre, apellidos y edad especificados
                    int count = context.Voto_Votante
                        .Count(v => v.Nombre == nombre && v.Apellidos == apellidos && v.Edad == edad);

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MensajeErrorGeneral + ex.Message);
                return false;
            }
        }

        public static bool AgregarVotante(string nombre, string apellidos, int edad)
        {
            using (var context = new DBonlineAntonioEF())
            {
                try
                {
                    var nuevoVotante = new Voto_Votante
                    {
                        Nombre = nombre,
                        Apellidos = apellidos,
                        Edad = edad,
                    };
                    context.Voto_Votante.Add(nuevoVotante);
                    return context.SaveChanges() > 0; // Retorna true si se inserta correctamente
                }
                catch (Exception)
                {
                    // Manejo de errores se puede implementar según sea necesario
                    return false;
                }
            }
        }


        public static Dictionary<string, int> ObtenerResultadosVotacion()
        {
            var resultados = new Dictionary<string, int>();

            using (var context = new DBonlineAntonioEF())
            {
                var partidos = context.Voto_PartidoPolitico.Select(p => new { p.Nombre, p.Votos }).ToList();

                foreach (var partido in partidos)
                {
                    resultados[partido.Nombre] = partido.Votos;
                }
            }

            return resultados;
        }


        //FORMVOTACION
        public static void ActualizarVotos(string partidoPolitico)
        {
            using (var context = new DBonlineAntonioEF())
            {
                try
                {
                    // Buscar el partido político por nombre
                    var partido = context.Voto_PartidoPolitico
                        .FirstOrDefault(p => p.Nombre == partidoPolitico);

                    // Si se encuentra el partido, incrementamos los votos
                    if (partido != null)
                    {
                        partido.Votos += 1;
                        context.SaveChanges();
                        Console.WriteLine("El voto se ha registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El partido político no fue encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(MensajeErrorGeneral + ex.Message);
                }
            }
        }
    }
}
