using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class MC
    {
        [Key]
        public int id { get; set; }
        public R_RUser User { get; set; }
        public int UserId { get; set; }
        public List<Game> Games { get; set; }

    }
}
