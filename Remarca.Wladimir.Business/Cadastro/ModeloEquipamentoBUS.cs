using System;
using Remarca.Wladimir.Models.Cadastro;
using Remarca.Wladimir.Repository.Cadastro;

namespace Remarca.Wladimir.Business.Cadastro
{
    public class ModeloEquipamentoBUS
    {
        public void ValidarDados(ModeloEquipamentoMOD modeloequipamento)
        {
            try
            {

                if (String.IsNullOrEmpty(modeloequipamento.DescricaoModeloEquipamento))
                    throw new Exception("Descrição do modelo de equipamento obrigatório!");

                else if (modeloequipamento.TipoEquipamento.CodigoTipoEquipamento == 0)
                    throw new Exception("Tipo de equipamento obrigatório!");

                else if (modeloequipamento.Marca.CodigoMarca == 0)
                    throw new Exception("Marca de equipamento obrigatória!");


            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Inserir(ModeloEquipamentoMOD modeloequipamento)
        {
            try
            {
                var repositorio = new ModeloEquipamentoREP();
                return repositorio.Inserir(modeloequipamento);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public String Atualizar(ModeloEquipamentoMOD modeloequipamento)
        {
            try
            {
                var repositorio = new ModeloEquipamentoREP();
                return repositorio.Atualizar(modeloequipamento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ModeloEquipamentoMOD Detalhes( Int32 CodigoModeloEquipamento)
        {
            try
            {
                var repositorio = new ModeloEquipamentoREP();
                return repositorio.Detalhes(CodigoModeloEquipamento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Excluir(Int32 CodigoModeloEquipamento)
        {
            try
            {
                var repositorio = new ModeloEquipamentoREP();
                return repositorio.Excluir(CodigoModeloEquipamento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ModeloEquipamentoListaMOD ModeloEquipamentoLista()
        {
            try
            {
                var repositorio = new ModeloEquipamentoREP();
                return repositorio.ModeloEquipamentoLista();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
           


    }
}
