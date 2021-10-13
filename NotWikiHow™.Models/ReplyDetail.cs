using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Models
{
   public class ReplyDetail
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public Guid UserId { get; set; }
        public int TutorId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
    }
}
