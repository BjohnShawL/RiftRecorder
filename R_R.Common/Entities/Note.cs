using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_R.Common.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(160)]
        public string Title { get; set; }
        [MaxLength(2048)]
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreatedOn { get; set; }

        public Game Game { get; set; }
        public R_RUser User { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
    }
}
