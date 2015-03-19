using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Remarca.Wladimir.UI.WindowsForms.Cadastro;

namespace Remarca.Wladimir.UI.WindowsForms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            tsslDataHora.Text = "Data do Sistema: " + DateTime.Now.ToShortDateString();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca frmMarca = new FrmMarca();
            frmMarca.ShowDialog();
        }

        private void tipoEquipamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoEquipamento frmTipoEquipamento = new FrmTipoEquipamento();
            frmTipoEquipamento.ShowDialog();
        }

        private void modeloEquipamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModeloEquipamento frmModeloEquipamento = new FrmModeloEquipamento();
            frmModeloEquipamento.ShowDialog();
        }
    }
}
