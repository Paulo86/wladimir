using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
   public class TipoEquipamentoREP
    {
        public String Inserir(TipoEquipamentoMOD Marca)
        {
            try
            {
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@DS_TIPO_EQUIPAMENTO", Marca.DescricaoTipoEquipamento);

                return conexao.Persistencia("USP_TIPO_EQUIPAMENTO_INS");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEquipamentoMOD Detalhes(Int32 codigoTipoEquipamento)
        {
            try
            {
                var conexao = new AcessaBancoSqlServer();

                var tipoequipamento = new TipoEquipamentoMOD();
                conexao.AdicionarParametros("@ID_TIPO_EQUIPAMENTO", codigoTipoEquipamento);
                foreach (DataRow e in conexao.Pesquisar("USP_TIPO_EQUIPAMENTO_SEL").Rows)
                {
                    tipoequipamento.CodigoTipoEquipamento = Convert.ToInt32(e["ID_TIPO_EQUIPAMENTO"]);
                    tipoequipamento.DescricaoTipoEquipamento = e["DS_TIPO_EQUIPAMENTO"].ToString();
                }
                return tipoequipamento;
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
                var lista = new TipoEquipamentoListaMOD();
                var conexao = new AcessaBancoSqlServer();
                foreach (DataRow equipamento in conexao.Pesquisar("USP_TIPO_EQUIPAMENTO_SEL_GRID").Rows)
                {
                    lista.Add(new TipoEquipamentoMOD
                    {
                        CodigoTipoEquipamento = Convert.ToInt32(equipamento["ID_TIPO_EQUIPAMENTO"]),
                        DescricaoTipoEquipamento = equipamento["DS_TIPO_EQUIPAMENTO"].ToString()
                    });
                }

                return lista;


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
                var conexao = new AcessaBancoSqlServer();
                conexao.AdicionarParametros("ID_TIPO_EQUIPAMENTO", CodigoTipoEquipamento);
                return conexao.Persistencia("USP_TIPO_EQUIPAMENTO_DEL");
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
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("ID_TIPO_EQUIPAMENTO", tipoequipamento.CodigoTipoEquipamento);
                conexao.AdicionarParametros("DS_TIPO_EQUIPAMENTO", tipoequipamento.DescricaoTipoEquipamento);
                return conexao.Persistencia("USP_TIPO_EQUIPAMENTO_UPD");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
