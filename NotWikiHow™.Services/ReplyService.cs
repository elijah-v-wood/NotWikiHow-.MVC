using NotWikiHow_.Data;
using NotWikiHow_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Services
{
    class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                UserId = _userId,
                CommentId = model.CommentId,
                TutorId = model.TutorId,
                Content = model.Content,
                CreatedUTC = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetAllRepliesByComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Replies.Where(e => e.CommentId == id).Select
                (e =>
                new ReplyListItem
                {
                    ReplyId=e.ReplyId,
                    CommentId=e.CommentId,
                    TutorId=e.TutorId,
                    Content=e.Content,
                    CreatedUTC=e.CreatedUTC
                }
                );
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Replies.Single
                    (e => e.ReplyId == id && e.UserId == _userId);
                return new ReplyDetail
                {
                    ReplyId=entity.ReplyId,
                    CommentId=entity.ReplyId,
                    TutorId=entity.TutorId,
                    Content=entity.Content,
                    CreatedUTC=entity.CreatedUTC,
                    ModifiedUTC=entity.ModifiedUTC
                };
            }
        }

    }
}
