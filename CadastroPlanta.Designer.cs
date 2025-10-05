namespace App_Plantas
{
    partial class CadastroPlanta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroPlanta));
            this.pb_FotoPlanta = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_NomePerson = new System.Windows.Forms.Label();
            this.txt_NomePerson = new System.Windows.Forms.TextBox();
            this.lbl_NomeCient = new System.Windows.Forms.Label();
            this.lbl_Familia = new System.Windows.Forms.Label();
            this.lbl_Genero = new System.Windows.Forms.Label();
            this.lbl_NomeP = new System.Windows.Forms.Label();
            this.btn_BuscarFoto = new System.Windows.Forms.Button();
            this.btn_Cadastrar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.txt_NomePop = new System.Windows.Forms.TextBox();
            this.txt_NomeCient = new System.Windows.Forms.TextBox();
            this.txt_Familia = new System.Windows.Forms.TextBox();
            this.txt_Genero = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FotoPlanta)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_FotoPlanta
            // 
            this.pb_FotoPlanta.Image = ((System.Drawing.Image)(resources.GetObject("pb_FotoPlanta.Image")));
            this.pb_FotoPlanta.Location = new System.Drawing.Point(523, 108);
            this.pb_FotoPlanta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_FotoPlanta.Name = "pb_FotoPlanta";
            this.pb_FotoPlanta.Size = new System.Drawing.Size(177, 152);
            this.pb_FotoPlanta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_FotoPlanta.TabIndex = 0;
            this.pb_FotoPlanta.TabStop = false;
            this.pb_FotoPlanta.Click += new System.EventHandler(this.pb_FotoPlanta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(482, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adicione a foto da sua planta";
            // 
            // lbl_NomePerson
            // 
            this.lbl_NomePerson.AutoSize = true;
            this.lbl_NomePerson.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NomePerson.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomePerson.Location = new System.Drawing.Point(353, 408);
            this.lbl_NomePerson.Name = "lbl_NomePerson";
            this.lbl_NomePerson.Size = new System.Drawing.Size(296, 42);
            this.lbl_NomePerson.TabIndex = 2;
            this.lbl_NomePerson.Text = "Nome Personalizado:";
            // 
            // txt_NomePerson
            // 
            this.txt_NomePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NomePerson.Location = new System.Drawing.Point(706, 414);
            this.txt_NomePerson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_NomePerson.Name = "txt_NomePerson";
            this.txt_NomePerson.Size = new System.Drawing.Size(222, 31);
            this.txt_NomePerson.TabIndex = 3;
            // 
            // lbl_NomeCient
            // 
            this.lbl_NomeCient.AutoSize = true;
            this.lbl_NomeCient.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NomeCient.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomeCient.Location = new System.Drawing.Point(353, 510);
            this.lbl_NomeCient.Name = "lbl_NomeCient";
            this.lbl_NomeCient.Size = new System.Drawing.Size(246, 42);
            this.lbl_NomeCient.TabIndex = 4;
            this.lbl_NomeCient.Text = "Nome Cientifico:";
            // 
            // lbl_Familia
            // 
            this.lbl_Familia.AutoSize = true;
            this.lbl_Familia.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Familia.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Familia.Location = new System.Drawing.Point(356, 574);
            this.lbl_Familia.Name = "lbl_Familia";
            this.lbl_Familia.Size = new System.Drawing.Size(126, 42);
            this.lbl_Familia.TabIndex = 5;
            this.lbl_Familia.Text = "Familia:";
            // 
            // lbl_Genero
            // 
            this.lbl_Genero.AutoSize = true;
            this.lbl_Genero.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Genero.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Genero.Location = new System.Drawing.Point(353, 636);
            this.lbl_Genero.Name = "lbl_Genero";
            this.lbl_Genero.Size = new System.Drawing.Size(123, 42);
            this.lbl_Genero.TabIndex = 6;
            this.lbl_Genero.Text = "Genero:";
            // 
            // lbl_NomeP
            // 
            this.lbl_NomeP.AutoSize = true;
            this.lbl_NomeP.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NomeP.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomeP.Location = new System.Drawing.Point(358, 456);
            this.lbl_NomeP.Name = "lbl_NomeP";
            this.lbl_NomeP.Size = new System.Drawing.Size(256, 42);
            this.lbl_NomeP.TabIndex = 7;
            this.lbl_NomeP.Text = "Nomes Populares:";
            // 
            // btn_BuscarFoto
            // 
            this.btn_BuscarFoto.Location = new System.Drawing.Point(523, 265);
            this.btn_BuscarFoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_BuscarFoto.Name = "btn_BuscarFoto";
            this.btn_BuscarFoto.Size = new System.Drawing.Size(177, 39);
            this.btn_BuscarFoto.TabIndex = 8;
            this.btn_BuscarFoto.Text = "Buscar";
            this.btn_BuscarFoto.UseVisualStyleBackColor = true;
            this.btn_BuscarFoto.Click += new System.EventHandler(this.btn_BuscarFoto_Click);
            // 
            // btn_Cadastrar
            // 
            this.btn_Cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cadastrar.Location = new System.Drawing.Point(801, 850);
            this.btn_Cadastrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cadastrar.Name = "btn_Cadastrar";
            this.btn_Cadastrar.Size = new System.Drawing.Size(172, 52);
            this.btn_Cadastrar.TabIndex = 9;
            this.btn_Cadastrar.Text = "Cadastrar";
            this.btn_Cadastrar.UseVisualStyleBackColor = true;
            this.btn_Cadastrar.Click += new System.EventHandler(this.btn_Cadastrar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(377, 850);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(172, 52);
            this.btn_Cancelar.TabIndex = 10;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // txt_NomePop
            // 
            this.txt_NomePop.Enabled = false;
            this.txt_NomePop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NomePop.Location = new System.Drawing.Point(706, 468);
            this.txt_NomePop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_NomePop.Name = "txt_NomePop";
            this.txt_NomePop.ReadOnly = true;
            this.txt_NomePop.Size = new System.Drawing.Size(222, 31);
            this.txt_NomePop.TabIndex = 11;
            // 
            // txt_NomeCient
            // 
            this.txt_NomeCient.Enabled = false;
            this.txt_NomeCient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NomeCient.Location = new System.Drawing.Point(706, 521);
            this.txt_NomeCient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_NomeCient.Name = "txt_NomeCient";
            this.txt_NomeCient.ReadOnly = true;
            this.txt_NomeCient.Size = new System.Drawing.Size(222, 31);
            this.txt_NomeCient.TabIndex = 12;
            // 
            // txt_Familia
            // 
            this.txt_Familia.Enabled = false;
            this.txt_Familia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Familia.Location = new System.Drawing.Point(706, 582);
            this.txt_Familia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Familia.Name = "txt_Familia";
            this.txt_Familia.ReadOnly = true;
            this.txt_Familia.Size = new System.Drawing.Size(222, 31);
            this.txt_Familia.TabIndex = 13;
            // 
            // txt_Genero
            // 
            this.txt_Genero.Enabled = false;
            this.txt_Genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Genero.Location = new System.Drawing.Point(706, 648);
            this.txt_Genero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Genero.Name = "txt_Genero";
            this.txt_Genero.ReadOnly = true;
            this.txt_Genero.Size = new System.Drawing.Size(222, 31);
            this.txt_Genero.TabIndex = 14;
            // 
            // CadastroPlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 1106);
            this.Controls.Add(this.txt_Genero);
            this.Controls.Add(this.txt_Familia);
            this.Controls.Add(this.txt_NomeCient);
            this.Controls.Add(this.txt_NomePop);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Cadastrar);
            this.Controls.Add(this.btn_BuscarFoto);
            this.Controls.Add(this.lbl_NomeP);
            this.Controls.Add(this.lbl_Genero);
            this.Controls.Add(this.lbl_Familia);
            this.Controls.Add(this.lbl_NomeCient);
            this.Controls.Add(this.txt_NomePerson);
            this.Controls.Add(this.lbl_NomePerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_FotoPlanta);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CadastroPlanta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastroPlanta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CadastroPlanta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_FotoPlanta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_FotoPlanta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_NomePerson;
        private System.Windows.Forms.TextBox txt_NomePerson;
        private System.Windows.Forms.Label lbl_NomeCient;
        private System.Windows.Forms.Label lbl_Familia;
        private System.Windows.Forms.Label lbl_Genero;
        private System.Windows.Forms.Label lbl_NomeP;
        private System.Windows.Forms.Button btn_BuscarFoto;
        private System.Windows.Forms.Button btn_Cadastrar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.TextBox txt_NomePop;
        private System.Windows.Forms.TextBox txt_NomeCient;
        private System.Windows.Forms.TextBox txt_Familia;
        private System.Windows.Forms.TextBox txt_Genero;
    }
}