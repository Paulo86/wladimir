using Remarca.Wladimir.Business.Cadastro;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Remarca.Wladimir.UI.WindowsForms.Cadastro
{
    public partial class FrmClienteCadastro : Form
    {
        #region Carregamento de ComboBox

        //Método para carregar o Tipo de pessoa
        private void CarregarTipoPessoa()
        {
            try
            {
                var negocios = new PessoaTipoBUS();

                this.cbbTipoPessoa.ValueMember = "CodigoTipoPessoa";
                this.cbbTipoPessoa.DisplayMember = "TipoPessoa";
                this.cbbTipoPessoa.DataSource = negocios.ListaTipoPessoa();
                this.cbbTipoPessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para carregar as Cidades
        private void CarregarCidade(Int32 CodigoEstado)
        {
            try
            {
                var negocios = new CidadeBUS();
                this.cbbCidadePrincipal.ValueMember = "CodigoCidade";
                this.cbbCidadePrincipal.DisplayMember = "NomeCidade";
                this.cbbCidadePrincipal.DataSource = negocios.ListaCidade(CodigoEstado);
                this.cbbCidadePrincipal.SelectedIndex = -1;

                this.cbbCidadeCobranca.ValueMember = "CodigoCidade";
                this.cbbCidadeCobranca.DisplayMember = "NomeCidade";
                this.cbbCidadeCobranca.DataSource = negocios.ListaCidade(CodigoEstado);
                this.cbbCidadeCobranca.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para carregar os Estados
        private void CarregarEstados()
        {
            try
            {
                //Carrega Estado principal
                var negocios = new EstadoBUS();
                this.cbbEstadoPrincipal.ValueMember = "CodigoEstado";
                this.cbbEstadoPrincipal.DisplayMember = "NomeEstado";
                this.cbbEstadoPrincipal.DataSource = negocios.ListaEstado();
                this.cbbEstadoPrincipal.SelectedIndex = -1;

                //Carrega estado cobrança
                this.cbbEstadoCobranca.ValueMember = "CodigoEstado";
                this.cbbEstadoCobranca.DisplayMember = "NomeEstado";
                this.cbbEstadoCobranca.DataSource = negocios.ListaEstado();
                this.cbbEstadoCobranca.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        /// <ClienteMOD>
        /// Esse método sempre que for chamado irá pegar os dados 
        /// dos componentes da tela e colocar dentro do DTO ClienteMOD
        /// </ClienteMOD>
        /// <returns></returns>
        private ClienteMOD Cliente()
        {
            var cliente = new ClienteMOD();
            cliente.RazaoSocial = this.txtRazaoSocial.Text;
            cliente.NomeFantasia = this.txtNomeFantasia.Text;
            cliente.NumeroEnderecoCobranca = this.txtNumeroCobranca.Text;
            cliente.NumeroEnderecoPrincipal = this.txtNumeroPrincipal.Text;
            cliente.Observacao = this.txtObservacao.Text;
            cliente.PessoaTipo.CodigoTipoPessoa = Convert.ToInt32(this.cbbTipoPessoa.SelectedValue);
            cliente.RgIe = this.txtRgIe.Text;
            cliente.CpfCnpj = this.txtCpfCnpj.Text;
            cliente.Status = this.cbbStatus.Text;
            cliente.TelefoneContatoCelular = this.txtCelular.Text;
            cliente.TelefoneFax = this.txtFax.Text;
            cliente.TelefonePrincipal = this.txtTelefone.Text;
            cliente.BairroEnderecoCobranca = this.txtBairroCobranca.Text;
            cliente.BairroEnderecoPrincipal = this.txtBairroPrincipal.Text;
            cliente.CepEnderecoCobranca = this.txtCepCobranca.Text;
            cliente.CepEnderecoPrincipal = this.txtCepPrincipal.Text;
            cliente.CidadeCobranca.CodigoCidade = Convert.ToInt32(this.cbbCidadeCobranca.SelectedValue);
            cliente.CidadePrincipal.CodigoCidade = Convert.ToInt32(this.cbbCidadePrincipal.SelectedValue);
            cliente.ComplementoCobrança = this.txtComplementoCobranca.Text;
            cliente.ComplementoPrincipal = this.txtComplemento.Text;
            cliente.Email = this.txtEmail.Text.ToLower();
            cliente.EnderecoCobranca = this.txtEndercoCobranca.Text;
            cliente.EnderecoPrincipal = this.txtEnderecoPrincipal.Text;
            cliente.NomeContato = this.txtContato.Text;
            if (!String.IsNullOrWhiteSpace(this.txtCodigo.Text))
                cliente.CodigoCliente = Convert.ToInt32(this.txtCodigo.Text);
            if (this.cbbCidadeCobranca.SelectedIndex == -1)
                cliente.CidadeCobranca.CodigoCidade = Convert.ToInt32(this.cbbCidadePrincipal.SelectedValue);

            return cliente;
        }

        /// <DesabilitaTodos>
        /// Este método sempre que for chamado irá desabilitar os componentes dos formulários
        /// </DesabilitaTodos>
        private void DesabilitaCampos()
        {
            this.txtCodigo.ReadOnly = true;
            this.txtRazaoSocial.ReadOnly = true;
            this.txtNomeFantasia.ReadOnly = true;
            this.txtEnderecoPrincipal.ReadOnly = true;
            this.txtEndercoCobranca.ReadOnly = true;
            this.txtEmail.ReadOnly = true;
            this.txtCpfCnpj.ReadOnly = true;
            this.txtContato.ReadOnly = true;
            this.txtCepPrincipal.ReadOnly = true;
            this.txtCepCobranca.ReadOnly = true;
            this.txtComplemento.ReadOnly = true;
            this.txtComplementoCobranca.ReadOnly = true;
            this.txtCelular.ReadOnly = true;
            this.txtBairroPrincipal.ReadOnly = true;
            this.txtBairroCobranca.ReadOnly = true;
            this.txtFax.ReadOnly = true;
            this.txtObservacao.ReadOnly = true;
            this.txtRgIe.ReadOnly = true;
            this.txtTelefone.ReadOnly = true;
            this.txtNumeroPrincipal.ReadOnly = true;
            this.txtNumeroCobranca.ReadOnly = true;
            this.cbbEstadoPrincipal.Enabled = false;
            this.cbbEstadoCobranca.Enabled = false;
            this.cbbCidadeCobranca.Enabled = false;
            this.cbbCidadePrincipal.Enabled = false;
            this.cbbStatus.Enabled = false;
            this.cbbTipoPessoa.Enabled = false;
        }

        //Enumerador que contem os tipo de ação no formulário.
        TipoAcao acao;

        /// <MétodoConstrutor>
        /// Inicializamos todos os componentes do Form
        /// Carregamos dependo da ação passada pela a tela de chamada iniciamos os comboBox e textBox
        /// já com dados do banco.
        /// </MétodoConstrutor>
        /// <param name="tipoAcao"></param>
        /// <param name="cliente"></param>
        public FrmClienteCadastro(TipoAcao tipoAcao, ClienteMOD cliente)
        {
            try
            {
                InitializeComponent();

                //Carregamos os dados nos comboBox abaixo
                this.CarregarTipoPessoa();
                this.CarregarEstados();

                acao = tipoAcao;
                switch (acao)
                {
                    #region Procedimentos no caso de Iserir
                    case TipoAcao.Inserir:
                        this.txtCodigo.Visible = false;
                        this.lblCodigo.Visible = false;
                        this.lblTitulo.Text = "Cadastro de Novo Cliente";
                        break;
                    #endregion

                    #region Procedimentos no caso de Atualização
                    case TipoAcao.Atualizar:
                        this.txtCodigo.ReadOnly = true;
                        this.lblTitulo.Text = "Atualizar Cadastro de Cliente";
                        this.txtCodigo.Text = cliente.CodigoCliente.ToString();
                        this.cbbStatus.Text = cliente.Status;
                        this.cbbTipoPessoa.SelectedValue = cliente.PessoaTipo.CodigoTipoPessoa;
                        this.txtRazaoSocial.Text = cliente.RazaoSocial;
                        this.txtNomeFantasia.Text = cliente.NomeFantasia;
                        this.txtEnderecoPrincipal.Text = cliente.EnderecoPrincipal;
                        this.txtEndercoCobranca.Text = cliente.EnderecoCobranca;
                        this.txtEmail.Text = cliente.Email;
                        this.txtCpfCnpj.Text = cliente.CpfCnpj;
                        this.txtContato.Text = cliente.NomeContato;
                        this.txtCepPrincipal.Text = cliente.CepEnderecoPrincipal;
                        this.txtCepCobranca.Text = cliente.CepEnderecoCobranca;
                        this.txtComplemento.Text = cliente.ComplementoPrincipal;
                        this.txtComplementoCobranca.Text = cliente.ComplementoCobrança;
                        this.txtCelular.Text = cliente.TelefoneContatoCelular;
                        this.txtBairroPrincipal.Text = cliente.BairroEnderecoPrincipal;
                        this.txtBairroCobranca.Text = cliente.BairroEnderecoCobranca;
                        this.txtFax.Text = cliente.TelefoneFax;
                        this.txtObservacao.Text = cliente.Observacao;
                        this.txtRgIe.Text = cliente.RgIe;
                        this.txtTelefone.Text = cliente.TelefonePrincipal;
                        this.txtNumeroPrincipal.Text = cliente.NumeroEnderecoPrincipal;
                        this.txtNumeroCobranca.Text = cliente.NumeroEnderecoCobranca;
                        this.cbbEstadoPrincipal.SelectedValue = cliente.CidadePrincipal.Estado.CodigoEstado;
                        this.CarregarCidade(cliente.CidadePrincipal.Estado.CodigoEstado);
                        this.cbbEstadoCobranca.SelectedValue = cliente.CidadeCobranca.Estado.CodigoEstado;
                        this.cbbCidadeCobranca.SelectedValue = cliente.CidadeCobranca.CodigoCidade;
                        this.cbbCidadePrincipal.SelectedValue = cliente.CidadePrincipal.CodigoCidade;                        
                        break;
                    #endregion

                    #region Procedimentos no caso de Pesquisa
                    case TipoAcao.Pesquisar:
                        this.SomenteLeitura();
                        this.lblTitulo.Text = "Detalhes do Cadastro de Cliente";
                        this.btnSalvar.Visible = false;
                        this.cbbStatus.Text = cliente.Status;
                        this.cbbTipoPessoa.SelectedValue = cliente.PessoaTipo.CodigoTipoPessoa;
                        this.txtCodigo.Text = cliente.CodigoCliente.ToString();
                        this.txtRazaoSocial.Text = cliente.RazaoSocial;
                        this.txtNomeFantasia.Text = cliente.NomeFantasia;
                        this.txtEnderecoPrincipal.Text = cliente.EnderecoPrincipal;
                        this.txtEndercoCobranca.Text = cliente.EnderecoCobranca;
                        this.txtEmail.Text = cliente.Email;
                        this.txtCpfCnpj.Text = cliente.CpfCnpj;
                        this.txtContato.Text = cliente.NomeContato;
                        this.txtCepPrincipal.Text = cliente.CepEnderecoPrincipal;
                        this.txtCepCobranca.Text = cliente.CepEnderecoCobranca;
                        this.txtComplemento.Text = cliente.ComplementoPrincipal;
                        this.txtComplementoCobranca.Text = cliente.ComplementoCobrança;
                        this.txtCelular.Text = cliente.TelefoneContatoCelular;
                        this.txtBairroPrincipal.Text = cliente.BairroEnderecoPrincipal;
                        this.txtBairroCobranca.Text = cliente.BairroEnderecoCobranca;
                        this.txtFax.Text = cliente.TelefoneFax;
                        this.txtObservacao.Text = cliente.Observacao;
                        this.txtRgIe.Text = cliente.RgIe;
                        this.txtTelefone.Text = cliente.TelefonePrincipal;
                        this.txtNumeroPrincipal.Text = cliente.NumeroEnderecoPrincipal;
                        this.txtNumeroCobranca.Text = cliente.NumeroEnderecoCobranca;
                        this.cbbEstadoPrincipal.SelectedValue = cliente.CidadePrincipal.Estado.CodigoEstado;
                        this.CarregarCidade(cliente.CidadePrincipal.Estado.CodigoEstado);
                        this.cbbEstadoCobranca.SelectedValue = cliente.CidadeCobranca.Estado.CodigoEstado;
                        this.cbbCidadeCobranca.SelectedValue = cliente.CidadeCobranca.CodigoCidade;
                        this.cbbCidadePrincipal.SelectedValue = cliente.CidadePrincipal.CodigoCidade;                        
                        this.toolStripButton1.Text = "&Retornar";
                        this.DesabilitaCampos();
                        break;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbCidadePrincipal_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe a Cidade do Endereço Principal";
            try
            {
                if (Convert.ToInt32(this.cbbEstadoPrincipal.SelectedValue) > 0)
                    this.CarregarCidade(Convert.ToInt32(this.cbbEstadoPrincipal.SelectedValue));
                else
                    return;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = this.Cliente();
                var negocios = new ClienteBUS();
                negocios.Validar(cliente);
                String retorno;

                if (acao == TipoAcao.Inserir)
                {
                    retorno = negocios.Inserir(cliente);
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Cliente Cadastrado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.DialogResult.Equals(DialogResult.Yes);
                    }
                    else
                        throw new Exception(retorno);
                }
                else if (acao == TipoAcao.Atualizar)
                {
                    retorno = negocios.Atualizar(cliente);
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Cliente Alterado com Sucesso ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.toolStripButton1.Text = "&Retornar";
                        this.DialogResult.Equals(DialogResult.Yes);
                    }
                    else
                        throw new Exception(retorno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar Cliente !\nDetalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult.Equals(DialogResult.No);
            }
        }

        private void cbbCidadePrincipal_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbEstadoPrincipal.SelectedIndex < 1)
                this.cbbEstadoCobranca.SelectedValue = this.cbbEstadoPrincipal.SelectedValue;

            else if (cbbCidadePrincipal.SelectedIndex < 1)
                this.cbbCidadeCobranca.SelectedValue = this.cbbCidadePrincipal.SelectedValue;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <TextoAjuda>
        /// Abaixo em todos os eventos ENTER dos componentes o sistema coloca na barra de roda pé
        /// as informações que devem ser inseridas no campo em foco
        /// </TextoAjuda>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Carregamento Texto de Ajuda
        private void cbbTipoPessoa_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Selecione o tipo de Pessoa";
        }

        private void cbbStatus_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Selecione o Status do Cliente";
        }

        private void txtRazaoSocial_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe a Razão Social";
        }

        private void txtNomeFantasia_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Nome Fantasia";
        }

        private void txtCpfCnpj_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o CPF ou CNPJ";
        }

        private void txtRgIe_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o RG ou IE";
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número do Telefone Principal";
        }

        private void txtFax_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número de Fax ou Telefone Secundário";
        }

        private void txtContato_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Nome do Contato";
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número de Celular do Contato";
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o E-mail do Cliente";
        }

        private void txtCepPrincipal_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número do CEP do Endereço Principal";
        }

        private void cbbEstadoPrincipal_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Estado do Endereço Principal";
        }

        private void txtEnderecoPrincipal_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe a Descrição o Endereço Principal";
        }

        private void txtBairroPrincipal_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Bairro do Endereço Principal";
        }

        private void txtNumeroPrincipal_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número do Endereço Principal";
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Complemento do Endereço Principal";
        }

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe as Observações do Cadastro do Cliente";
        }

        private void txtCepCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número do CEP do Endereço de Cobrança";
        }

        private void cbbEstadoCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Estado do Endereço de Cobrança";
        }

        private void txtEndercoCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe a Descrição o Endereço de Cobrança";
        }

        private void txtBairroCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Bairro do Endereço de Cobrança";
        }

        private void cbbCidadeCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe a Cidade do Endereço de Cobrança";
        }

        private void txtNumeroCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Número do Endereço de Cobrança";
        }

        private void txtComplementoCobranca_Enter(object sender, EventArgs e)
        {
            lblAjuda.Text = "Informe o Complemento do Endereço de Cobrança";
        }
        #endregion

        private void txtCpfCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else if (cbbTipoPessoa.SelectedIndex == -1)
            {
                e.Handled = true;
                cbbTipoPessoa.Focus();
                MessageBox.Show("Selecione o Tipo de Pessoa !", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                #region Mascara Dinamica para CNPJ

                if (cbbTipoPessoa.Text == "Jurídica" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtCpfCnpj.MaxLength = 18;
                    if (txtCpfCnpj.Text.Length == 2)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 3;
                    }
                    else if (txtCpfCnpj.Text.Length == 6)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 7;
                    }
                    else if (txtCpfCnpj.Text.Length == 10)
                    {
                        txtCpfCnpj.Text += '/';
                        txtCpfCnpj.SelectionStart = 11;
                    }
                    else if (txtCpfCnpj.Text.Length == 15)
                    {
                        txtCpfCnpj.Text += '-';
                        txtCpfCnpj.SelectionStart = 16;
                    }
                }

                #endregion

                #region Mascara Dinamica para CPF

                else if (cbbTipoPessoa.Text == "Física" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtCpfCnpj.MaxLength = 14;

                    if (txtCpfCnpj.Text.Length == 3)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 4;
                    }
                    else if (txtCpfCnpj.Text.Length == 7)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 8;
                    }
                    else if (txtCpfCnpj.Text.Length == 11)
                    {
                        txtCpfCnpj.Text += '-';
                        txtCpfCnpj.SelectionStart = 12;
                    }
                }

                #endregion
            }
        }

        private void cbbTipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtCpfCnpj.Clear();
            this.txtRgIe.Clear();
        }

        private void txtRgIe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else if (cbbTipoPessoa.SelectedIndex == -1)
            {
                e.Handled = true;
                cbbTipoPessoa.Focus();
                MessageBox.Show("Selecione o Tipo de Pessoa !", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                #region Mascara Dinamica para IE
                if (cbbTipoPessoa.Text == "Jurídica" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtRgIe.MaxLength = 15;
                    if (txtRgIe.Text.Length == 3)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 4;
                    }
                    else if (txtRgIe.Text.Length == 7)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 8;
                    }
                    else if (txtRgIe.Text.Length == 11)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 12;
                    }
                }
                #endregion

                #region Mascara Dinamica para RG
                else if (cbbTipoPessoa.Text == "Física" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtRgIe.MaxLength = 12;
                    if (txtRgIe.Text.Length == 2)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 3;
                    }
                    else if (txtRgIe.Text.Length == 6)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 7;
                    }
                    else if (txtRgIe.Text.Length == 10)
                    {
                        txtRgIe.Text += '-';
                        txtRgIe.SelectionStart = 11;
                    }
                }
                #endregion
            }
        }

        private void txtCepPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica para CEP
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtCepPrincipal.MaxLength = 9;
                if (txtCepPrincipal.Text.Length == 5)
                {
                    txtCepPrincipal.Text += '-';
                    txtCepPrincipal.SelectionStart = 6;
                }
            }
            #endregion
        }

        private void txtCepCobranca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica para CEP
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtCepCobranca.MaxLength = 9;
                if (txtCepCobranca.Text.Length == 5)
                {
                    txtCepCobranca.Text += '-';
                    txtCepCobranca.SelectionStart = 6;
                }
            }
            #endregion
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtTelefone.MaxLength = 13;
                if (txtTelefone.Text.Length == 0)
                {
                    txtTelefone.Text += '(';
                    txtTelefone.SelectionStart = 2;
                }
                else if (txtTelefone.Text.Length == 3)
                {
                    txtTelefone.Text += ')';
                    txtTelefone.SelectionStart = 4;
                }
                else if (txtTelefone.Text.Length == 8)
                {
                    txtTelefone.Text += '-';
                    txtTelefone.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtFax.MaxLength = 13;
                if (txtFax.Text.Length == 0)
                {
                    txtFax.Text += '(';
                    txtFax.SelectionStart = 2;
                }
                else if (txtFax.Text.Length == 3)
                {
                    txtFax.Text += ')';
                    txtFax.SelectionStart = 4;
                }
                else if (txtFax.Text.Length == 8)
                {
                    txtFax.Text += '-';
                    txtFax.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtCelular.MaxLength = 13;
                if (txtCelular.Text.Length == 0)
                {
                    txtCelular.Text += '(';
                    txtCelular.SelectionStart = 2;
                }
                else if (txtCelular.Text.Length == 3)
                {
                    txtCelular.Text += ')';
                    txtCelular.SelectionStart = 4;
                }
                else if (txtCelular.Text.Length == 8)
                {
                    txtCelular.Text += '-';
                    txtCelular.SelectionStart = 9;
                }
            }
            #endregion
        }
    }
}
