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
                    CRUD.ActualizarVotos("PP");
                }
                else if (radioButtonPSOE.Checked)
                {
                    CRUD.ActualizarVotos("PSOE");
                }
                else if (radioButtonSUMAR.Checked)
                {
                    CRUD.ActualizarVotos("SUMAR");
                }
                else if (radioButtonVOX.Checked)
                {
                    CRUD.ActualizarVotos("VOX");
                }
                else if (radioButtonERC.Checked)
                {
                    CRUD.ActualizarVotos("JUNTS");
                }
                else if (radioButtonJUNTS.Checked)
                {
                    CRUD.ActualizarVotos("ERC");
                }
                else if (radioButtonPNV.Checked)
                {
                    CRUD.ActualizarVotos("PNV");
                }
                else if (radioButtonEHBildu.Checked)
                {
                    CRUD.ActualizarVotos("EHBildu");
                }

                MessageBox.Show("Has introducido tu voto correctamente");
                this.Hide();
            }            
        }

        
    }
}
