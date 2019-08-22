using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class HelpHurt
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int OtherCharacterId { get; set; }
        public Character OtherCharacter { get; set; }
        public int Help { get; set; }
        public int Hurt { get; set; }
    }
}
