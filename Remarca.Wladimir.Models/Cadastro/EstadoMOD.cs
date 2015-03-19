using System;

namespace Remarca.Wladimir.Models.Cadastro
{
    /// <EstadoMOD>
    /// Essa classe contem o modelo de dados do cadastro de Estados
    /// </EstadoMOD>
   public class EstadoMOD
    {
        public Int32 CodigoEstado { get; set; }
        public String NomeEstado { get; set; }
        public String UF { get; set; }
    }
}
