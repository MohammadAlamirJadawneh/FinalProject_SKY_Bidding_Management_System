using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderLocation_Handlers
{
    public record UpdateTenderLocationHandler : IRequestHandler<UpdateTenderLocationCommand, TenderLocationDto>
    {
        private readonly AppDbContext _db;

        public UpdateTenderLocationHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TenderLocationDto> Handle(UpdateTenderLocationCommand request, CancellationToken cancellationToken)
        {

            if (await _db.TenderLocations
                .AnyAsync(tl => tl.TenderLocationName == request.tenderLocationName, cancellationToken))
            {
                Console.WriteLine("TenderLocation with the same name already exists.");
                return null;
            }


            var tenderLocation = await _db.TenderLocations.FindAsync(request.tenderLocationId);

            if (tenderLocation == null)
            {
                Console.WriteLine("TenderLocation not found.");
                return null;
            }

            tenderLocation.TenderLocationName = request.tenderLocationName;

            await _db.SaveChangesAsync(cancellationToken);

            return new TenderLocationDto
            {
                TenderLocationId = tenderLocation.TenderLocationId,
                TenderLocationName = tenderLocation.TenderLocationName
            };
        }
    }

}
