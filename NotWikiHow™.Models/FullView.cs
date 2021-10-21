using NotWikiHow_.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class FullView
    {
        public int TutorId { get; set; }
        public string Description { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        public List<Step> Steps { get; set; }
        /*public List<Comment> Comments { get; set; }
        public List<Reply> Replies { get; set; }*/
    }
}
