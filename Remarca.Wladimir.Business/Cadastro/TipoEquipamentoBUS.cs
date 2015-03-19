using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;

namespace Remarca.Wladimir.Business.Cadastro
{
   public class TipoEquipamentoBUS
    {
        public String Inserir(TipoEquipamentoMOD TipoEquipamento)
        {
            try
            {
                var repositorio = new TipoEquipamentoREP();
                return repositorio.Inserir(TipoEquipamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEquipamentoMOD Detalhes(Int32 CodigoTipoEquipamento)
        {
            try
            {
                return new TipoEquipamentoREP().Detalhes(CodigoTipoEquipamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEquipamentoListaMOD tipoequipamentolista()
        {
            try
            {
                return new TipoEquipamentoREP().tipoequipamentolista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Excluir(Int32 CodigoTipoEquipamento)
        {
            try
            {
                return new TipoEquipamentoREP().Excluir(CodigoTipoEquipamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Atualizar(TipoEquipamentoMOD tipoequipamento)
        {
            try
            {
                return new TipoEquipamentoREP().Atualizar(tipoequipamento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
