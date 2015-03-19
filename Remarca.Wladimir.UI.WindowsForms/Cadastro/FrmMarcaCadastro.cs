using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Business.Cadastro;

namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmMarcaCadastro : Form
    {


        TipoAcao tipoacao = new TipoAcao();

        private MarcasMOD marca()
        {
            try
            {
                var marca = new MarcasMOD();
                marca.DescricaoMarca = this.txtDescricao.Text;
                if (this.txtCodigo.Text != String.Empty)
                {
                    marca.CodigoMarca = Convert.ToInt32(this.txtCodigo.Text);
                }
                return marca;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void carregartela(MarcasMOD marca)
        {
            try
            {
                this.txtDescricao.Text = marca.DescricaoMarca;
                this.txtCodigo.Text = marca.CodigoMarca.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmMarcaCadastro(TipoAcao acao, MarcasMOD marca)
        {
            InitializeComponent();

            tipoacao = acao;
            switch (acao)
            {
                case TipoAcao.Inserir:
                    this.lblTitulo.Text = "Cadastro de Marcas";
                    break;
                case TipoAcao.Atualizar:
                    this.lblTitulo.Text = "Atualização de Marcas";
                    this.txtCodigo.ReadOnly = true;
                    this.carregartela(marca);
                    break;
                case TipoAcao.Pesquisar:
                    this.txtCodigo.ReadOnly = true;
                    this.txtDescricao.ReadOnly = true;
                    break;
                default:
                    break;
            }
        }

        private void FrmMarcaCadastro_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                String retorno = "";

                if (tipoacao == TipoAcao.Inserir)
                {   
                    retorno = new MarcaBUS().Inserir(this.marca());
                    if (char.IsNumber(retorno, 0))
                    {
                        this.txtCodigo.Text = retorno;
                        MessageBox.Show("Marca cadastrada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception(retorno);
                    }
                }
                else if (tipoacao == TipoAcao.Atualizar)
                {
                    retorno = new MarcaBUS().Atualizar(this.marca());

                    if (char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Marca alterada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
