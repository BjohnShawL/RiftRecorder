﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.EntitiyInterfaces;

namespace R_R.Common.Entities
{
    public class LogosConcept : Iconcept
    {
        [Key]
        public int Id { get; set; }
        public List<LogosTheme> LogosThemes { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
       
    }
}
