using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class StoryTag
    {
        public int Id { get; set; }
       public string Name { get; set; }
        public int JuiceCost { get; set; }
        public DateTime CreatedOn { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
