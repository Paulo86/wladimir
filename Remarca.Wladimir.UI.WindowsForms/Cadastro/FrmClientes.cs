using Remarca.Wladimir.Business.Cadastro;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmClientes : Form
    {
        /// <CarregaDataGridPrincipal>
        /// Esse método é utilizado sempre que precisamos carregar os dados no dataGridViewPrincipal
        /// </CarregaDataGridPrincipal>
        private void carregarGrid()
        {
            try
            {
                var negocios = new ClienteBUS();
                this.gdvPrincipal.DataSource = negocios.ListaClienteGrid();
                this.gdvPrincipal.Focus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <FrmClientes>
        /// Método construtor do Formulário.
        /// Neste método inicializamos os compomentes do formulário,
        /// configurações e Dados do DataGridPrincipal
        /// </FrmClientes>
        public FrmClientes()
        {
            InitializeComponent();
            try
            {
                this.gdvPrincipal.AutoGenerateColumns = false;
                this.carregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FrmClienteCadastro frmClienteCadastro = new FrmClienteCadastro(TipoAcao.Inserir, null);
            DialogResult resposta = frmClienteCadastro.ShowDialog();
            this.carregarGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var negocios = new ClienteBUS();
                var cliente = new ClienteMOD();
                cliente = negocios.ClienteSingle(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));

                FrmClienteCadastro frmClienteCadastro = new FrmClienteCadastro(TipoAcao.Atualizar, cliente);
                DialogResult resposta = frmClienteCadastro.ShowDialog();
                this.carregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resposta = MessageBox.Show("Confirma a Exclusão ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.No)
                    return;
                else
                {
                    var negocios = new ClienteBUS();
                    String retorno = negocios.Excluir(Convert.ToInt32(this.gdvPrincipal.Rows[0].Cells[0].Value));

                    if (char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Registro Excluido com Sucesso !", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.carregarGrid();
                    }
                    else { throw new Exception(retorno); }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvPrincipal.Rows.Count != 0)
                {
                    var negocios = new ClienteBUS();
                    var cliente = new ClienteMOD();
                    cliente = negocios.ClienteSingle(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));

                    FrmClienteCadastro frmClienteCadastro = new FrmClienteCadastro(TipoAcao.Pesquisar, cliente);
                    DialogResult resposta = frmClienteCadastro.ShowDialog();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
