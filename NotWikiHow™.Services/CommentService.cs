using NotWikiHow_.Data;
using NotWikiHow_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var ety = new Comment()
            {
                UserId = _userId,
                Question = model.Question,
                TutorId = model.TutorId,
                CreatedUTC = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(ety);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetMyComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments.Where(e => e.UserId == _userId)
                    .Select(e =>
                    new CommentListItem
                    {
                        CommentId=e.CommentId,
                        Question=e.Question,
                        CreatedUTC=e.CreatedUTC,
                        TutorId=e.TutorId,
                        Tutorial=e.Tutorial
                    });
                return query.ToArray();
            }
        }
        public CommentDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ety =
                    ctx.Comments.Single(e => e.CommentId == id && _userId == e.UserId);
                return new CommentDetail
                {
                    CommentId = ety.CommentId,
                    TutorId = ety.TutorId,
                    Question = ety.Question,
                    CreatedUTC = ety.CreatedUTC,
                    ModifiedUTC = ety.ModifiedUTC,
                    Tutorial=ety.Tutorial
                };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var ety = ctx.Comments.Single
                    (e => e.CommentId == model.CommentId && e.UserId == _userId);

                ety.Question = model.Question;
                ety.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments.Single
                    (e => e.CommentId == id && e.UserId == _userId);
                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
