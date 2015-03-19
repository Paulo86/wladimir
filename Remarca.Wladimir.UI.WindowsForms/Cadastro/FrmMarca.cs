using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Remarca.Wladimir.Business.Cadastro;
using Remarca.Wladimir.Models.Cadastro;

namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmMarca : Form
    {
        private void carregargrid()
        {
            try
            {
                this.gdvMarcas.DataSource = new MarcaBUS().marcalista();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public FrmMarca()
        {
            InitializeComponent();
            this.gdvMarcas.AutoGenerateColumns = false;
            this.carregargrid();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {                
                FrmMarcaCadastro frmMarcaCadastro = new FrmMarcaCadastro(TipoAcao.Inserir, null);
                DialogResult resposta = frmMarcaCadastro.ShowDialog();
                this.carregargrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                var marca = new MarcaBUS().Detalhes(Convert.ToInt32(this.gdvMarcas.CurrentRow.Cells[0].Value));
                FrmMarcaCadastro frmMarcaCadastro = new FrmMarcaCadastro(TipoAcao.Atualizar, marca);
                DialogResult resposta = frmMarcaCadastro.ShowDialog();
                this.carregargrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resposta = MessageBox.Show("Confirma a exclusão?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta.Equals(DialogResult.No))
                {
                    return;
                }

                else
                {
                    String retorno = new MarcaBUS().Excluir (Convert.ToInt32(this.gdvMarcas.CurrentRow.Cells[0].Value));

                    if (char.IsNumber(retorno,0))
                    {
                        MessageBox.Show("Marca excluída com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.carregargrid();
                    }
                    else
                    {
                        throw new Exception(retorno);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
