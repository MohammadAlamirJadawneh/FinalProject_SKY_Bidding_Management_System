using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderIndustry_Handler
{

    public record DeleteTenderIndustryHandler : IRequestHandler<DeleteTenderIndustryCommand, bool>
    {
        private readonly AppDbContext _db;

        public DeleteTenderIndustryHandler(AppDbContext db)
        {

            _db = db;
        }

        public async Task<bool> Handle(DeleteTenderIndustryCommand request, CancellationToken cancellationToken)
        {
            var tenderIndustry = await _db.TenderIndustries.FindAsync(request.TenderIndustryId);

            if (tenderIndustry == null)
            {
                Console.WriteLine($"tenderIndustry with ID {request.TenderIndustryId} not found.");
                return false;
            }

            _db.TenderIndustries.Remove(tenderIndustry);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
