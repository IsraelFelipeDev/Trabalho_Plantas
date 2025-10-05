using App_Plantas.Services;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static App_Plantas.Services.PlantaService;

namespace App_Plantas
{
    public partial class ChatGlobal : Form
    {
        private int _usuarioId;// Armazena o ID do usuário logado.
        private ChatService _chatService;// Serviço para interagir com o banco de dados do chat
        private long _ultimaMensagemId = 0;// Armazena o ID da última mensagem carregada
        private string _caminhoFotoUpload = null;// Armazena o caminho da foto selecionada para upload

        public ChatGlobal(int usuarioId, string nomeUsuario)
        {
            InitializeComponent();
            _usuarioId = usuarioId;// Inicializa o ID do usuário logado
            _chatService = new ChatService();// Inicializa o serviço de chat
            flpChat.AutoScroll = true; // Habilita a rolagem automática
            lbl_NomeUser.Text = nomeUsuario;// Define o nome do usuário na interface

            if (_usuarioId <= 0)
            // Validação simples para garantir que o ID do usuário é válido, se não for, fecha a tela de chat.
            {
                MessageBox.Show("ID de usuário inválido para o chat. Por favor, faça login novamente.", "Erro de Inicialização", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            Task.Run(async () => await CarregarMensagensAsync());
            // Carrega as mensagens existentes ao iniciar o chat e configura o timer para buscar novas mensagens.

            timerAtualizacao.Tick += timerAtualizacao_Tick;
            timerAtualizacao.Interval = 2000; // Define o intervalo para 2 segundos
            timerAtualizacao.Start();
        }

        private void ScrollToBottom()
        // Rola o FlowLayoutPanel para a última mensagem
        {
            if (flpChat.Controls.Count > 0)
            {
                flpChat.ScrollControlIntoView(flpChat.Controls[flpChat.Controls.Count - 1]);
                // Rola para o último controle adicionado
            }
        }

        private async Task CarregarMensagensAsync()
        {
            DataTable mensagens = null;
            try
            {
                mensagens = await _chatService.ObterTodasMensagensAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar mensagens do banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se a chamada está em uma thread diferente da UI
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => UpdateChatUI(mensagens)));
            }
            else
            {
                UpdateChatUI(mensagens);
            }
        }

        private void UpdateChatUI(DataTable mensagens)
        // Atualiza a interface do usuário com as mensagens carregadas
        {
            flpChat.SuspendLayout();// Suspende o layout para evitar flickering
            flpChat.Controls.Clear();
            if (mensagens != null && mensagens.Rows.Count > 0)
            {
                foreach (DataRow row in mensagens.Rows)
                {
                    AdicionarMensagemAoChat(row);// Adiciona cada mensagem ao painel de chat
                }
                _ultimaMensagemId = Convert.ToInt64(mensagens.Rows[mensagens.Rows.Count - 1]["id"]);
            }
            flpChat.ResumeLayout();
            ScrollToBottom();
        }

        private async void timerAtualizacao_Tick(object sender, EventArgs e)
        // Evento disparado a cada tick do timer para buscar novas mensagens
        {
            await BuscarNovasMensagens();
            
        }

