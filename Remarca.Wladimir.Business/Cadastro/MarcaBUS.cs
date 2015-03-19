using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;

namespace Remarca.Wladimir.Business.Cadastro
{
   public class MarcaBUS
    {
       public String Inserir(MarcasMOD Marcas)
       {
           try
           {
               var repositorio = new MarcasREP();
               return repositorio.Inserir(Marcas);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public MarcasMOD Detalhes(Int32 codigoMarca)
       {
           try
           {
               return new MarcasREP().Detalhes(codigoMarca);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public MarcasListaMOD marcalista()
       {
           try
           {
               return new MarcasREP().marcalista();
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public String Excluir(Int32 codigoMarca)
       {
           try
           {
               return new MarcasREP().Excluir(codigoMarca);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public String Atualizar(MarcasMOD marca)
       {
           try
           {
               return new MarcasREP().Atualizar(marca);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }

}
