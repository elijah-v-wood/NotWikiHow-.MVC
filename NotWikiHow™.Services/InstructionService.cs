using NotWikiHow_.Data;
using NotWikiHow_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Services
{
    public class InstructionService
    {
        private readonly Guid _userId;

        public InstructionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateInstruction(InstructionCreate model)
        {
            var ety = new Instruction()
            {
                TutorId=model.TutorId,
                Title = model.Title,
                Description = model.Description,
                CreatedUTC = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
               var count = ctx.Instructions.Where(e => e.TutorId == ety.TutorId).Count();
                ety.Step = count++;

                ctx.Instructions.Add(ety);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InstructionList> GetInstructionsByTutorial(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Instructions
                    .Where(e => e.TutorId == id)
                    .Select(e =>
                    new InstructionList
                    {
                        InstructId=e.InstructId,
                        Step=e.Step,
                        Title=e.Title,
                        Description=e.Description
                    }
                    );
                return query.ToArray();
            }
        }
        public InstructionDetail GetById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var ety =
                    ctx.Instructions.Single(e => e.InstructId == id);
                return new InstructionDetail()
                {
                    InstructId = ety.InstructId,
                    TutorId = ety.TutorId,
                    Step = ety.Step,
                    Title = ety.Title,
                    Description = ety.Description
                };
            }
        }
        public bool UpdateInstruction(InstructionEdit model)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var ety = ctx.Instructions.Single(e => e.InstructId == model.InstructId);

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
                    ctx.Instructions.Single
                    (e => e.InstructId == id);
                ctx.Instructions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
