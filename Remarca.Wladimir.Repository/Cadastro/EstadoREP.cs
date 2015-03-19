using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
    public class EstadoREP
    {
        /// <EstadoLista>
        /// Este método retorna uma Lista de Estados do tipo EstadoListaMOD
        /// </EstadoLista>
        /// <returns></returns>
        public EstadoListaMOD ListaEstado()
        {
            try
            {
                var Lista = new EstadoListaMOD();
                AcessaBancoSqlServer conexao = new AcessaBancoSqlServer();
                foreach (DataRow Estado in conexao.Pesquisar("USP_TB_ESTADO_LISTA").Rows)
                {
                    Lista.Add(new EstadoMOD
                    {
                        CodigoEstado = Convert.ToInt32(Estado["ID_ESTADO"]),
                        NomeEstado = Estado["NM_ESTADO"].ToString()
                    });
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
