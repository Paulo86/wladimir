using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
    public class ClienteREP
    {
        /// <ListaClienteGrid>
        /// Retorna uma lista de Clientes para o DataGridViwew principal   
        /// Chamado o método Pesquisar da camada Data Access.
        /// </ListaClienteGrid>
        /// <returns></returns>
        public ClienteListaMOD ListaClienteGrid()
        {
            try
            {                
                var lista = new ClienteListaMOD();                
                var conexao = new AcessaBancoSqlServer();                
                foreach (DataRow Cliente in conexao.Pesquisar("USP_TB_CLIENTE_SEL_GRID").Rows)
                {                    
                    lista.Add(new ClienteMOD
                    {
                        CodigoCliente = Convert.ToInt32(Cliente["ID_CLIENTE"]),
                        RazaoSocial = Cliente["NM_RAZAO_SOCIAL"].ToString(),
                        NomeFantasia = Cliente["NM_FANTASIA"].ToString(),
                        CpfCnpj = Cliente["NR_CPF_CNPJ"].ToString()
                    });
                }                
               
                return lista;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <Inserir>
        /// Método que Insere um novo cliente no Sistema 
        /// chamado o método de Persistencia da Classe de Acesso a banco de dados da camada Data Access.
        /// </Inserir>
        /// <param name="Cliente"></param>
        /// <returns></returns>
        public String Inserir(ClienteMOD Cliente)
        {           
            try
            {                
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@NM_RAZAO_SOCIAL", Cliente.RazaoSocial);
                conexao.AdicionarParametros("@NM_FANTASIA", Cliente.NomeFantasia);
                conexao.AdicionarParametros("@ID_PESSOA_TIPO", Cliente.PessoaTipo.CodigoTipoPessoa);
                conexao.AdicionarParametros("@NR_CPF_CNPJ", Cliente.CpfCnpj);
                conexao.AdicionarParametros("@NR_RG_IE", Cliente.RgIe);
                conexao.AdicionarParametros("@DS_ENDERECO_PRINCIPAL", Cliente.EnderecoPrincipal);
                conexao.AdicionarParametros("@NR_ENDERECO_PRINCIPAL", Cliente.NumeroEnderecoPrincipal);
                conexao.AdicionarParametros("@ID_CIDADE_ENDERECO_PRINCIPAL", Cliente.CidadePrincipal.CodigoCidade);
                conexao.AdicionarParametros("@NR_CEP_ENDERECO_PRINCIPAL", Cliente.CepEnderecoPrincipal);
                conexao.AdicionarParametros("@NM_BAIRRO_ENDERECO_PRINCIPAL", Cliente.BairroEnderecoPrincipal);
                conexao.AdicionarParametros("@DS_COMPLEMENTO_PRINCIPAL", Cliente.ComplementoPrincipal);
                conexao.AdicionarParametros("@DS_ENDERECO_COBRANCA", Cliente.EnderecoCobranca);
                conexao.AdicionarParametros("@NR_ENDERECO_COBRANCA", Cliente.NumeroEnderecoCobranca);
                conexao.AdicionarParametros("@NM_BAIRRO_ENDERECO_COBRANCA", Cliente.BairroEnderecoCobranca);
                conexao.AdicionarParametros("@NR_CEP_ENDERECO_COBRANCA", Cliente.CepEnderecoCobranca);
                conexao.AdicionarParametros("@DS_COMPLEMENTO_COBRANCA", Cliente.ComplementoCobrança);
                conexao.AdicionarParametros("@ID_CIDADE_ENDERECO_COBRANCA", Cliente.CidadeCobranca.CodigoCidade);
                conexao.AdicionarParametros("@NM_CONTATO", Cliente.NomeContato);
                conexao.AdicionarParametros("@NR_TELEFONE_CONTATO_CELULAR", Cliente.TelefoneContatoCelular);
                conexao.AdicionarParametros("@NR_TELEFONE_PRINCIPAL", Cliente.TelefonePrincipal);
                conexao.AdicionarParametros("@NR_TELEFONE_FAX", Cliente.TelefoneFax);
                conexao.AdicionarParametros("@DS_STATUS", Cliente.Status);
                conexao.AdicionarParametros("@DS_EMAIL", Cliente.Email);
                conexao.AdicionarParametros("@DS_OBSERVACAO", Cliente.Observacao);
                
                return conexao.Persistencia("USP_TB_CLIENTE_INS");
            }
                
            catch (Exception)
            {                
                throw;
            }
        }

        /// <Atualizar>
        /// Método para atualizar o cadastro de cliente:
        /// Esse método chama o método Persistencia da Classe de Acesso a banco de dados da camada Data Access.
        /// </Atualiza>
        /// <param name="Cliente"></param>
        /// <returns></returns>
        public String Atualizar(ClienteMOD Cliente)
        {
            try
            {
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@ID_CLIENTE", Cliente.CodigoCliente);
                conexao.AdicionarParametros("@NM_RAZAO_SOCIAL", Cliente.RazaoSocial);
                conexao.AdicionarParametros("@NM_FANTASIA", Cliente.NomeFantasia);
                conexao.AdicionarParametros("@ID_PESSOA_TIPO", Cliente.PessoaTipo.CodigoTipoPessoa);
                conexao.AdicionarParametros("@NR_CPF_CNPJ", Cliente.CpfCnpj);
                conexao.AdicionarParametros("@NR_RG_IE", Cliente.RgIe);
                conexao.AdicionarParametros("@DS_ENDERECO_PRINCIPAL", Cliente.EnderecoPrincipal);
                conexao.AdicionarParametros("@NR_ENDERECO_PRINCIPAL", Cliente.NumeroEnderecoPrincipal);
                conexao.AdicionarParametros("@ID_CIDADE_ENDERECO_PRINCIPAL", Cliente.CidadePrincipal.CodigoCidade);
                conexao.AdicionarParametros("@NR_CEP_ENDERECO_PRINCIPAL", Cliente.CepEnderecoPrincipal);
                conexao.AdicionarParametros("@NM_BAIRRO_ENDERECO_PRINCIPAL", Cliente.BairroEnderecoPrincipal);
                conexao.AdicionarParametros("@DS_COMPLEMENTO_PRINCIPAL", Cliente.ComplementoPrincipal);
                conexao.AdicionarParametros("@DS_ENDERECO_COBRANCA", Cliente.EnderecoCobranca);
                conexao.AdicionarParametros("@NR_ENDERECO_COBRANCA", Cliente.NumeroEnderecoCobranca);
                conexao.AdicionarParametros("@NM_BAIRRO_ENDERECO_COBRANCA", Cliente.BairroEnderecoCobranca);
                conexao.AdicionarParametros("@NR_CEP_ENDERECO_COBRANCA", Cliente.CepEnderecoCobranca);
                conexao.AdicionarParametros("@DS_COMPLEMENTO_COBRANCA", Cliente.ComplementoCobrança);
                conexao.AdicionarParametros("@ID_CIDADE_ENDERECO_COBRANCA", Cliente.CidadeCobranca.CodigoCidade);
                conexao.AdicionarParametros("@NM_CONTATO", Cliente.NomeContato);
                conexao.AdicionarParametros("@NR_TELEFONE_CONTATO_CELULAR", Cliente.TelefoneContatoCelular);
                conexao.AdicionarParametros("@NR_TELEFONE_PRINCIPAL", Cliente.TelefonePrincipal);
                conexao.AdicionarParametros("@NR_TELEFONE_FAX", Cliente.TelefoneFax);
                conexao.AdicionarParametros("@DS_STATUS", Cliente.Status);
                conexao.AdicionarParametros("@DS_EMAIL", Cliente.Email);
                conexao.AdicionarParametros("@DS_OBSERVACAO", Cliente.Observacao);

                return conexao.Persistencia("USP_TB_CLIENTE_UPD");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <ClienteSingle>
        /// Método para Pesquisar um Cliente:
        /// Este método retorna um Objeto do Tipo ClienteMOD preenchido com dados de um cliente
        /// Chamando o Método de Persistencia da Classe de Acesso a banco de dados da camada Data Access.
        /// </ClienteSingle>
        /// <param name="CodigoCliente"></param>
        /// <returns></returns>
        public ClienteMOD ClienteSingle(Int32 CodigoCliente)
        {
            try
            {
                var clienteMOD = new ClienteMOD();
                var conexao = new AcessaBancoSqlServer();
                conexao.AdicionarParametros("ID_CLIENTE", CodigoCliente);

                var dado = conexao.Pesquisar("USP_TB_CLIENTE_SEL").Rows[0];
                clienteMOD.RazaoSocial = dado["NM_RAZAO_SOCIAL"].ToString();
                clienteMOD.NomeFantasia = dado["NM_FANTASIA"].ToString();
                clienteMOD.PessoaTipo.CodigoTipoPessoa = Convert.ToInt32(dado["ID_PESSOA_TIPO"]);
                clienteMOD.CpfCnpj = dado["NR_CPF_CNPJ"].ToString();
                clienteMOD.RgIe = dado["NR_RG_IE"].ToString();
                clienteMOD.EnderecoPrincipal = dado["DS_ENDERECO_PRINCIPAL"].ToString();
                clienteMOD.NumeroEnderecoPrincipal = dado["NR_ENDERECO_PRINCIPAL"].ToString();
                clienteMOD.CidadePrincipal.Estado.CodigoEstado = Convert.ToInt32(dado["ID_ESTADO_PRINCIPAL"]);
                clienteMOD.CidadePrincipal.CodigoCidade = Convert.ToInt32(dado["ID_CIDADE_ENDERECO_PRINCIPAL"]);
                clienteMOD.CepEnderecoPrincipal = dado["NR_CEP_ENDERECO_PRINCIPAL"].ToString();
                clienteMOD.BairroEnderecoPrincipal = dado["NM_BAIRRO_ENDERECO_PRINCIPAL"].ToString();
                clienteMOD.ComplementoPrincipal = dado["DS_COMPLEMENTO_PRINCIPAL"].ToString();
                clienteMOD.EnderecoCobranca = dado["DS_ENDERECO_COBRANCA"].ToString();
                clienteMOD.NumeroEnderecoCobranca = dado["NR_ENDERECO_COBRANCA"].ToString();
                clienteMOD.BairroEnderecoCobranca = dado["NM_BAIRRO_ENDERECO_COBRANCA"].ToString();
                clienteMOD.CepEnderecoCobranca = dado["NR_CEP_ENDERECO_COBRANCA"].ToString();
                clienteMOD.ComplementoCobrança = dado["DS_COMPLEMENTO_COBRANCA"].ToString();
                clienteMOD.CidadeCobranca.Estado.CodigoEstado = Convert.ToInt32(dado["ID_ESTADO_COBRANCA"]);
                clienteMOD.CidadeCobranca.CodigoCidade = Convert.ToInt32(dado["ID_CIDADE_ENDERECO_COBRANCA"]);
                clienteMOD.NomeContato = dado["NM_CONTATO"].ToString();
                clienteMOD.TelefoneContatoCelular = dado["NR_TELEFONE_CONTATO_CELULAR"].ToString();
                clienteMOD.TelefonePrincipal = dado["NR_TELEFONE_PRINCIPAL"].ToString();
                clienteMOD.TelefoneFax = dado["NR_TELEFONE_FAX"].ToString();
                clienteMOD.Status = dado["DS_STATUS"].ToString();
                clienteMOD.Email = dado["DS_EMAIL"].ToString();
                clienteMOD.Observacao = dado["DS_OBSERVACAO"].ToString();
                clienteMOD.CodigoCliente = Convert.ToInt32(dado["ID_CLIENTE"]);
                
                return clienteMOD;                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <Excluir>
        /// Este método Excluir um registro de cliente do banco de dados
        /// Chamando o método de Persistencia da Classe de acesso a banco de dados da camada Data Access
        /// </Excluir>
        /// <param name="CodigoCliente"></param>
        /// <returns></returns>
        public String Excluir(Int32 CodigoCliente)
        {
            try
            {
                var conexao = new AcessaBancoSqlServer();
                conexao.AdicionarParametros("@ID_CLIENTE", CodigoCliente);
                return conexao.Persistencia("USP_TB_CLIENTE_DEL");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
