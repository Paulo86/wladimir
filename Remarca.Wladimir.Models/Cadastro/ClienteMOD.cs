using System;

namespace Remarca.Wladimir.Models.Cadastro
{
    /// <ClienteMOD>
    /// Essa classe contem o modelo de dados do Cadastro de Clientes
    /// </ClienteMOD>
    public class ClienteMOD
    {
        public ClienteMOD()
        {
            PessoaTipo = new PessoaTipoMOD();
            CidadePrincipal = new CidadeMOD();
            CidadeCobranca = new CidadeMOD();
        }
        public Int32 CodigoCliente { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public PessoaTipoMOD PessoaTipo { get; set; }
        public String CpfCnpj { get; set; }
        public String RgIe { get; set; }
        public String EnderecoPrincipal { get; set; }
        public String NumeroEnderecoPrincipal { get; set; }
        public CidadeMOD CidadePrincipal { get; set; }
        public String CepEnderecoPrincipal { get; set; }
        public String BairroEnderecoPrincipal { get; set; }
        public String ComplementoPrincipal { get; set; }
        public CidadeMOD CidadeCobranca { get; set; }
        public String EnderecoCobranca { get; set; }
        public String NumeroEnderecoCobranca { get; set; }
        public String BairroEnderecoCobranca { get; set; }
        public String CepEnderecoCobranca { get; set; }
        public String ComplementoCobrança { get; set; }
        public String NomeContato { get; set; }
        public String TelefoneContatoCelular { get; set; }
        public String TelefonePrincipal { get; set; }
        public String TelefoneFax { get; set; }
        public String Status { get; set; }
        public String Email { get; set; }
        public String Observacao { get; set; }
    }
}
