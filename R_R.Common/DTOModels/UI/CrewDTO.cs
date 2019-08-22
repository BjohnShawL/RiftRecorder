using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.DTOModels.UI
{
    public class CrewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CharacterDTO> Members { get; set; }
        public List<PowerTagDTO> PowerTags { get; set; }
        public string Weakness { get; set; }
    }
}
