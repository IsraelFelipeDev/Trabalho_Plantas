using System;
using System.Drawing;
using System.Windows.Forms;

namespace App_Plantas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string emailDigitado = txt_Login.Text.Trim();
            string senhaDigitada = txt_senha.Text;

            if (string.IsNullOrEmpty(emailDigitado))
            {
                MessageBox.Show("Por favor, digite seu e-mail.");
                return;
            }

            if (string.IsNullOrEmpty(senhaDigitada))
            {
                MessageBox.Show("Por favor, digite sua senha.");
                return;
            }

            try
            {
                
                Usuario usuarioLogin = new Usuario();
                int idUsuario = usuarioLogin.Login(emailDigitado, senhaDigitada);
                // Login bem-sucedido, idUsuario contém o ID do usuário


                if (idUsuario > 0)
                // Se o ID for maior que 0, o login foi bem-sucedido
                {
                    MessageBox.Show("Login efetuado com sucesso!");

                    // Instanciar o formulário Jardim e passar o ID do usuário
                    Jardim ver = new Jardim(idUsuario);

                    this.Hide();
                    ver.Show();

                    txt_Login.Clear();
                    txt_senha.Clear();

                    string nomeUsuario = usuarioLogin.ObterNomePorId(idUsuario);
                    MessageBox.Show($"Bem-vindo, {nomeUsuario}!");
                }
                else
                {
                    // Login falhou, exibe mensagem de erro
                    MessageBox.Show("E-mail ou senha incorretos. Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar o login: " + ex.Message);
            }
        }

        private void linkLbl_FaçaCadast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        // Evento para abrir o formulário de cadastro caso o usuário não tenha uma conta ainda
        {
            // Abrir o formulário de cadastro
            Cadastro telaCadastro = new Cadastro();
            this.Hide();
            telaCadastro.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}