using System.Collections.Generic;
using alterdata.api.Shared.Enums;

namespace alterdata.api.Shared.Utils
{
    public class FusoHorarioUtils
    {
        public Dictionary<EstadosBrasileirosEnum, FusoHorarioBrasileiroEnum> dicionario 
            = new Dictionary<EstadosBrasileirosEnum, FusoHorarioBrasileiroEnum>();

        public FusoHorarioUtils()
        {
            this.dicionario.Add(EstadosBrasileirosEnum.ES, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.GO, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.MG, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.PR, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.RJ, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.RS, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.SC, FusoHorarioBrasileiroEnum.Brasilia);
            this.dicionario.Add(EstadosBrasileirosEnum.SP, FusoHorarioBrasileiroEnum.Brasilia);

            this.dicionario.Add(EstadosBrasileirosEnum.AL, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.AP, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.BA, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.CE, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.MA, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.MT, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.MS, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.PA, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.PB, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.PE, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.PI, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.RN, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.SE, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.TO, FusoHorarioBrasileiroEnum.Amazonia);

            this.dicionario.Add(EstadosBrasileirosEnum.AM, FusoHorarioBrasileiroEnum.Acre);
            this.dicionario.Add(EstadosBrasileirosEnum.RO, FusoHorarioBrasileiroEnum.Acre);
            this.dicionario.Add(EstadosBrasileirosEnum.RR, FusoHorarioBrasileiroEnum.Amazonia);
            this.dicionario.Add(EstadosBrasileirosEnum.AC, FusoHorarioBrasileiroEnum.Acre);
        }
        
    }
}