using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(160)]
        public string GameTitle { get; set; }
        [Required, MaxLength(2048)]
        public string Description { get; set; }
        public List<Character> Characters { get; set; }
        public List<GameSession> Sessions { get; set; }
        public List<Crew> Crews { get; set; }
        public List<StoryTag> StoryTags { get; set; }
        public List<Note> Notes { get; set; }
        public MC MC { get; set; }
        public int McID { get; set; }


    }
}
