using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.DTOModels.UI
{
    public class StatusDTO
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public int Effect { get; set; }
        public bool IsPositive { get; set; }
    }
}
