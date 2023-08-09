namespace VotoElectronico
{
    partial class FormRegistro
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelEdad = new System.Windows.Forms.Label();
            this.textBoxEdad = new System.Windows.Forms.TextBox();
            this.checkBoxAntecedentes = new System.Windows.Forms.CheckBox();
            this.buttonResultados = new System.Windows.Forms.Button();
            this.labelApellidos = new System.Windows.Forms.Label();
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.buttonGuardarVotosBD = new System.Windows.Forms.Button();
            this.buttonCargarBD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmar.Location = new System.Drawing.Point(24, 212);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(119, 41);
            this.buttonConfirmar.TabIndex = 6;
            this.buttonConfirmar.Text = "CONFIRMAR";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.ButtonConfirmar_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(35, 47);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(62, 18);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(125, 47);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 2;
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdad.Location = new System.Drawing.Point(35, 126);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(42, 18);
            this.labelEdad.TabIndex = 3;
            this.labelEdad.Text = "Edad";
            // 
            // textBoxEdad
            // 
            this.textBoxEdad.Location = new System.Drawing.Point(125, 126);
            this.textBoxEdad.Name = "textBoxEdad";
            this.textBoxEdad.Size = new System.Drawing.Size(100, 20);
            this.textBoxEdad.TabIndex = 4;
            // 
            // checkBoxAntecedentes
            // 
            this.checkBoxAntecedentes.AutoSize = true;
            this.checkBoxAntecedentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAntecedentes.Location = new System.Drawing.Point(72, 161);
            this.checkBoxAntecedentes.Name = "checkBoxAntecedentes";
            this.checkBoxAntecedentes.Size = new System.Drawing.Size(116, 22);
            this.checkBoxAntecedentes.TabIndex = 5;
            this.checkBoxAntecedentes.Text = "Antecedentes";
            this.checkBoxAntecedentes.UseVisualStyleBackColor = true;
            // 
            // buttonResultados
            // 
            this.buttonResultados.Location = new System.Drawing.Point(163, 222);
            this.buttonResultados.Name = "buttonResultados";
            this.buttonResultados.Size = new System.Drawing.Size(113, 23);
            this.buttonResultados.TabIndex = 7;
            this.buttonResultados.Text = "VER RESULTADOS";
            this.buttonResultados.UseVisualStyleBackColor = true;
            this.buttonResultados.Click += new System.EventHandler(this.ButtonResultados_Click);
            // 
            // labelApellidos
            // 
            this.labelApellidos.AutoSize = true;
            this.labelApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellidos.Location = new System.Drawing.Point(35, 87);
            this.labelApellidos.Name = "labelApellidos";
            this.labelApellidos.Size = new System.Drawing.Size(67, 18);
            this.labelApellidos.TabIndex = 9;
            this.labelApellidos.Text = "Apellidos";
            // 
            // textBoxApellidos
            // 
            this.textBoxApellidos.Location = new System.Drawing.Point(125, 87);
            this.textBoxApellidos.Name = "textBoxApellidos";
            this.textBoxApellidos.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellidos.TabIndex = 3;
            // 
            // buttonGuardarVotosBD
            // 
            this.buttonGuardarVotosBD.Location = new System.Drawing.Point(24, 294);
            this.buttonGuardarVotosBD.Name = "buttonGuardarVotosBD";
            this.buttonGuardarVotosBD.Size = new System.Drawing.Size(113, 30);
            this.buttonGuardarVotosBD.TabIndex = 10;
            this.buttonGuardarVotosBD.Text = "GUARDAR EN BD";
            this.buttonGuardarVotosBD.UseVisualStyleBackColor = true;
            this.buttonGuardarVotosBD.Click += new System.EventHandler(this.ButtonGuardarVotosBD_Click);
            // 
            // buttonCargarBD
            // 
            this.buttonCargarBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCargarBD.Location = new System.Drawing.Point(163, 294);
            this.buttonCargarBD.Name = "buttonCargarBD";
            this.buttonCargarBD.Size = new System.Drawing.Size(113, 29);
            this.buttonCargarBD.TabIndex = 11;
            this.buttonCargarBD.Text = "CARGAR BD";
            this.buttonCargarBD.UseVisualStyleBackColor = true;
            this.buttonCargarBD.Click += new System.EventHandler(this.ButtonCargarBD_Click);
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(300, 360);
            this.Controls.Add(this.buttonCargarBD);
            this.Controls.Add(this.buttonGuardarVotosBD);
            this.Controls.Add(this.textBoxApellidos);
            this.Controls.Add(this.labelApellidos);
            this.Controls.Add(this.buttonResultados);
            this.Controls.Add(this.checkBoxAntecedentes);
            this.Controls.Add(this.textBoxEdad);
            this.Controls.Add(this.labelEdad);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.buttonConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormRegistro";
            this.Text = "REGISTRO VOTANTE";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelEdad;
        private System.Windows.Forms.TextBox textBoxEdad;
        private System.Windows.Forms.CheckBox checkBoxAntecedentes;
        private System.Windows.Forms.Button buttonResultados;
        private System.Windows.Forms.Label labelApellidos;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.Button buttonGuardarVotosBD;
        private System.Windows.Forms.Button buttonCargarBD;
    }
}

