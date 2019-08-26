using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class CharacterLogos
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int LogosConceptId { get; set; }
        public LogosConcept LogosConcept { get; set; }
    }
}
