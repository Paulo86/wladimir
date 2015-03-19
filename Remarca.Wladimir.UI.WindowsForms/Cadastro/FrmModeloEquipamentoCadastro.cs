using Remarca.Wladimir.Business.Cadastro;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmModeloEquipamentoCadastro : Form
    {
        TipoAcao tipoAcao = new TipoAcao();

        private void CarregarComboBox()
        {
            try
            {
                this.cbbMarca.DisplayMember = "DescricaoMarca";
                this.cbbMarca.ValueMember = "CodigoMarca";
                this.cbbMarca.DataSource = new MarcaBUS().marcalista();
                this.cbbMarca.SelectedIndex = -1;

                this.cbbTipoEquipamento.DisplayMember = "DescricaoTipoEquipamento";
                this.cbbTipoEquipamento.ValueMember = "CodigoTipoEquipamento";
                this.cbbTipoEquipamento.DataSource = new TipoEquipamentoBUS().tipoequipamentolista();
                this.cbbTipoEquipamento.SelectedIndex = -1;
                    
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void CarregarDadosNaTela(ModeloEquipamentoMOD modeloEquipamento)
        {
            try
            {
                this.txtCodigo.Text = modeloEquipamento.CodigoModeloEquipamento.ToString();
                this.txtDescricao.Text = modeloEquipamento.DescricaoModeloEquipamento;
                this.cbbMarca.SelectedValue = modeloEquipamento.Marca.CodigoMarca;
                this.cbbTipoEquipamento.SelectedValue = modeloEquipamento.TipoEquipamento.CodigoTipoEquipamento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DesabilitarControles()
        {
            this.txtDescricao.ReadOnly = true;
            this.txtCodigo.ReadOnly = true;
            this.cbbMarca.Enabled = false;
            this.cbbTipoEquipamento.Enabled = false;
        }

        private ModeloEquipamentoMOD CarregarModeloEquipamento()
        {
            try
            {
                var modelo = new ModeloEquipamentoMOD();
                if (!this.txtCodigo.Text.Trim().Equals(String.Empty))
                    modelo.CodigoModeloEquipamento = Convert.ToInt32(this.txtCodigo.Text);

                modelo.DescricaoModeloEquipamento = this.txtDescricao.Text;
                modelo.Marca.CodigoMarca = Convert.ToInt32(this.cbbMarca.SelectedValue);
                modelo.TipoEquipamento.CodigoTipoEquipamento = Convert.ToInt32(this.cbbTipoEquipamento.SelectedValue);

                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmModeloEquipamentoCadastro(TipoAcao acao, ModeloEquipamentoMOD modeloEquipamento)
        {
            InitializeComponent();
            tipoAcao = acao;

            try
            {
                this.CarregarComboBox();

                switch (acao)
                {
                    case TipoAcao.Inserir:
                        this.lblTitulo.Text = "Cadastro de Modelo de Equipamento";
                        break;
                    case TipoAcao.Atualizar:
                        this.lblTitulo.Text = "Atualizar Cadastro de Modelo de Equipamento";
                        this.txtCodigo.ReadOnly = true;
                        this.CarregarDadosNaTela(modeloEquipamento);
                        break;
                    case TipoAcao.Pesquisar:
                        this.lblTitulo.Text = "Detalhes de Cadastro de Modelo de Equipamento";
                        this.CarregarDadosNaTela(modeloEquipamento);
                        this.DesabilitarControles();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = "";
                var negocios = new ModeloEquipamentoBUS();
                negocios.ValidarDados(this.CarregarModeloEquipamento());
                switch (tipoAcao)
                {
                    case TipoAcao.Inserir:
                        retorno = negocios.Inserir(this.CarregarModeloEquipamento());
                        if (Char.IsNumber(retorno, 0))
                        {
                            MessageBox.Show("Modelo de Equipamento Cadastrado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtCodigo.Text = retorno;
                            this.tipoAcao = TipoAcao.Atualizar;
                        }
                        else { throw new Exception(retorno); }
                        break;
                    case TipoAcao.Atualizar:
                        retorno = negocios.Atualizar(this.CarregarModeloEquipamento());
                        if (Char.IsNumber(retorno, 0))
                        {
                            MessageBox.Show("Modelo de Equipamento Atualizado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tipoAcao = TipoAcao.Atualizar;
                        }
                        else { throw new Exception(retorno); }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Grava Informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTipoEquipamento_Click(object sender, EventArgs e)
        {
            try
            {

                FrmTipoEquipamentoCadastro frmTipoEquipamentoCadastro = new FrmTipoEquipamentoCadastro(TipoAcao.Inserir, null);
                DialogResult resposta = frmTipoEquipamentoCadastro.ShowDialog();
                this.CarregarComboBox();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMarcaCadastro frmMarcaCadastro = new FrmMarcaCadastro(TipoAcao.Inserir, null);
                DialogResult resposta = frmMarcaCadastro.ShowDialog();
                this.CarregarComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
