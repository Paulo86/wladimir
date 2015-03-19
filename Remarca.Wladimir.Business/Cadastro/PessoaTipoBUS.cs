using System;
using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;

namespace Remarca.Wladimir.Business.Cadastro
{
    public class PessoaTipoBUS
    {
        /// <PessoaLista>
        /// Retorna uma lista do tipo PessoaTipoMOD
        /// </PessoaLista>
        /// <returns></returns>
        public PessoaTipoListaMOD ListaTipoPessoa()
        {
            try
            {
                //Criamos uma variável apontando para a Classe TipoPessoaREP
                var repositorio = new TipoPessoaREP();

                //Retornamos para o método o método ListaTipoPessoa
                return repositorio.ListaTipoPessoa();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
