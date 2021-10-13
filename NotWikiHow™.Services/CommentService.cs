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
            var entity = new Comment()
            {
                UserId = _userId,
                TutorId = model.TutorId,
                Question = model.Question,
                CreatedUTC = DateTimeOffset.Now,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetAllComments(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments.Where
                    (e => e.TutorId == id)
                    .Select
                    (e => new CommentListItem
                    {
                        CommentId = e.CommentId,
                        TutorId = e.TutorId,
                        Question = e.Question,
                        CreatedUTC = e.CreatedUTC,
                    }
                    );
                return query.ToArray();
            }
        }
        public CommentDetail GetById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity= ctx.Comments.Single
                    (e=>e.CommentId==id && e.UserId == _userId);

                return new CommentDetail
                {
                    CommentId=entity.CommentId,
                    TutorId=entity.TutorId,
                    Question=entity.Question,
                    CreatedUTC=entity.CreatedUTC,
                    ModifiedUTC=entity.ModifiedUTC,
                };
            };
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single
                    (e => e.CommentId == model.CommentId && e.UserId == _userId);
                
                entity.Question = model.Question;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int id)
        {
            using(var ctx = new ApplicationDbContext())
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
