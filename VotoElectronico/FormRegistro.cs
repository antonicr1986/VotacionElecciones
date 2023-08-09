using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VotoElectronico
{
    public partial class FormRegistro : Form
    {
        private readonly int mayoriaEdad = 18;

        Votante votante = new Votante();
        FormVotacion ventanaVotacion = new FormVotacion();

        public FormRegistro()
        {
            InitializeComponent();
        }

        private void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxEdad.Text, out int edad))
            {
                if (!string.IsNullOrEmpty(textBoxNombre.Text) && !string.IsNullOrEmpty(textBoxApellidos.Text) 
                    && Convert.ToInt32(textBoxEdad.Text) >= mayoriaEdad && !checkBoxAntecedentes.Checked)
                {

                    votante.Nombre = textBoxNombre.Text;
                    votante.Apellidos = textBoxApellidos.Text;
                    votante.Edad = edad;

                    if (checkBoxAntecedentes.Checked)
                    {
                        votante.Antecedentes = "true";
                    }           

                    int resultado = VotanteDAL.Agregar(votante);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Datos del votante guardados con éxito!!", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron guardar los datos!!", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    ventanaVotacion.ShowDialog();
                }
                else
                {
                    if (string.IsNullOrEmpty(textBoxNombre.Text))
                    {
                        MessageBox.Show("Introduce tu nombre");
                    }
                    if (string.IsNullOrEmpty(textBoxApellidos.Text))
                    {
                        MessageBox.Show("Introduce tus apellidos");
                    }
                    if (checkBoxAntecedentes.Checked)
                    {
                        MessageBox.Show("Personas con antecedentes penales no pueden votar");
                    }
                    if (Convert.ToInt32(textBoxEdad.Text) != 0 && Convert.ToInt32(textBoxEdad.Text) < mayoriaEdad)
                    {
                        MessageBox.Show("Menores de edad no pueden votar");
                    }
                }
            }
            else
            {
                MessageBox.Show("Introduce un formato correcto en la edad");
            }
        }

        private void ButtonResultados_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> votosPorPartido = new Dictionary<string, int>
            {
                { "Partido Popular", ventanaVotacion.VotosPP },
                { "PSOE", ventanaVotacion.VotosPSOE },
                { "SUMAR", ventanaVotacion.VotosSUMAR },
                { "VOX", ventanaVotacion.VotosVOX },
                { "JUNTS", ventanaVotacion.VotosJUNTS },
                { "ERC", ventanaVotacion.VotosERC },
                { "PNV", ventanaVotacion.VotosPNV },
                { "EH Bildu", ventanaVotacion.VotosEHBildu }
            };

            string mensaje = "Resultados de la votación:\n\n";
            foreach (var kvp in votosPorPartido)
            {
                mensaje += $"{kvp.Key}: {kvp.Value} votos\n";
            }

            MessageBox.Show(mensaje);          
        }

        private void ButtonGuardarVotosBD_Click(object sender, EventArgs e)
        {
            //VotanteDAL.GuardarVotos(votosPorPartido);
        }
    }
}
