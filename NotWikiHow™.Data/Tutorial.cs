using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Data
{
    public class Tutorial
    {
        [Key]
        public int TutorId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Instruction> Instructions = new List<Instruction>();
        public bool Published { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}
