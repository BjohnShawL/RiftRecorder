using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class Identity
    {
        [Key]
        public int Id { get; set; }
        public List<LogosTheme> LogosThemes { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
