using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;
using System;

namespace Remarca.Wladimir.Business.Cadastro
{
   public class CidadeBUS
    {
       /// <CidadeNegocios>
       /// Retorna uma lista de cidade, tendo que passar um código de Estado
        /// </CidadeNegocios>
       /// <param name="CodigoEstado"></param>
       /// <returns></returns>
      public CidadeListaMOD ListaCidade(Int32 CodigoEstado)
       {
           try
           {
               //Criamos uma variável apontando para a classe CidadeREP
               var repositorio = new CidadeREP();

               //Retornamos os dados do método CidadeLista para este
               return repositorio.ListaCidade(CodigoEstado);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
