using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class GameSession
    {
        [Key]
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }

    }
}
