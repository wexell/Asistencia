namespace Asistencia
{
    partial class Modificar
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modificar));
            this.label8 = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.DateTimePicker();
            this.uphoras = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGerencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPuesto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.updias = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.tbEmpleado = new System.Windows.Forms.TextBox();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.uphoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updias)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(92, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "Fecha:";
            // 
            // Fecha
            // 
            this.Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha.Location = new System.Drawing.Point(179, 196);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(101, 20);
            this.Fecha.TabIndex = 54;
            // 
            // uphoras
            // 
            this.uphoras.DecimalPlaces = 2;
            this.uphoras.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.uphoras.Location = new System.Drawing.Point(179, 251);
            this.uphoras.Name = "uphoras";
            this.uphoras.Size = new System.Drawing.Size(88, 20);
            this.uphoras.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(75, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 52;
            this.label7.Text = "Gerencia:";
            // 
            // tbGerencia
            // 
            this.tbGerencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGerencia.Location = new System.Drawing.Point(176, 145);
            this.tbGerencia.Name = "tbGerencia";
            this.tbGerencia.ReadOnly = true;
            this.tbGerencia.Size = new System.Drawing.Size(227, 20);
            this.tbGerencia.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(91, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 50;
            this.label6.Text = "Puesto:";
            // 
            // tbPuesto
            // 
            this.tbPuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPuesto.Location = new System.Drawing.Point(177, 109);
            this.tbPuesto.Name = "tbPuesto";
            this.tbPuesto.ReadOnly = true;
            this.tbPuesto.Size = new System.Drawing.Size(227, 20);
            this.tbPuesto.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(342, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Dias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(74, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Cantidad:";
            // 
            // updias
            // 
            this.updias.Location = new System.Drawing.Point(291, 251);
            this.updias.Name = "updias";
            this.updias.Size = new System.Drawing.Size(88, 20);
            this.updias.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(72, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Nombres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(214, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Horas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(65, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "Empleado:";
            // 
            // tbNombres
            // 
            this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombres.Location = new System.Drawing.Point(176, 76);
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.ReadOnly = true;
            this.tbNombres.Size = new System.Drawing.Size(227, 20);
            this.tbNombres.TabIndex = 39;
            // 
            // tbEmpleado
            // 
            this.tbEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmpleado.Location = new System.Drawing.Point(176, 35);
            this.tbEmpleado.Name = "tbEmpleado";
            this.tbEmpleado.ReadOnly = true;
            this.tbEmpleado.Size = new System.Drawing.Size(119, 20);
            this.tbEmpleado.TabIndex = 56;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Appearance.Options.UseForeColor = true;
            this.btnUpdate.AppearancePressed.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdate.AppearancePressed.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.AppearancePressed.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.AppearancePressed.Options.UseBackColor = true;
            this.btnUpdate.AppearancePressed.Options.UseBorderColor = true;
            this.btnUpdate.BackgroundImage = global::Asistencia.Properties.Resources.naranja;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnUpdate.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(187, 310);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 37);
            this.btnUpdate.TabIndex = 120;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Appearance.Options.UseForeColor = true;
            this.btnBack.AppearancePressed.BackColor = System.Drawing.Color.DeepPink;
            this.btnBack.AppearancePressed.BackColor2 = System.Drawing.Color.DeepPink;
            this.btnBack.AppearancePressed.BorderColor = System.Drawing.Color.LightCoral;
            this.btnBack.AppearancePressed.Options.UseBackColor = true;
            this.btnBack.AppearancePressed.Options.UseBorderColor = true;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(355, 23);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(48, 37);
            this.btnBack.TabIndex = 46;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(109)))));
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbEmpleado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.uphoras);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbGerencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPuesto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNombres);
            this.Name = "Modificar";
            this.Size = new System.Drawing.Size(872, 446);
            this.Load += new System.EventHandler(this.Modificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uphoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker Fecha;
        private System.Windows.Forms.NumericUpDown uphoras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGerencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPuesto;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown updias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombres;
        private System.Windows.Forms.TextBox tbEmpleado;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
    }
}
