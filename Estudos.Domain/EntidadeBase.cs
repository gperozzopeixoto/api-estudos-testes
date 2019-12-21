using System;

namespace Estudos.Domain
{
    public class EntidadeBase
    {
        public int Codigo { get; set; }
        public DateTime DataInclusao{ get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}