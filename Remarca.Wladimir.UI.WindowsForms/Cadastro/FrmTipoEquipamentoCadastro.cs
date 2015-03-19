using Remarca.Wladimir.Business.Cadastro;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmTipoEquipamentoCadastro : Form
    {
        TipoAcao tipoacao = new TipoAcao();

        private TipoEquipamentoMOD tipoequipamento()
        {
            try
            {
                var tipoequipamento = new TipoEquipamentoMOD();
                tipoequipamento.DescricaoTipoEquipamento = this.txtDescricao.Text;
                if (this.txtCodigo.Text != String.Empty)
                {
                    tipoequipamento.CodigoTipoEquipamento = Convert.ToInt32(this.txtCodigo.Text);
                }
                return tipoequipamento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void carregartela(TipoEquipamentoMOD tipoequipamento)
        {
            try
            {
                this.txtDescricao.Text = tipoequipamento.DescricaoTipoEquipamento;
                this.txtCodigo.Text = tipoequipamento.CodigoTipoEquipamento.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmTipoEquipamentoCadastro(TipoAcao acao, TipoEquipamentoMOD tipoequipamento)
        {
            InitializeComponent();

            tipoacao = acao;
            switch (acao)
            {
                case TipoAcao.Inserir:
                    this.lblTitulo.Text = "Cadastro de Tipos de Equipamentos";
                    break;
                case TipoAcao.Atualizar:
                    this.lblTitulo.Text = "Atualização de Tipos de Equipamentos";
                    this.txtCodigo.ReadOnly = true;
                    this.carregartela(tipoequipamento);
                    break;
                case TipoAcao.Pesquisar:
                    this.txtCodigo.ReadOnly = true;
                    this.txtDescricao.ReadOnly = true;
                    break;
                default:
                    break;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                String retorno = "";

                if (tipoacao == TipoAcao.Inserir)
                {
                    retorno = new TipoEquipamentoBUS().Inserir(this.tipoequipamento());
                    if (char.IsNumber(retorno, 0))
                    {
                        this.txtCodigo.Text = retorno;
                        MessageBox.Show("Tipo de equipamento cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception(retorno);
                    }
                }
                else if (tipoacao == TipoAcao.Atualizar)
                {
                    retorno = new TipoEquipamentoBUS().Atualizar(this.tipoequipamento());

                    if (char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Tipo de equipamento alterado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
