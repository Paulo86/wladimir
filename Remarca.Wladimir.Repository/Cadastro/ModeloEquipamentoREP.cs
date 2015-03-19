using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
    public class ModeloEquipamentoREP
    {
        public String Inserir(ModeloEquipamentoMOD modeloequipamento)
        {
            try
            {
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("DS_MODELO_EQUIPAMENTO", modeloequipamento.DescricaoModeloEquipamento);
                conexao.AdicionarParametros("ID_TIPO_EQUIPAMENTO", modeloequipamento.TipoEquipamento.CodigoTipoEquipamento);
                conexao.AdicionarParametros("ID_MARCA", modeloequipamento.Marca.CodigoMarca);

                return conexao.Persistencia("USP_MODELO_EQUIPAMENTO_INS");
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
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@DS_MODELO_EQUIPAMENTO", modeloequipamento.DescricaoModeloEquipamento);
                conexao.AdicionarParametros("@ID_MODELO_EQUIPAMENTO", modeloequipamento.CodigoModeloEquipamento);
                conexao.AdicionarParametros("@ID_TIPO_EQUIPAMENTO", modeloequipamento.TipoEquipamento.CodigoTipoEquipamento);
                conexao.AdicionarParametros("@ID_MARCA", modeloequipamento.Marca.CodigoMarca);

                return conexao.Persistencia("USP_MODELO_EQUIPAMENTO_UPD");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ModeloEquipamentoMOD Detalhes(Int32 CodigoModeloEquipamento)
        {
            try
            {
                var modeloequipamento = new ModeloEquipamentoMOD();
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@ID_MODELO_EQUIPAMENTO", CodigoModeloEquipamento);

                foreach (DataRow modelo in conexao.Pesquisar("USP_MODELO_EQUIPAMENTO_SEL").Rows)
                {
                    modeloequipamento.CodigoModeloEquipamento = Convert.ToInt32(modelo["ID_MODELO_EQUIPAMENTO"]);
                    modeloequipamento.DescricaoModeloEquipamento = modelo["DS_MODELO_EQUIPAMENTO"].ToString();
                    modeloequipamento.Marca.CodigoMarca = Convert.ToInt32(modelo["ID_MARCA"]);
                    modeloequipamento.TipoEquipamento.CodigoTipoEquipamento = Convert.ToInt32(modelo["ID_TIPO_EQUIPAMENTO"]);
                }
                return modeloequipamento;

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
                var lista = new ModeloEquipamentoListaMOD();

                var conexao = new AcessaBancoSqlServer();
                foreach (DataRow modelo in conexao.Pesquisar("USP_MODELO_EQUIPAMENTO_SEL_GRID").Rows)
                {
                    lista.Add(new ModeloEquipamentoMOD
                    {
                        CodigoModeloEquipamento = Convert.ToInt32(modelo["ID_MODELO_EQUIPAMENTO"]),
                        DescricaoModeloEquipamento = modelo["DS_MODELO_EQUIPAMENTO"].ToString(),
                        TipoEquipamento = new TipoEquipamentoMOD
                        {
                            DescricaoTipoEquipamento = modelo["DS_TIPO_EQUIPAMENTO"].ToString()
                        }
                    });
                }

                return lista;
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
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@ID_MODELO_EQUIPAMENTO", CodigoModeloEquipamento);

                return conexao.Persistencia("USP_MODELO_EQUIPAMENTO_DEL");

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
