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
        public List<Character> Characters { get; set; }
        public List<DateTime> Sessions { get; set; }
        
        public MC MC { get; set; }
        public int McID { get; set; }
    }
}
