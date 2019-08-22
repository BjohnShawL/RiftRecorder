using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weakness { get; set; }
        public List<Character> Characters { get; set; }
        public List<PowerTag> PowerTags { get; set; }
        public List<StoryTag> StoryTags { get; set; }
    }
}
