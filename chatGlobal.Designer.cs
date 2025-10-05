namespace App_Plantas
{
    partial class ChatGlobal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatGlobal));
            this.label1 = new System.Windows.Forms.Label();
            this.pbFotoUpload = new System.Windows.Forms.PictureBox();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.lbl_NomeUser = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.flpChat = new System.Windows.Forms.FlowLayoutPanel();
            this.timerAtualizacao = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "ChatPlanta";
            // 
            // pbFotoUpload
            // 
            this.pbFotoUpload.Image = ((System.Drawing.Image)(resources.GetObject("pbFotoUpload.Image")));
            this.pbFotoUpload.Location = new System.Drawing.Point(1060, 788);
            this.pbFotoUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbFotoUpload.Name = "pbFotoUpload";
            this.pbFotoUpload.Size = new System.Drawing.Size(83, 76);
            this.pbFotoUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoUpload.TabIndex = 3;
            this.pbFotoUpload.TabStop = false;
            this.pbFotoUpload.Click += new System.EventHandler(this.pbFotoUpload_Click_1);
            // 
            // txtMensagem
            // 
            this.txtMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensagem.Location = new System.Drawing.Point(269, 814);
            this.txtMensagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(425, 34);
            this.txtMensagem.TabIndex = 4;
            this.txtMensagem.Text = "Digite sua Mensagem ";
            // 
            // lbl_NomeUser
            // 
            this.lbl_NomeUser.AutoSize = true;
            this.lbl_NomeUser.Font = new System.Drawing.Font("Poor Richard", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomeUser.Location = new System.Drawing.Point(62, 799);
            this.lbl_NomeUser.Name = "lbl_NomeUser";
            this.lbl_NomeUser.Size = new System.Drawing.Size(25, 31);
            this.lbl_NomeUser.TabIndex = 5;
            this.lbl_NomeUser.Text = "-";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(831, 799);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(140, 50);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // flpChat
            // 
            this.flpChat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flpChat.BackgroundImage")));
            this.flpChat.Location = new System.Drawing.Point(24, 91);
            this.flpChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpChat.Name = "flpChat";
            this.flpChat.Size = new System.Drawing.Size(1084, 658);
            this.flpChat.TabIndex = 8;
            // 
            // timerAtualizacao
            // 
            this.timerAtualizacao.Interval = 2000;
            this.timerAtualizacao.Tick += new System.EventHandler(this.timerAtualizacao_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1089, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ChatGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 1106);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flpChat);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lbl_NomeUser);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.pbFotoUpload);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatGlobal";
            this.Text = "chatGlobal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChatGlobal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbFotoUpload;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label lbl_NomeUser;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.FlowLayoutPanel flpChat;
        private System.Windows.Forms.Timer timerAtualizacao;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}