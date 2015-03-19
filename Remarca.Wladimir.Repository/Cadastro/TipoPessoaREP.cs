using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
   public class TipoPessoaREP
    {
       /// <PessoaTipoLista>
       /// Retorna uma lista com os tipos de pessoa usando o método Pesquisar da Camada DataAccess       
       /// </PessoaTipoLista>
       /// <returns></returns>
       public PessoaTipoListaMOD ListaTipoPessoa()
       {
           try
           {
               //Criamos uma variavel apontando para a classe PessoaTipoListaMOD que recebe uma lista do tipo PessoaTipoMOD
               var Lista = new PessoaTipoListaMOD();

               //Criamos uma variável apontando para a Classe AcessaBancoDadosSqlServer que conecta no banco e executa a Persistencia/Pesquisa
               var conexao = new AcessaBancoSqlServer();

               //Adicionamos os dados a variável 'Lista'
               foreach (DataRow TipoPessoa in conexao.Pesquisar("USP_TB_PESSOA_TIPO_LISTA").Rows)
               {
                   Lista.Add(new PessoaTipoMOD {
                       CodigoTipoPessoa = Convert.ToInt32(TipoPessoa["ID_PESSOA_TIPO"]),
                       TipoPessoa = TipoPessoa["DS_PESSOA_TIPO"].ToString()
                   });
               }

               //Retornamos a variável 'Lista' preenchida para o método
               return Lista;
           }
           catch (Exception)
           {               
               throw;
           }
       }
    }
}
