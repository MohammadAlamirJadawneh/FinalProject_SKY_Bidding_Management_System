using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidDocument_Handlers
{
    public record DeleteBidDocumentCommandHandler(AppDbContext Db) : IRequestHandler<DeleteBidDocumentCommand, bool>
    {
        public async Task<bool> Handle(DeleteBidDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await Db.BidDocuments
                .FirstOrDefaultAsync(d => d.BidDocumentId == request.BidDocumentId, cancellationToken);

            if (document == null)
                return false;

            Db.BidDocuments.Remove(document);
            await Db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
 



}
