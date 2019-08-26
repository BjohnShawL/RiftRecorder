using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class CharacterMythos
    {
        public int MythosConceptId { get; set; }
        public MythosConcept MythosConcept { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
