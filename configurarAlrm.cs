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
    public partial class configurarAlrm : Form
    {
        private int _usuarioId;
        public configurarAlrm(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
            _usuarioId = usuarioId;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CONFIGURAÇÃO DE ALARME DEFINIDA COM SUCESSO");
            Jardim volt = new Jardim(_usuarioId);
            this.Hide();
            volt.Show();
        }

        private void configurarAlrm_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Jardim volt = new Jardim(_usuarioId);
            this.Hide();
            volt.Show();
        }
    }
}
