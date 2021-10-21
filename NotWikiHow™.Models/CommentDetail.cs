using NotWikiHow_.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public int TutorId { get; set; }
        public string Question { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Last Modified On")]
        public DateTimeOffset ModifiedUTC { get; set; }
        [ForeignKey("TutorId")]
        public virtual Tutorial Tutorial { get; set; }
    }
}
