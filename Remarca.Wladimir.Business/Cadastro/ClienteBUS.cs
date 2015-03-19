using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;
using System;

namespace Remarca.Wladimir.Business.Cadastro
{
    /// <ClienteNegocios>
    /// Essa classe é reponsável por toda aregra de negócio relacionada ao cadastro de cliente
    /// </ClienteNegocios>
    public class ClienteBUS
    {
        /// <ListaCliente>
        /// Esse método retorna uma lista de Clientes 
        /// a partir do método ListaClienteREP da camada Repository.
        /// </ListaCliente>
        /// <returns></returns>
        public ClienteListaMOD ListaClienteGrid()
        {
            try
            {
                var repositorio = new ClienteREP();
                return repositorio.ListaClienteGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Inserir>
        /// Esse método Insere um novo registro dentro do banco de dados 
        /// Chamado o Método Inserir da Classe ClienteREP da camada Repository
        /// </Inserir>
        /// <param name="Cliente"></param>
        /// <returns></returns>
        public String Inserir(ClienteMOD Cliente)
        {
            try
            {
                var repositorio = new ClienteREP();
                return repositorio.Inserir(Cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Validar>
        /// Esse método faz as validações dos dados vindos da UI dentro do objeto ClienteMOD
        /// Antes de passar para os métodos que levam até o Repositório
        /// </Validar>
        /// <param name="Cliente"></param>
        public void Validar(ClienteMOD Cliente)
        {
            try
            {
                if (String.IsNullOrEmpty(Cliente.RazaoSocial))
                    throw new Exception("Razão Social é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.NomeFantasia))
                    throw new Exception("Nome Fantasia é Obrigatório !");
                else if (Cliente.PessoaTipo.CodigoTipoPessoa < 1)
                    throw new Exception("Tipo Pessoa é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.CpfCnpj))
                    throw new Exception("Cpf/Cnpj é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.RgIe))
                    throw new Exception("Rg/Ie é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.EnderecoPrincipal))
                    throw new Exception("Endereço Principal é Obrigatório !");
                else if (Cliente.CidadePrincipal.CodigoCidade < 1)
                    throw new Exception("Cidade do Endereço Principal é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.NumeroEnderecoPrincipal))
                    throw new Exception("Numero do Endereço Principal é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.CepEnderecoPrincipal))
                    throw new Exception("CEP do Endereço Principal é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.BairroEnderecoPrincipal))
                    throw new Exception("Bairro do Endereço Principal é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.NumeroEnderecoPrincipal))
                    throw new Exception("Numero do Endereço Principal é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.TelefonePrincipal))
                    throw new Exception("Numero de Telefone Principal é Obrigatório !");
                else if (String.IsNullOrEmpty(Cliente.Status))
                    throw new Exception("Status do Cliente é Obrigatório !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Atualizar>
        /// Este método Atualiza um registro de cadastro de cliente chamado O método
        /// da Atualizar da Classe CienteREP da camada Repository
        /// </Atualizar>
        /// <param name="Cliente"></param>
        /// <returns></returns>
        public String Atualizar(ClienteMOD Cliente)
        {
            try
            {
                var repositorio = new ClienteREP();
                return repositorio.Atualizar(Cliente);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <ClienteSingle>
        /// Este método retorna contém um Objteto ClienteMOD com dados vindos 
        /// do método ClienteSingle da Classe ClienteREP da camada Repository
        /// </ClienteSingle>
        /// <param name="CodigoCliente"></param>
        /// <returns></returns>
         public ClienteMOD ClienteSingle(Int32 CodigoCliente)
        {
            try
            {
                var repositorio = new ClienteREP();
                return repositorio.ClienteSingle(CodigoCliente);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <Excluir>
        /// Este método faz a chamada do método Excluir da classe ClienteREP
        /// da camada Repository responsável por excluir um registro.
        /// </Excluir>
        /// <param name="CodigoCliente"></param>
        /// <returns></returns>
         public String Excluir(Int32 CodigoCliente)
         {
             try
             {
                 var repositorio = new ClienteREP();
                 return repositorio.Excluir(CodigoCliente);

             }
             catch (Exception)
             {
                 
                 throw;
             }
         }
    }
}
