﻿using NotWikiHow_.Data;
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
                CreatedUTC = DateTimeOffset.Now
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
                        CreatedUTC = e.CreatedUTC,
                    }
                );
                return query.ToArray();
            }
        }
        public TutorialDetail GetById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tutorials
                    .Single(e => (e.TutorId == id && e.UserId == _userId) || (e.TutorId==id && e.Published==true));
                return
                    new TutorialDetail
                    {
                        TutorId = entity.TutorId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Instructions = entity.Instructions,
                        Published = entity.Published,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC,
                    };
            }
        }
    }
}
