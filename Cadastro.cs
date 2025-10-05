using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Plantas
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            
            
            string nomeDigitado = txt_Nome.Text.Trim();
            string emailDigitado = txt_Email.Text.Trim();
            string senhaDigitada = txt_Senha.Text;

            
            if (string.IsNullOrEmpty(nomeDigitado))
            {
                MessageBox.Show("Por favor, digite seu nome.");
                return;
            }

            if (string.IsNullOrEmpty(emailDigitado) || !IsValidEmail(emailDigitado))
            {
                MessageBox.Show("Por favor, digite um e-mail válido.");
                return;
            }

            if (string.IsNullOrEmpty(senhaDigitada) || senhaDigitada.Length < 6)
            {
                MessageBox.Show("A senha deve ter no mínimo 6 caracteres.");
                return;
            }

            
            try
            {
                Usuario novoUsuario = new Usuario();
                novoUsuario.Nome = nomeDigitado;
                novoUsuario.Email = emailDigitado;

                // O método CadastrarUsuario já se encarrega do hash da senha
                novoUsuario.CadastrarUsuario(senhaDigitada);

                MessageBox.Show("Usuário cadastrado com sucesso!");
                Form1 MeuJardim = new Form1();
                this.Hide();
                MeuJardim.Show();

                // Limpar campos após o cadastro
                txt_Nome.Clear();
                txt_Email.Clear();
                txt_Senha.Clear();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                // Tratamento específico para e-mail duplicado
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Este e-mail já está em uso. Por favor, tente outro.");
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message);
            }
        }

        // Método de validação de e-mail (você pode adicionar esta função na sua classe de formulário)
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            Form1 nv = new Form1();
            this.Hide();
            nv.Show();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }
    }
    }

