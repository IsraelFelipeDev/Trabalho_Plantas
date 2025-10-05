using App_Plantas.Services;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Plantas
{
    public partial class PerefilPlanta : Form
    {
        private int _plantaId;
        private int usuarioId;
        // Os dois construtores responsaveis por iniciar o formulario e receber o id da planta e usuario

        public PerefilPlanta()
        {
            InitializeComponent();
            this.Load += PerfilPlanta_Load;
            // Essa linha associa o evento Load ao método PerfilPlanta_Load
        }

        public PerefilPlanta(int plantaId,int usuarioId) : this()
        {
            _plantaId = plantaId;
            
            this.usuarioId = usuarioId;
        }

        private async void PerfilPlanta_Load(object sender, EventArgs e)
        {
            await CarregarDadosPlanta();
        }

        private async Task CarregarDadosPlanta()
        // Esse metodo carrega os dados da planta e faz a tradução
        {
            try
            {
                this.Enabled = false;

                PlantaService service = new PlantaService();
                var planta = await service.ConsultarPlantaPorIdAsync(_plantaId);
                // Aqui ele consulta a planta pelo id e armazena na variavel planta para posterior uso

                if (planta != null)
                {
                    // Instancia o serviço de tradução
                    TradutorService tradutor = new TradutorService();

                    // Preencher os rótulos e caixas de texto com os dados da planta
                    lbl_NomePopular.Text = await tradutor.TraduzirAsync(planta.NomePopular, "en", "pt");
                    lbl_NomeCientifico.Text = planta.NomeCientifico; 
                    lbl_Apelido.Text = planta.Apelido;
                    lbl_NomePopEsc.Text = await tradutor.TraduzirAsync(planta.NomePopular, "en", "pt");
                    lbl_NomeCientificoEsc.Text = planta.NomeCientifico; 
                    lbl_FamiliaEsc.Text = await tradutor.TraduzirAsync(planta.Familia, "en", "pt");
                    lbl_GeneroEsc.Text = await tradutor.TraduzirAsync(planta.Genero, "en", "pt");
                    lbl_ApelidoPlantEsc.Text = planta.Apelido;
                    lbl_DataAdicEsc.Text = planta.DataAdicao.ToShortDateString();
                    // Nesse bloco ele preenche os campos com os dados da planta, traduzindo alguns campos que são em ingles 
                    // passados pela Api de identificação da planta , mas aqui ele traduz para portugues atraves da Api de tradução;


                    // Chamar o serviço de tradução de forma assíncrona
                    string textoTraduzidoRega = await tradutor.TraduzirAsync(planta.FrequenciaRega, "en", "pt");
                    txtFrequenciaRega.Text = !string.IsNullOrEmpty(textoTraduzidoRega) ? textoTraduzidoRega : planta.FrequenciaRega;
                    Console.WriteLine($"Texto original: {planta.FrequenciaRega} | Texto traduzido: {textoTraduzidoRega}");
                    string textoTraduzidoSolo = await tradutor.TraduzirAsync(planta.TipoSolo, "en", "pt");
                    txtTipoSolo.Text = !string.IsNullOrEmpty(textoTraduzidoSolo) ? textoTraduzidoSolo : planta.TipoSolo;

                    string textoTraduzidoSol = await tradutor.TraduzirAsync(planta.NivelSol, "en", "pt");
                    txtNivelSol.Text = !string.IsNullOrEmpty(textoTraduzidoSol) ? textoTraduzidoSol : planta.NivelSol;
                    Console.WriteLine($"Texto original: {planta.TipoSolo} | Texto traduzido: {await tradutor.TraduzirAsync(planta.TipoSolo, "en", "pt")}");
                }
                else
                {
                    MessageBox.Show("Planta não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados da planta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

       

        

    private async void btn_ExcluirPlanta_Click(object sender, EventArgs e)
        {
            // Confirmação para o usuário antes de prosseguir para exclusão da planta.
            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja excluir esta planta? Esta ação não pode ser desfeita.",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    this.Enabled = false; // Desabilita o formulário para evitar cliques acidentais

                    PlantaService service = new PlantaService();
                    bool sucesso = await service.ExcluirPlantaAsync(_plantaId);

                    if (sucesso)
                    {
                        MessageBox.Show("Planta excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Fecha a tela de perfil após a exclusão
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir a planta. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar excluir a planta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Enabled = true; // Habilita o formulário novamente
                }
            }
        }

       

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            Jardim jardim = new Jardim(usuarioId); 
            this.Hide();
            jardim.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
    }
