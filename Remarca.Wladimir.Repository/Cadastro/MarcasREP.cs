using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remarca.Wladimir.DataAcess;
using Remarca.Wladimir.Models.Cadastro;
using System.Data;

namespace Remarca.Wladimir.Repository.Cadastro
{
    public class MarcasREP
    {
        public String Inserir(MarcasMOD Marca)
        {
            try
            {
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("@DS_MARCA", Marca.DescricaoMarca);

                return conexao.Persistencia("USP_MARCA_INS");

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
                var conexao = new AcessaBancoSqlServer();

                var marca = new MarcasMOD();
                conexao.AdicionarParametros("@ID_MARCA", codigoMarca);
                foreach (DataRow m in conexao.Pesquisar("USP_MARCA_SEL").Rows)
                {
                    marca.CodigoMarca = Convert.ToInt32(m["ID_MARCA"]);
                    marca.DescricaoMarca = m["DS_MARCA"].ToString();
                }
                return marca;
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
                var lista = new MarcasListaMOD();
                var conexao = new AcessaBancoSqlServer();
                foreach (DataRow marca in conexao.Pesquisar("USP_MARCA_SEL_GRID").Rows)
                {
                    lista.Add(new MarcasMOD {
                     CodigoMarca = Convert.ToInt32(marca["ID_MARCA"]),
                     DescricaoMarca = marca["DS_MARCA"].ToString()                    
                    });
                }
                
                return lista;


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
                var conexao = new AcessaBancoSqlServer();
                conexao.AdicionarParametros("ID_MARCA", codigoMarca);
                return conexao.Persistencia("USP_MARCA_DEL");
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
                var conexao = new AcessaBancoSqlServer();
                conexao.LimparParametro();
                conexao.AdicionarParametros("ID_MARCA",marca.CodigoMarca);
                conexao.AdicionarParametros("DS_MARCA", marca.DescricaoMarca);
                return conexao.Persistencia("USP_MARCA_UPD");

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

}
