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
    }
}
