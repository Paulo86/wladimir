using Remarca.Wladimir.Business.Cadastro;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Linq;
using System.Windows.Forms;


namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmModeloEquipamento : Form
    {
        private void CarregarGrid()
        {
            try
            {
                ModeloEquipamentoListaMOD lista = new ModeloEquipamentoBUS().ModeloEquipamentoLista();
                this.gdvModeloEquipamento.DataSource = lista.Select(x => new
                {
                    CodigoModeloEquipamento = x.CodigoModeloEquipamento,
                    DescricaoModeloEquipamento = x.DescricaoModeloEquipamento,                    
                    DescricaoTipoEquipamento = x.TipoEquipamento.DescricaoTipoEquipamento
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ModeloEquipamentoMOD CarregarModeloEquipamento()
        {
            try
            {
                return new ModeloEquipamentoBUS().Detalhes(Convert.ToInt32(this.gdvModeloEquipamento.CurrentRow.Cells[0].Value));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmModeloEquipamento()
        {
            InitializeComponent();
            try
            {
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                FrmModeloEquipamentoCadastro frmModeloEquipamentoCadastro = new FrmModeloEquipamentoCadastro(TipoAcao.Inserir, null);
                frmModeloEquipamentoCadastro.ShowDialog();
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmModeloEquipamentoCadastro frmModeloEquipamentoCadastro = new FrmModeloEquipamentoCadastro(TipoAcao.Atualizar, this.CarregarModeloEquipamento());
                frmModeloEquipamentoCadastro.ShowDialog();
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmModeloEquipamentoCadastro frmModeloEquipamentoCadastro = new FrmModeloEquipamentoCadastro(TipoAcao.Pesquisar, this.CarregarModeloEquipamento());
                frmModeloEquipamentoCadastro.ShowDialog();
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respota = MessageBox.Show("Confirma a exclusão deste registro ?", "Responda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respota.Equals(DialogResult.No))
                    return;
                else
                {
                    String retorno = new ModeloEquipamentoBUS().Excluir(Convert.ToInt32(this.gdvModeloEquipamento.CurrentRow.Cells[0].Value));
                    if (!Char.IsNumber(retorno, 0))
                        throw new Exception(retorno);
                    else
                    {
                        MessageBox.Show("Registro Excluido com Sucesso !", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CarregarGrid();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
