using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class Status
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Effect { get; set; }
        public bool IsPositive { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
