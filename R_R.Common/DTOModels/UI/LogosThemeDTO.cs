using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.DTOModels.UI
{
    public class LogosThemeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBurned { get; set; }
        public int Attention { get; set; }
        public int Crack { get; set; }
        public int Type { get; set; }
        public List<PowerTagDTO> PowerTags { get; set; }
    }
}
