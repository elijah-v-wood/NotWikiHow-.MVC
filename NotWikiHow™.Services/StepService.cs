using NotWikiHow_.Data;
using NotWikiHow_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Services
{
    public class StepService
    {
        private readonly Guid _userId;

        public StepService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateInstruction(StepCreate model)
        {
            var ety = new Step()
            {
                TutorId = model.TutorId,
                UserId=_userId,
                Title = model.Title,
                Description = model.Description,
                CreatedUTC = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Steps.Add(ety);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StepList> GetInstructions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Steps
                    .Where(e => e.UserId == _userId)
                    .Select(e =>
                    new StepList
                    {
                        InstructId = e.InstructId,
                        Title = e.Title,
                        Description = e.Description
                    }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<StepList> GetInstructionsByTutorial(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Steps
                    .Where(e => e.TutorId == id && e.UserId==_userId)
                    .Select(e =>
                    new StepList
                    {
                        InstructId = e.InstructId,
                        Title = e.Title,
                        Description = e.Description
                    }
                    );
                return query.ToArray();
            }
        }
        public StepDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ety =
                    ctx.Steps.Single(e => e.InstructId == id);
                return new StepDetail()
                {
                    InstructId = ety.InstructId,
                    TutorId = ety.TutorId,
                    Order = ety.Order,
                    Title = ety.Title,
                    Description = ety.Description
                };
            }
        }
        public bool UpdateInstruction(StepEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ety = ctx.Steps.Single(e => e.InstructId == model.InstructId && e.UserId == _userId);

                ety.Title = model.Title;
                ety.Description = model.Description;
                ety.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteInstruction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Steps.Single
                    (e => e.InstructId == id && e.UserId==_userId);
                ctx.Steps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
