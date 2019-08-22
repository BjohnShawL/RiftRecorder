using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.DTOModels.UI
{
    public class GameDTO
    {
        public int ID { get; set; }
        public string GameTitle { get; set; }
        public List<CharacterDTO> Characters { get; set; }
        public List<DateTime> Sessions { get; set; }
        public McDTO Mc { get; set; }
    }
}
