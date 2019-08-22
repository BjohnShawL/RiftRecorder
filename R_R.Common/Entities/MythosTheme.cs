﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class MythosTheme
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(160)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public bool IsBurned { get; set; }
        public int Attention { get; set; }
        public int Fade { get; set; }
        public int Type { get; set; }
        public List<PowerTag> PowerTags { get; set; }

        public int RiftId { get; set; }
        public Rift Rift { get; set; }
    }
}