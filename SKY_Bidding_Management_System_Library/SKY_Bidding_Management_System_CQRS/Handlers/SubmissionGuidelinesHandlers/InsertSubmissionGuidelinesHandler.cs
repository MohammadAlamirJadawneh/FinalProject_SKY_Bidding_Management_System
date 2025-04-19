using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.SubmissionGuidelinesCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.SubmissionGuidelinesHandlers
{
    public record InsertSubmissionGuidelinesHandler(AppDbContext Context) : IRequestHandler<InsertSubmissionGuidelinesCommand, bool>
    {
        public async Task<bool> Handle(InsertSubmissionGuidelinesCommand request, CancellationToken cancellationToken)
        {
             
            var entities = request.Guidelines.Select(g => new SubmissionGuideline
            {
                TenderId = g.TenderId,
                RequiredDocument = g.RequiredDocument   
            }).ToList();

           
            await Context.SubmissionGuidelines.AddRangeAsync(entities);
            await Context.SaveChangesAsync();

            return true;
        }
    }
 

}
