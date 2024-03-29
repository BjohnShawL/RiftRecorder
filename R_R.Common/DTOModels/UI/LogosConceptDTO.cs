﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.DTOModels.UI
{
    public class LogosConceptDTO
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Identity { get; set; }
        public List<LogosThemeDTO> Themes { get; set; }
        public bool IsBurned { get; set; }
    }
}
