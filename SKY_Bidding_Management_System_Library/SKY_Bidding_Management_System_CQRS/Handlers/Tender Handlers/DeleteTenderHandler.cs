using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record DeleteTenderHandler(AppDbContext Db) : IRequestHandler<DeleteTenderCommand, bool>
    {
        public async Task<bool> Handle(DeleteTenderCommand request, CancellationToken cancellationToken)
        {
            var tender = await Db.Tenders.FindAsync(request.TenderId);

            if (tender is null)
                return false;

            Db.Tenders.Remove(tender);
            await Db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

     

}
