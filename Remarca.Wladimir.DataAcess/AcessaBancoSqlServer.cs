using System;
using System.Data;
using System.Data.SqlClient;

namespace Remarca.Wladimir.DataAcess
{
    /// <AcessoDados>
    /// Essa Classe é responsável por todas as conexões com obanco de dados 
    /// Fazendo o CRUD do sistema
    /// </AcessoDados>
    public class AcessaBancoSqlServer
    {
        /// <Conexao>
        /// Cria uma Nova conexao com SQL Sever
        /// </Conexao>
        /// <returns></returns>
        private SqlConnection CriaNovaConexao()
        {
            return new SqlConnection(Properties.Settings.Default.SistemaConnectionString);
        }

        /// <Parametros>
        /// 
        /// </Parametros>
        private SqlParameterCollection ParametrosComando = new SqlCommand().Parameters;

        /// <LimparParametros>
        /// Método para Limpar todos os parametros dentro da coleção (ParametrosComando)
        /// </LimparParametros>
        public void LimparParametro()
        {
            ParametrosComando.Clear();
        }

        /// <AddParametros>
        /// 
        /// </AddParametros>
        /// <param name="NomeParametro"></param>
        /// <param name="ValorParametro"></param>
        public void AdicionarParametros(String NomeParametro, object ValorParametro)
        {
            ParametrosComando.Add(new SqlParameter(NomeParametro, ValorParametro));
        }

        /// <Persistencia>
        /// Insere, Atualiza e Deleta no banco de dados
        /// </Persistencia>
        /// <param name="NomeProcedure"></param>
        /// <returns></returns>
        public String Persistencia(String NomeProcedure)
        {
            //Criamos a Conexão com o Banco
            SqlConnection conexao = CriaNovaConexao();

            //Criamos o Comando a partir do objeto 'conexao'
            SqlCommand comando = conexao.CreateCommand();

            //Informamos o Tipo de comando como PROCEDURE
            comando.CommandType = CommandType.StoredProcedure;

            //Informamos o nome da PROCEDURE usando o Parametro de entrado do método
            comando.CommandText = NomeProcedure;

            //Adicionar os parametros
            foreach (SqlParameter Parametros in ParametrosComando)
            {
                comando.Parameters.Add(new SqlParameter(Parametros.ParameterName, Parametros.Value));
            }

            try
            {
                //Abrimos a conexao
                conexao.Open();

                //Executamos o Comando e pegamos o retorno do banco de dados
                String retorno = comando.ExecuteScalar().ToString();

                //Fechamos a conexao com o banco
                conexao.Close();

                //Tiramos a conexão e o comando da Memória
                conexao.Dispose();
                comando.Dispose();

                //Retornamos a variável 'retorno' para o método
                return retorno;
            }
            catch (Exception erro)
            {
                return erro.Message;
            }

            finally
            {
                //Verificamos se a conexao esta aberta
                if (conexao.State == ConnectionState.Open)
                {
                    //Fechamos a conexao com o banco
                    conexao.Close();

                    //Tiramos a conexão e o comando da Memória
                    conexao.Dispose();
                    comando.Dispose();
                }
            }
        }

        /// <Pesquisa>
        /// Executa pesquisas no banco de dados
        /// </Pesquisa>
        /// <param name="NomeProcedure"></param>
        /// <returns></returns>
        public DataTable Pesquisar(String NomeProcedure)
        {
            //Criamos a Conexão com o Banco
            SqlConnection conexao = CriaNovaConexao();

            //Criamos o Comando a partir do objeto 'conexao'
            SqlCommand comando = conexao.CreateCommand();

            //Informamos o Tipo de comando como PROCEDURE
            comando.CommandType = CommandType.StoredProcedure;

            //Informamos o nome da PROCEDURE usando o Parametro de entrado do método
            comando.CommandText = NomeProcedure;

            //Adicionar os parametros
            foreach (SqlParameter Parametros in ParametrosComando)
            {
                comando.Parameters.Add(new SqlParameter(Parametros.ParameterName, Parametros.Value));
            }

            try
            {
                //Abrimos a conexao
                conexao.Open();

                //Criamos uma tabela vazia (DataTable) e jogamos todos os dados da consulta dentro dela
                DataTable tabela = new DataTable();
                SqlDataAdapter adaptadorDados = new SqlDataAdapter(comando);
                adaptadorDados.Fill(tabela);               

                //Fechamos a conexao com o banco
                conexao.Close();

                //Tiramos a conexão e o comando da Memória
                conexao.Dispose();
                comando.Dispose();

                //Retornamos a variável 'retorno' para o método
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                //Verificamos se a conexao esta aberta
                if (conexao.State == ConnectionState.Open)
                {
                    //Fechamos a conexao com o banco
                    conexao.Close();

                    //Tiramos a conexão e o comando da Memória
                    conexao.Dispose();
                    comando.Dispose();
                }
            }
        }
    }
}
