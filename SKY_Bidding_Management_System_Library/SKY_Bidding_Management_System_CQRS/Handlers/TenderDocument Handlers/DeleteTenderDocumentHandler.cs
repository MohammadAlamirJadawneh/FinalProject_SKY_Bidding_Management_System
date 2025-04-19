using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;

using SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Handlers.TenderDocument_Handlers
{
    public record DeleteTenderDocumentCommandHandler(AppDbContext Db) : IRequestHandler<DeleteTenderDocumentCommand, bool>
    {
        public async Task<bool> Handle(DeleteTenderDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await Db.TenderDocuments
                .FirstOrDefaultAsync(d => d.TenderDocumentId == request.TenderDocumentId, cancellationToken);

            if (document == null)
                return false;

            Db.TenderDocuments.Remove(document);
            await Db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

     
}