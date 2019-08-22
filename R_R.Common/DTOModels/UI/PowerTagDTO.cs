using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.DTOModels.UI
{
    public class PowerTagDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBroad { get; set; }
        public bool IsBurned { get; set; }
        public string QuestionAnswered { get; set; }
    }
}
