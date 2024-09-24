using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotoElectronico
{
    public partial class FormRegistro : Form
    {
        private readonly int mayoriaEdad = 18;

        FormVotacion ventanaVotacion = new FormVotacion();

        public static Dictionary<string, int> votosPorPartido = new Dictionary<string, int>();

        Conexion objetoConexion = new Conexion();

        public FormRegistro()
        {
            InitializeComponent();
        }

        private void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            int edad;

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("Introduce tu nombre");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxApellidos.Text))
            {
                MessageBox.Show("Introduce tus apellidos");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxEdad.Text))
            {
                MessageBox.Show("Introduce tu edad");
                return;
            }

            try
            {
                if (int.TryParse(textBoxEdad.Text, out edad))
                {
                    if (edad < mayoriaEdad)
                    {
                        MessageBox.Show("Menores de edad no pueden votar");
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(textBoxNombre.Text) && !string.IsNullOrWhiteSpace(textBoxApellidos.Text) 
                        && edad >= mayoriaEdad)
                    {
                        
                        string nombre = textBoxNombre.Text ;
                        string apellidos = textBoxApellidos.Text;

                        if (VotanteExiste(nombre, apellidos, edad))
                        {
                            MessageBox.Show("El votante ya realizo su voto anteriormnete.");
                            return;
                        }
                        else
                        {
                            // Usar SqlConnection para conectarse a la base de datos
                            using (var context = new DBonlineAntonioEF()) //***EF
                            {
                                try
                                {
                                    // Crear el objeto votante con los datos del formulario
                                    var nuevoVotante = new Voto_Votante
                                    {
                                        Nombre = nombre,
                                        Apellidos = apellidos,
                                        Edad = edad,
                                    };

                                    // Agregar el nuevo votante al contexto
                                    context.Voto_Votante.Add(nuevoVotante);

                                    //Guardar los cambios en la base de datos
                                    int rowsAffected = context.SaveChanges();

                                    // Verificar si se ha insertado correctamente
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("El votante ha sido insertado exitosamente.");
                                        textBoxNombre.Text = "";
                                        textBoxApellidos.Text = "";
                                        textBoxEdad.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo insertar el votante.");
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al intentar insertar el votante: " + ex.Message);
                                    return;
                                }
                            }
                        }
                        ventanaVotacion.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Introduce un formato correcto en la edad");
                    }
                }                  
            }
            catch(Exception ex)
            {
                MessageBox.Show("Excepcion: " + ex.Message);
            }        
        }

        private void ButtonResultados_Click(object sender, EventArgs e)
        {
            bool votacionComenzada = false;

            // Usar el contexto de Entity Framework
            using (var context = new DBonlineAntonioEF())
            {
                int count = context.Voto_PartidoPolitico.Count();

                if (count > 0)
                {
                    // Obtener los nombres y votos de los partidos
                    var partidos = context.Voto_PartidoPolitico.Select(p => new { p.Nombre, p.Votos }).ToList();

                    votosPorPartido.Clear();

                    foreach (var partido in partidos)
                    {
                        votosPorPartido[partido.Nombre] = partido.Votos;
                    }

                    if (votosPorPartido.Count > 0)
                    {
                        string mensaje = "Resultados de la votación:\n\n";
                        foreach (var kvp in votosPorPartido)
                        {
                            mensaje += $"{kvp.Key}: {kvp.Value} votos\n";
                            votacionComenzada = true;
                        }

                        if (votacionComenzada)
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("Votación no comenzada");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay datos para ver de la votación");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron partidos políticos en la base de datos.");
                }
            }
        }

        public bool VotanteExiste(string nombre, string apellidos, int edad)
        {
            try
            {
                using (var context = new DBonlineAntonioEF())
                {
                    // Verificar si existe un votante con el nombre, apellidos y edad especificados
                    int count = context.Voto_Votante
                        .Count(v => v.Nombre == nombre && v.Apellidos == apellidos && v.Edad == edad);

                    return count > 0;  // Devuelve true si hay al menos una coincidencia, indicando que el votante existe
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void textBoxEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter no es un dígito y no es la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito, cancelar el evento para que no se introduzca en el TextBox
                e.Handled = true;
            }
        }
    }
}
