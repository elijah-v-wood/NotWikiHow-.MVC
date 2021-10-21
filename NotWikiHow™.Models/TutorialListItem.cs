using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
    public class TutorialListItem
    {
        [Key]
        public int TutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name=("Created"))]
        public DateTimeOffset CreatedUTC { get; set; }

    }
}
