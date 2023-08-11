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
        SqlConnection Conn = BDComun.ObtenerConexion();
        public static bool MostrarResultados { get; set; }

        public static Dictionary<string, int> votosPorPartido;

        public FormRegistro()
        {
            InitializeComponent();
            VotanteDAL.CrearTabla(Conn);
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
                        ventanaVotacion.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron guardar los datos!!", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
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
            bool VotacionComenzada = false;
            votosPorPartido = new Dictionary<string, int>
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

            string mensaje2 = "Resultados de la votación cargada:\n\n";
            if (VotanteDAL.votosPorPartido != null && VotanteDAL.votosPorPartido.Count > 0)
            {
                foreach (var kvp in VotanteDAL.votosPorPartido)
                {
                    mensaje2 += $"{kvp.Key}: {kvp.Value} votos\n";
                }
                MessageBox.Show(mensaje2);
            }
            else if (votosPorPartido != null && votosPorPartido.Count>0)
            {
                string mensaje = "Resultados de la votación:\n\n";
                foreach (var kvp in votosPorPartido)
                {
                    mensaje += $"{kvp.Key}: {kvp.Value} votos\n";
                    if (kvp.Value != 0)
                    {
                        VotacionComenzada = true;
                    }
                }

                if (VotacionComenzada)
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Votación no comenzada");
                }
            }
        }

        private void buttonGuardarVotosBD_Click_1(object sender, EventArgs e)
        {
            VotanteDAL.GuardarVotos(votosPorPartido);
            MessageBox.Show("Votos guardados con éxito en la BD");
        }

        private void buttonCargarBD_Click_1(object sender, EventArgs e)
        {
            VotanteDAL.CargarVotos();
            MessageBox.Show("Votos cargados con éxito en la BD");
        }
    }
}
