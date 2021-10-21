using NotWikiHow_.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class StepList
    {
        public int InstructId { get; set; }
        public int TutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("TutorId")]
        public virtual Tutorial Tutorial { get; set; }
    }
}
