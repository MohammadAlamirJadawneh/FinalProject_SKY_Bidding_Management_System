using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderType_Handlers
{


    public record DeleteTenderTypeHandler : IRequestHandler<DeleteTenderTypeCommand, bool>
    {
        private readonly AppDbContext _db;

        public DeleteTenderTypeHandler(AppDbContext db)
        {

            _db = db;
        }

        public async Task<bool> Handle(DeleteTenderTypeCommand request, CancellationToken cancellationToken)
        {
            var tenderType = await _db.TenderTypes.FindAsync(request.TenderTypeId);

            if (tenderType == null)
            {
                Console.WriteLine($"tenderType with ID {request.TenderTypeId} not found.");
                return false;
            }

            _db.TenderTypes.Remove(tenderType);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
