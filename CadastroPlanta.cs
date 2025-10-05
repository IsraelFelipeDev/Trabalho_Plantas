using App_Plantas.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq; // Adicione esta linha para usar FirstOrDefault
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace App_Plantas
{
    public partial class CadastroPlanta : Form
    {
        // Variável para armazenar o caminho da imagem selecionada
        private string caminhoImagemPlanta;
       
        private int _usuarioId;

        // A variável para armazenar os dados da API
        private (string NomePopular, string NomeCientifico, string Familia, string Genero,
        string FrequenciaRega, string TipoSolo, string NivelSol) dadosIdentificacao;

        public CadastroPlanta()
        {
            InitializeComponent();
        }

        public CadastroPlanta(int usuarioId) : this()
        {
            _usuarioId = usuarioId; // Armazena o ID do usuário
        }

        private void pb_FotoPlanta_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoImagemPlanta = openFileDialog.FileName;
                try
                {
                    // Usa um FileStream para ler o arquivo e carregar a imagem na memória.
                    // O "using" garante que o stream será fechado e o arquivo liberado.
                    using (var stream = new System.IO.FileStream(caminhoImagemPlanta, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        pb_FotoPlanta.Image = System.Drawing.Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
        }

        private async void btn_BuscarFoto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(caminhoImagemPlanta))
            {
                MessageBox.Show("Por favor, adicione uma imagem da planta primeiro.");
                return;
            }

            try
            {
                // Desabilitar o botão para evitar múltiplas chamadas
                btn_BuscarFoto.Enabled = false;

                PlantaService service = new PlantaService();

                // Chamar o método assíncrono da API
                dadosIdentificacao = await service.IdentificarPlantaAsync(caminhoImagemPlanta);


                // Preencher os campos da tela com os dados retornados
                txt_NomePop.Text = dadosIdentificacao.NomePopular;
                txt_NomeCient.Text = dadosIdentificacao.NomeCientifico;
                txt_Familia.Text = dadosIdentificacao.Familia;
                txt_Genero.Text = dadosIdentificacao.Genero;

                MessageBox.Show("Identificação concluída com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar informações da planta: " + ex.Message);

                // Limpar os campos em caso de erro
                txt_NomePop.Text = "";
                txt_NomeCient.Text = "";
                txt_Familia.Text = "";
                txt_Genero.Text = "";
            }
            finally
            {
                btn_BuscarFoto.Enabled = true;
                // Reabilitar o botão após a conclusão
            }
        }

        private async void btn_Cadastrar_Click(object sender, EventArgs e)
        {   
            
            if (string.IsNullOrEmpty(caminhoImagemPlanta))
            {
                MessageBox.Show("Por favor, adicione uma imagem da planta primeiro.");
                return;
            }

            try
            {
                btn_Cadastrar.Enabled = false;

                PlantaService service = new PlantaService();

                // Chama o método para cadastrar a planta com identificação
                int idPlanta = await service.CadastrarNovaPlantaComIdentificacaoAsync(
                    caminhoImagemPlanta,
                    _usuarioId,
                    txt_NomePerson.Text.Trim(), // Apelido
                    "" // Descrição
                );

                MessageBox.Show($"Planta cadastrada com sucesso! ID: {idPlanta}");

                // Define o DialogResult como OK para que o formulário Jardim saiba que o cadastro foi bem-sucedido.
                this.DialogResult = DialogResult.OK;
                Jardim volt = new Jardim(_usuarioId);
                this.Hide();
                volt.Show();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar a planta: " + ex.Message);
            }
            finally
            {
                btn_Cadastrar.Enabled = true;
            }
        }

        private void LimparCampos()
        {
            pb_FotoPlanta.Image = null;
            caminhoImagemPlanta = string.Empty; // Limpar a variável do caminho
            txt_NomePop.Clear();
            txt_NomeCient.Clear();
            txt_Familia.Clear();
            txt_Genero.Clear();
            txt_NomePerson.Clear();

            // Também limpar a variável de identificação
            dadosIdentificacao = (null, null, null, null, null, null, null);
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Jardim volt = new Jardim(_usuarioId);
            this.Hide();
            volt.Show();
        }

        private void CadastroPlanta_Load(object sender, EventArgs e)
        {

        }
    }
}



