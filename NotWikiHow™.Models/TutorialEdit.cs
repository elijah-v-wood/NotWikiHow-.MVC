using NotWikiHow_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class TutorialEdit
    {
        public int TutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Instruction> Instructions { get; set; }
        public bool Published { get; set; }

        public Instruction instruction { get; set; }
    }
}
