using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class StoryTag
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int JuiceCost { get; set; }
        public DateTime CreatedOn { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public int? CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
