using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.EntitiyInterfaces;

namespace R_R.Common.Entities 
{
    public class MythosConcept :Iconcept
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<MythosTheme> MythosThemes { get; set; }


    }
}
