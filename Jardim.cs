using App_Plantas.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace App_Plantas
{
    public partial class Jardim : Form
    {
        private int _usuarioId;
        private string _nomeUsuario;
        // OS dois construtores responsaveis por iniciar o formulario e receber o id do usuario logado
        // e tambem o nome do usuario logado

        public Jardim(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }

        
        private async void Jardim_Load(object sender, EventArgs e)
        // Esse metodo carrega as plantas do usuario e estiliza o botao de adicionar planta
        {
            

            PlantaService service = new PlantaService();
            // Carrega o nome do usuário logado para exibir no label

            _nomeUsuario = await service.ConsultarNomeUsuarioAsync(_usuarioId);
            label2.Text = _nomeUsuario; // Use o campo de classe aqui
            await CarregarPlantasEmImagensAsync();
            
        }

        private async Task CarregarPlantasEmImagensAsync()
        {
            PlantaService service = new PlantaService();
            var lista = await Task.Run(() => service.ConsultarPlantasPorUsuario(_usuarioId));

            // Garantir que a atualização da UI seja feita na thread correta
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(async () => await AtualizarUIComPlantas(lista)));
            }
            else
            {
                await AtualizarUIComPlantas(lista);
            }
        }

        private async Task AtualizarUIComPlantas(List<Planta> lista)
        {
            // Limpa apenas os PictureBoxes de plantas existentes, mantendo o botão
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(btn_AdicionarPlanta);

            // Adiciona os novos PictureBoxes dinamicamente
            foreach (var planta in lista)
            {
                PictureBox pb = new PictureBox
                {
                    Width = 135,
                    Height = 135,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = planta.Id
                };

                // Verifica se o nome do arquivo da foto existe no banco de dados
                if (!string.IsNullOrEmpty(planta.Foto))
                {
                    // Usa a variável de instância para construir o caminho completo do arquivo
                    string pastaFotosProjeto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plantas_Fotos");
                    string caminhoCompletoFoto = Path.Combine(pastaFotosProjeto, planta.Foto);

                    // Verifica se o arquivo físico existe no diretório correto
                    if (File.Exists(caminhoCompletoFoto))
                    {
                        try
                        {
                            using (var stream = new FileStream(caminhoCompletoFoto, FileMode.Open, FileAccess.Read))
                            {
                                pb.Image = Image.FromStream(stream);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao carregar imagem para a planta {planta.NomePopular}: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"O arquivo da imagem '{planta.Foto}' não foi encontrado em '{pastaFotosProjeto}'.");
                    }
                }
                // Adiciona um ToolTip para exibir o nome popular e científico ao passar o mouse sobre a imagem
                ToolTip tt = new ToolTip();
                tt.SetToolTip(pb, $"{planta.NomePopular} - {planta.NomeCientifico}");
                // Adiciona o evento de clique para abrir o perfil da planta

                pb.Click += (s, e) =>
                {
                    int plantaId = (int)((PictureBox)s).Tag;
                    PerefilPlanta perfil = new PerefilPlanta(plantaId, _usuarioId);
                    perfil.ShowDialog();
                    // Após fechar o perfil, recarregue a lista de plantas para refletir possíveis alterações.
                    Task.Run(async () => await CarregarPlantasEmImagensAsync());
                };

                flowLayoutPanel1.Controls.Add(pb);
                // Adiciona um pequeno atraso para melhorar a experiência visual ao carregar várias imagens
            }
        }

        private async void btn_AdicionarPlanta_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (CadastroPlanta cadastroPlantaForm = new CadastroPlanta(_usuarioId))
            {
                DialogResult resultado = cadastroPlantaForm.ShowDialog();
                

                if (resultado == DialogResult.OK)
                {
                    await CarregarPlantasEmImagensAsync();
                }
            }
        }


        // Esse metodo abre o chat global passando o id do usuario logado
        private void btnAbrirChatGlobal_Click(object sender, EventArgs e)
        {
            // Verifica se o ID do usuário é válido
            if (_usuarioId == -1) 
            {
                MessageBox.Show("Erro: Usuário não logado. Por favor, reinicie a aplicação e faça login.", "Erro de Sessão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Instancia o ChatGlobal, passando o ID do usuário logado
            ChatGlobal chatForm = new ChatGlobal(_usuarioId, _nomeUsuario);
            this.Hide();
            chatForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            configurarAlrm def = new configurarAlrm(_usuarioId);
            this.Hide();
            def.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}

