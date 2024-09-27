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
        private const string MensajeNoDatosVotacion = "No hay datos para ver de la votación";
        private const string MensajeEdadFormatoIncorrecto = "Introduce un formato correcto en la edad";
        private const string MensajeVotanteNoInsertado = "No se pudo insertar el votante.";

        private const string MensajeErrorGeneral = "Error: ";

        private readonly int mayoriaEdad = 18;    
        public static Dictionary<string, int> votosPorPartido = new Dictionary<string, int>();
        FormVotacion ventanaVotacion = new FormVotacion();

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
                        
                    string nombre = textBoxNombre.Text ;
                    string apellidos = textBoxApellidos.Text;

                    if (CRUD.VotanteExiste(nombre, apellidos, edad))
                    {
                        MessageBox.Show("El votante ya realizo su voto anteriormnete.");
                        return;
                    }
                    else
                    {
                        if (CRUD.AgregarVotante(nombre, apellidos, edad))
                        {
                            MessageBox.Show("El votante ha sido insertado exitosamente.");
                            textBoxNombre.Text = "";
                            textBoxApellidos.Text = "";
                            textBoxEdad.Text = "";
                        }
                        else
                        {
                            MessageBox.Show(MensajeVotanteNoInsertado);
                            return;
                        }
                    }
                    ventanaVotacion.ShowDialog();
                }
                else
                {
                    MessageBox.Show(MensajeEdadFormatoIncorrecto);
                }               
            }
            catch(Exception ex)
            {
                MessageBox.Show(MensajeErrorGeneral + ex.Message);
            }        
        }

        private void ButtonResultados_Click(object sender, EventArgs e)
        {
            var votosPorPartido = CRUD.ObtenerResultadosVotacion();

            if (votosPorPartido.Count > 0)
            {
                string mensaje = "Resultados de la votación:\n\n";
                foreach (var kvp in votosPorPartido)
                {
                    mensaje += $"{kvp.Key}: {kvp.Value} votos\n";
                }
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show(MensajeNoDatosVotacion);
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
