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
        public List<Step> Steps { get; set; }
        public bool Published { get; set; }

        public Step step { get; set; }
    }
}
