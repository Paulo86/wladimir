using System;

namespace Remarca.Wladimir.Models.Cadastro
{
    public class ModeloEquipamentoMOD
    {
        public ModeloEquipamentoMOD()
        {
            TipoEquipamento = new TipoEquipamentoMOD();
            Marca = new MarcasMOD();
        }

        public int CodigoModeloEquipamento { get; set; }
        public String DescricaoModeloEquipamento { get; set; }

        public TipoEquipamentoMOD TipoEquipamento { get; set; }

        public MarcasMOD Marca { get; set; }
    }
}
