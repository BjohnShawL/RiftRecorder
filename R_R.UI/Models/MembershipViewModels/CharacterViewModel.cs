using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.DTOModels.UI;

namespace R_R.UI.Models.MembershipViewModels
{
    public class CharacterViewModel
    {
        public CharacterDTO Character { get; set; }
        public RiftDTO Rift { get; set; }
        public IdentityDTO Identity { get; set; }
        public GameDTO Game { get; set; }
        public IEnumerable<NoteDTO> Notes { get; set; }
        public CrewDTO Crew { get; set; }
    }
}
