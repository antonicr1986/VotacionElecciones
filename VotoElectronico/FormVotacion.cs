using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotoElectronico
{
    public partial class FormVotacion : Form
    {
        Conexion objetoConexion = new Conexion();

        public FormVotacion()
        {
            InitializeComponent();
        }

        private void ButtonConfirmarVoto_Click(object sender, EventArgs e)
        {
            if (!radioButtonPP.Checked && !radioButtonPSOE.Checked && !radioButtonSUMAR.Checked && !radioButtonVOX.Checked 
                && !radioButtonJUNTS.Checked && !radioButtonERC.Checked && !radioButtonEHBildu.Checked && !radioButtonPNV.Checked)
            {
                MessageBox.Show("Has de elejir un partido politico");
            }
            else
            {
                if (radioButtonPP.Checked)
                {
                    ActualizarVotos("PP");
                }
                else if (radioButtonPSOE.Checked)
                {
                    ActualizarVotos("PSOE");
                }
                else if (radioButtonSUMAR.Checked)
                {
                    ActualizarVotos("SUMAR");
                }
                else if (radioButtonVOX.Checked)
                {
                    ActualizarVotos("VOX");
                }
                else if (radioButtonERC.Checked)
                {
                    ActualizarVotos("JUNTS");
                }
                else if (radioButtonJUNTS.Checked)
                {
                    ActualizarVotos("ERC");
                }
                else if (radioButtonPNV.Checked)
                {
                    ActualizarVotos("PNV");
                }
                else if (radioButtonEHBildu.Checked)
                {
                    ActualizarVotos("EHBildu");
                }

                MessageBox.Show("Has introducido tu voto correctamente");
                this.Hide();
            }            
        }

        public void ActualizarVotos(string partidoPolitico) //TODO
        {
            // Utilizamos el contexto de Entity Framework
            using (var context = new DBonlineAntonioEntities())
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
                        context.SaveChanges(); // Guardar los cambios en la base de datos
                        Console.WriteLine("El voto se ha registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El partido político no fue encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
