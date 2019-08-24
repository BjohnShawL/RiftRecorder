using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class UserGame
    {
        public Game Game { get; set; }
        public int GameId { get; set; }
        public R_RUser User { get; set; }
        public string UserId { get; set; }
    }
}
