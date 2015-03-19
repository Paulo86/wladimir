using Remarca.Wladimir.Business.Cadastro;
using System;
using System.Windows.Forms;


namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmTipoEquipamento : Form
    {
        private void carregargrid()
        {
            try
            {
                this.gdvTipoEquipamento.DataSource = new TipoEquipamentoBUS().tipoequipamentolista();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public FrmTipoEquipamento()
        {
            InitializeComponent();
            this.gdvTipoEquipamento.AutoGenerateColumns = false;
            this.carregargrid();
        }


        private void btnIncluir_Click_1(object sender, EventArgs e)
        {
            try
            {

                FrmTipoEquipamentoCadastro frmTipoEquipamentoCadastro = new FrmTipoEquipamentoCadastro(TipoAcao.Inserir, null);
                DialogResult resposta = frmTipoEquipamentoCadastro.ShowDialog();
                this.carregargrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRetornar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var tipoequipamento = new TipoEquipamentoBUS().Detalhes(Convert.ToInt32(this.gdvTipoEquipamento.CurrentRow.Cells[0].Value));
                FrmTipoEquipamentoCadastro frmtipoEquipamento = new FrmTipoEquipamentoCadastro(TipoAcao.Atualizar, tipoequipamento);
                DialogResult resposta = frmtipoEquipamento.ShowDialog();
                this.carregargrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
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
                    String retorno = new TipoEquipamentoBUS().Excluir(Convert.ToInt32(this.gdvTipoEquipamento.CurrentRow.Cells[0].Value));

                    if (char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Tipo de Equipamento excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.carregargrid();
                    }
                    else { throw new Exception(retorno); }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
