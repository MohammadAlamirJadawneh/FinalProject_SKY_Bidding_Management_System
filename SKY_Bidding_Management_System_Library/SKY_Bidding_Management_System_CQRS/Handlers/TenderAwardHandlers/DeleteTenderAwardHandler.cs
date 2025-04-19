using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderAwardHandlers
{
    public record DeleteTenderAwardHandler(AppDbContext Db) : IRequestHandler<DeleteTenderAwardCommand, bool>
    {
        public async Task<bool> Handle(DeleteTenderAwardCommand request, CancellationToken cancellationToken)
        {
            var entity = await Db.TenderAwards.FindAsync(new object[] { request.TenderAwardId }, cancellationToken);
            if (entity == null)
            {
                Console.WriteLine("TenderAward not found");
                return false;
            }

            Db.TenderAwards.Remove(entity);
            await Db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

    
}
