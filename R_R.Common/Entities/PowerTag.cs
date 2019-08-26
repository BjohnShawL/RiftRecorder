using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class PowerTag
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(160)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public bool IsBroad { get; set; }
        public bool IsBurned { get; set; }
        public string QuestionAnswered { get; set; }

        public int? MythosThemeId { get; set; }
        public MythosTheme MythosTheme { get; set; }
        public int? LogosThemeId { get; set; }
        public LogosTheme LogosTheme { get; set; }
    }
}
