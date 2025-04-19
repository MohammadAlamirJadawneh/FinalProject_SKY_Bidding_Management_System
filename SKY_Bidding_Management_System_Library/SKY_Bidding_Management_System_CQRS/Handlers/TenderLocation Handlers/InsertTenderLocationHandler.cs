using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers
{

    public record InsertTenderLocationHandler : IRequestHandler<InsertTenderLocationCommand, TenderLocationDto>
    {
        private readonly AppDbContext _db;

        public InsertTenderLocationHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TenderLocationDto> Handle(InsertTenderLocationCommand request, CancellationToken cancellationToken)
        {
             if (await _db.TenderLocations
                .AnyAsync(tl => tl.TenderLocationName == request.tenderLocation.TenderLocationName, cancellationToken))
            {
                Console.WriteLine("TenderType with the same name already exists.");
                return null; ;
            }

            var tenderLocation = new TenderLocation
            {
                TenderLocationName = request.tenderLocation.TenderLocationName
            };

            await _db.TenderLocations.AddAsync(tenderLocation, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            var tenderLocationDto = new TenderLocationDto
            {
                TenderLocationId = tenderLocation.TenderLocationId,
                TenderLocationName = tenderLocation.TenderLocationName
            };

            return tenderLocationDto;
        }
    }



}


