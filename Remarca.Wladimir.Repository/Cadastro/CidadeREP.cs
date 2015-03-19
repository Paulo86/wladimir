using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
   public class CidadeREP
    {
       /// <ListaCidade>
       /// Retorna uma lista de Cidades amarradas á um estado
        /// </ListaCidade>
       /// <param name="CodigoEstado"></param>
       /// <returns></returns>
       public CidadeListaMOD ListaCidade(Int32 CodigoEstado)
       {
           try
           {
               //Criamos uma variavel apontando para a classe CidadeListaMOD que recebe uma Lista de Cidades
               var Lista = new CidadeListaMOD();

               //Criamos uma variável que aponta para a classe AcessaBancoDadosSqlServer que conecta no banco
               var conexao = new AcessaBancoSqlServer();
               
               //Adicionamos os parametros no comando
               conexao.AdicionarParametros("@ID_ESTADO", CodigoEstado);

               //Adicionamos as cidades na variável Lista
               foreach (DataRow Cidade in conexao.Pesquisar("USP_TB_CIDADE_LISTA_POR_ESTADO").Rows)
               {
                   Lista.Add(new CidadeMOD {
                       CodigoCidade = Convert.ToInt32(Cidade["ID_CIDADE"]),
                       NomeCidade = Cidade["NM_CIDADE"].ToString()
                   });
               }

               //Retornamos a lista preenchida com os dados para o método
               return Lista;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
