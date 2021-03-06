using NotWikiHow_.Data;
using NotWikiHow_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Services
{
    public class TutorialService
    {
        private readonly Guid _userId;
        public TutorialService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTutorial(TutorialCreateModel model)
        {
            var entity = new Tutorial()
            {
                UserId = _userId,
                Title = model.Title,
                Description = model.Description,
                CreatedUTC = DateTimeOffset.Now,
                Steps = new List<Step>()
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tutorials.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TutorialListItem> GetMyTutorials()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx.Tutorials.Where(e => e.UserId == _userId)
                .Select(e =>
                    new TutorialListItem
                    {
                        TutorId = e.TutorId,
                        Title = e.Title,
                        Description = e.Description,
                        CreatedUTC = e.CreatedUTC
                    }
                );
                return query.ToArray();
            }
        }
        public TutorialDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tutorials
                    .Single(e => (e.TutorId == id && e.UserId == _userId) || (e.TutorId == id && e.Published == true));
                foreach (Step step in ctx.Steps)
                {
                    if (step.TutorId == entity.TutorId)
                    {
                        entity.Steps.Add(step);
                    }
                }
                return
                    new TutorialDetail
                    {
                        TutorId = entity.TutorId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Steps = entity.Steps,
                        Published = entity.Published,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC,
                    };
            }
        }
        public bool UpdateTutorial(TutorialEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ety = ctx.Tutorials.Single
                    (e => e.TutorId == model.TutorId && e.UserId == _userId);

                ety.Title = model.Title;
                ety.Description = model.Description;
                ety.Published = model.Published;
                ety.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTutorial(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Tutorials.Single
                    (e => e.TutorId == id && e.UserId == _userId);
                ctx.Tutorials.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        /*public FullView GetFullView(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ety =
                    ctx.Tutorials.Single(e => e.TutorId == id);
                foreach(Step step in ctx.Steps)
                {
                    if (step.TutorId == ety.TutorId)
                    {
                        ety.Steps.Add(step);
                    }
                }
                return new FullView
                {
                    TutorId=ety.TutorId,
                    Steps=ety.Steps,
                    Description=ety.Description,
                    CreatedUTC=ety.CreatedUTC
                };
            }
        }*/

    }
}
