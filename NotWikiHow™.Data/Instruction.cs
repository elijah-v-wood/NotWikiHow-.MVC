using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Data
{
        // A Good Portion of this code is structured in a way that allows it to sit in a database
        // However it isn't my intention to give this datatype a dbSet.

    public class Instruction
    {
        [Key]
        public int InstructId { get; set; }
        public int TutorId { get; set; }
        public int Step { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
