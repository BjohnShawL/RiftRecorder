using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace R_R.Common.Entities
{
    public class Character
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(80)]
        public String Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public int BuildupPoints { get; set; }
        
        public int CrewId { get; set; }
        public Crew Crew { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }


        public List<Status> Statuses { get; set; }
        public List<StoryTag> StoryTags { get; set; }

        
    }
}
