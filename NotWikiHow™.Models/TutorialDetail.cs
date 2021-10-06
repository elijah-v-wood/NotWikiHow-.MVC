using NotWikiHow_.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class TutorialDetail
    {
        [Key]
        public int TutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Instruction> Instructions { get; set; }
        public bool Published { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name ="Last Modified On")]
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}
