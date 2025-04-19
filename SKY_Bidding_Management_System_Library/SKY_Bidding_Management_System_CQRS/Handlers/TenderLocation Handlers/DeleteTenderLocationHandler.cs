using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderLocation_Handlers
{

    public record DeleteTenderLocationHandler : IRequestHandler<DeleteTenderLocationCommand, bool>
    {
        private readonly AppDbContext _db;

        public DeleteTenderLocationHandler(AppDbContext db)
        {

            _db = db;
        }

        public async Task<bool> Handle(DeleteTenderLocationCommand request, CancellationToken cancellationToken)
        {
            var tenderLocation = await _db.TenderLocations.FindAsync(request.TenderLocationId);

            if (tenderLocation == null)
            {
                Console.WriteLine($"TenderLocation with ID {request.TenderLocationId} not found.");
                return false;
            }

            _db.TenderLocations.Remove(tenderLocation);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
