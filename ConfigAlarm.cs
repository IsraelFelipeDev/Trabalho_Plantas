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
    public partial class ConfigAlarm : Form
    {
        // 1. Adicione um campo privado para armazenar o ID do usuário
        private int _usuarioId;

        // 2. Modifique o construtor para receber o ID
        public ConfigAlarm(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId; // Armazena o ID
            Opacity = 1;
        }

        // Remova o construtor público sem parâmetros, pois ele não é usado corretamente

        // ... (seus outros métodos) ...

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            // Ao cancelar, cria o Jardim passando o ID armazenado
            Jardim volt = new Jardim(_usuarioId);
            this.Hide();
            volt.Show();
            // Opcional: Para liberar recursos, você pode usar this.Close(); ao invés de this.Hide();
        }

        private void btn_salvarAlt_Click(object sender, EventArgs e)
        {
            // Implementação mínima de retorno (SEM a lógica de salvar)
            // 1. Corrigindo o erro de sintaxe e o tipo de argumento do MessageBox
            MessageBox.Show("Rotina definida com sucesso.", "Configuração Salva", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 2. Cria o Jardim passando o ID armazenado
            Jardim volt = new Jardim(_usuarioId);
            this.Hide();
            volt.Show();
            // Opcional: Para liberar recursos, você pode usar this.Close(); ao invés de this.Hide();
        }
    }
}