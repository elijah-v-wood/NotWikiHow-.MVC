using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class CommentCreate
    {
        public int TutorId { get; set; }
        public string Question { get; set; }
    }
}