        private async Task BuscarNovasMensagens()
        // Busca novas mensagens a partir do último ID conhecido
        {
            DataTable novasMensagens = null;
            // Se ocorrer um erro ao buscar novas mensagens, ele será capturado aqui
            try
            {
                novasMensagens = await _chatService.ObterMensagensAPartirDeAsync(_ultimaMensagemId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar novas mensagens: {ex.Message}");
                return;
            }

            if (novasMensagens != null && novasMensagens.Rows.Count > 0)
            {
                if (this.InvokeRequired)
                // Verifica se a chamada está em uma thread diferente da UI
                {
                    this.Invoke(new MethodInvoker(() => AdicionarNovasMensagensNaUI(novasMensagens)));
                }
                else
                {
                    AdicionarNovasMensagensNaUI(novasMensagens);
                    // Adiciona as novas mensagens à UI
                }
            }
        }

        private void AdicionarNovasMensagensNaUI(DataTable novasMensagens)
        // Adiciona novas mensagens ao painel de chat
        {
            flpChat.SuspendLayout();
            foreach (DataRow row in novasMensagens.Rows)
            {
                AdicionarMensagemAoChat(row);
            }
            _ultimaMensagemId = Convert.ToInt64(novasMensagens.Rows[novasMensagens.Rows.Count - 1]["id"]);
            // Atualiza o ID da última mensagem
            flpChat.ResumeLayout();
            ScrollToBottom();
        }

        private void AdicionarMensagemAoChat(DataRow row)
        {
            
            Panel postagemPanel = new Panel();
            postagemPanel.AutoSize = true;
            postagemPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            postagemPanel.BorderStyle = BorderStyle.FixedSingle;
            postagemPanel.Margin = new Padding(5);
            postagemPanel.MaximumSize = new Size(flpChat.ClientSize.Width - 10, 0);
            postagemPanel.MinimumSize = new Size(flpChat.ClientSize.Width - 10, 0);

            string mensagem = row["mensagem"].ToString();
            string caminhoFoto = row["caminho_foto"].ToString();
            string nomeUsuario = row["nome_usuario"].ToString();

            TableLayoutPanel contentLayout = new TableLayoutPanel();
            contentLayout.AutoSize = true;
            contentLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            contentLayout.ColumnCount = 1;
            contentLayout.RowCount = 3;
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            contentLayout.Padding = new Padding(5);
            contentLayout.Margin = new Padding(0);

            Label lblUsuario = new Label();
            lblUsuario.Text = nomeUsuario + " (" + Convert.ToDateTime(row["data_postagem"]).ToString("HH:mm") + ")";
            lblUsuario.Font = new Font(lblUsuario.Font, FontStyle.Bold);
            lblUsuario.AutoSize = true;
            lblUsuario.Margin = new Padding(0, 0, 0, 5);
            contentLayout.Controls.Add(lblUsuario, 0, 0);

            int currentRow = 1;

            if (!string.IsNullOrEmpty(caminhoFoto) && File.Exists(caminhoFoto))
            {
                PictureBox pb = new PictureBox();
                try
                {
                    using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
                    {
                        pb.Image = Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao carregar imagem '{caminhoFoto}' para a mensagem: {ex.Message}");
                    pb.Image = null;
                }
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Size = new Size(150, 150);
                pb.Margin = new Padding(0, 0, 0, 5);
                contentLayout.Controls.Add(pb, 0, currentRow);
                currentRow++;
            }

            if (!string.IsNullOrEmpty(mensagem))
            {
                Label lblMensagem = new Label();
                lblMensagem.Text = mensagem;
                lblMensagem.AutoSize = true;
                lblMensagem.MaximumSize = new Size(postagemPanel.MaximumSize.Width - 10, 0);
                lblMensagem.Margin = new Padding(0);
                contentLayout.Controls.Add(lblMensagem, 0, currentRow);
                currentRow++;
            }

            contentLayout.RowCount = currentRow;
            // Adiciona o layout de conteúdo ao painel de postagem, que é então adicionado ao FlowLayoutPanel do chat.
            postagemPanel.Controls.Add(contentLayout);
            
            flpChat.Controls.Add(postagemPanel);
        }

        private async void btnEnviar_Click_1(object sender, EventArgs e)
        // Esse evento  é reponsavel por enviar a mensagem digitada no campo de texto.
        {
            string mensagem = txtMensagem.Text.Trim();
            // Valida se a mensagem ou a foto existe antes de enviar.

            if (string.IsNullOrEmpty(mensagem) && string.IsNullOrEmpty(_caminhoFotoUpload))
            // A variável _caminhoFotoUpload é definida no evento de clique da PictureBox.
            {
                MessageBox.Show("Você precisa digitar uma mensagem ou selecionar uma foto para enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Copia a foto para o diretório de destino se houver uma selecionada
                string caminhoFotoSalva = "";
                if (!string.IsNullOrEmpty(_caminhoFotoUpload))
                // Processa e salva a foto, se uma foi selecionada.
                {
                    string pastaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Chat_Fotos");
                    if (!Directory.Exists(pastaDestino))
                    // Cria o diretório de destino se ele não existir.
                    {
                        Directory.CreateDirectory(pastaDestino);
                    }
                    string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(_caminhoFotoUpload);
                    caminhoFotoSalva = Path.Combine(pastaDestino, nomeArquivo);
                    File.Copy(_caminhoFotoUpload, caminhoFotoSalva, true);
                }

                await _chatService.PostarMensagemAsync(_usuarioId, mensagem, caminhoFotoSalva);

                txtMensagem.Clear();
                _caminhoFotoUpload = null;
                // Opcional: limpa a PictureBox de upload
                // pbFotoUpload.Image = null; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar a mensagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbFotoUpload_Click(object sender, EventArgs e)
        // Evento disparado ao clicar na PictureBox para selecionar uma imagem
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Arquivos|*.*";
            openFileDialog.Title = "Selecione uma imagem para o chat";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _caminhoFotoUpload = openFileDialog.FileName;

                try
                {
                    pbFotoUpload.Image = Image.FromFile(_caminhoFotoUpload);
                    pbFotoUpload.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _caminhoFotoUpload = null;
                }
            }
        }

        private void pbFotoUpload_Click_1(object sender, EventArgs e)
        // Evento disparado ao clicar na PictureBox para selecionar uma imagem
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Arquivos|*.*";
            openFileDialog.Title = "Selecione uma imagem para o chat";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Armazena o caminho do arquivo selecionado em uma variável de classe.
                _caminhoFotoUpload = openFileDialog.FileName;

                try
                {
                    // Tenta carregar a imagem na PictureBox para pré-visualização.
                    pbFotoUpload.Image = Image.FromFile(_caminhoFotoUpload);
                    pbFotoUpload.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _caminhoFotoUpload = null; // Limpa o caminho se o carregamento falhar.
                }
            }
        }

        
            private async void btnEnviar_Click(object sender, EventArgs e)
        {
            // Obtém a mensagem do campo de texto, removendo espaços em branco no início e no fim.
            string mensagem = txtMensagem.Text.Trim();

            // Valida se a mensagem ou a foto existe antes de enviar.
            // A variável _caminhoFotoUpload é definida no evento de clique da PictureBox.
            if (string.IsNullOrEmpty(mensagem) && string.IsNullOrEmpty(_caminhoFotoUpload))
            {
                MessageBox.Show("Você precisa digitar uma mensagem ou selecionar uma foto para enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string caminhoFotoSalva = "";

                //  Processa e salva a foto, se uma foi selecionada.
                if (!string.IsNullOrEmpty(_caminhoFotoUpload))
                {
                    // Cria o diretório de destino se ele não existir.
                    string pastaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Chat_Fotos");
                    if (!Directory.Exists(pastaDestino))
                    {
                        Directory.CreateDirectory(pastaDestino);
                    }

                    // Cria um nome de arquivo único para evitar conflitos.
                    string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(_caminhoFotoUpload);
                    caminhoFotoSalva = Path.Combine(pastaDestino, nomeArquivo);

                    // Copia o arquivo da origem para o destino.
                    File.Copy(_caminhoFotoUpload, caminhoFotoSalva, true);
                }

                // Posta a mensagem no banco de dados.
                // O _usuarioId é o ID do usuário logado, passado no construtor da tela.
                await _chatService.PostarMensagemAsync(_usuarioId, mensagem, caminhoFotoSalva);

                //  Limpa os campos após o envio.
                txtMensagem.Clear();
                _caminhoFotoUpload = null;

               
            }
            catch (Exception ex)
            {
                // Trata qualquer erro que possa ocorrer durante o processo de envio.
                MessageBox.Show($"Ocorreu um erro ao enviar a mensagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navega de volta para a tela do jardim
            Jardim volt = new Jardim(_usuarioId);           
            this.Hide();
            volt.Show();

        }

        private void ChatGlobal_Load(object sender, EventArgs e)
        {

        }
    }
    
}
