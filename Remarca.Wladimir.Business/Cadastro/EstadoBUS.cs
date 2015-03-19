using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;
using System;

namespace Remarca.Wladimir.Business.Cadastro
{    
   public class EstadoBUS
    {
       /// <EstadoLista>
       /// Retorna uma lista de Estado do tipo EstadoMOD
       /// </EstadoLista>
       /// <returns></returns>
       public EstadoListaMOD ListaEstado()
       {
           try
           {
               //Criamos uma variável que aponta para a Classe EstadoREP
               var repositorio = new EstadoREP();

               //Retornamos o Método ListaEstado para este;
               return repositorio.ListaEstado();
           }
           catch (Exception)
           {

               throw;
           }
       }
    }
}
