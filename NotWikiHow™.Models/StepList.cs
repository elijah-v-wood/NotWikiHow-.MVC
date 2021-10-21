using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class StepList
    {
        public int InstructId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
