using System;

namespace Remarca.Wladimir.Models.Cadastro
{
    /// <CidadeMOD>
    /// Contém os modelo de dados do cadastro de Cidade
    /// </CidadeMOD>
   public class CidadeMOD
    {
        public CidadeMOD()
        {
            Estado = new EstadoMOD();
        }
        public Int32 CodigoCidade { get; set; }
        public String NomeCidade { get; set; }
        public String CodigoIBGE { get; set; }
        public EstadoMOD Estado { get; set; }
    }
}
