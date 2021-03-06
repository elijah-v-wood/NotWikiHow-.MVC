using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Data
{
        // A Good Portion of this code is structured in a way that allows it to sit in a database
        // However it isn't my intention to give this datatype a dbSet.

    public class Step
    {
        [Key]
        public int InstructId { get; set; }
        public Guid UserId { get; set; }
        public int TutorId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
        [ForeignKey("TutorId")]
        public virtual Tutorial Tutorial { get; set; }

    }
}
