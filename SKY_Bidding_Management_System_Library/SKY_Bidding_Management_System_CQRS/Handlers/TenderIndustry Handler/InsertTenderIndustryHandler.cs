using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderIndustry_Handler
{

    public record InsertTenderIndustryHandler : IRequestHandler<InsertTenderIndustryCommand, TenderIndustryDto>
    {
        private readonly AppDbContext _db;

        public InsertTenderIndustryHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TenderIndustryDto> Handle(InsertTenderIndustryCommand request, CancellationToken cancellationToken)
        {
             if (await _db.TenderIndustries
                .AnyAsync(tl => tl.TenderIndustryName == request.tenderIndustry.TenderIndustryName, cancellationToken))
            {
                Console.WriteLine("TenderIndustry with the same name already exists.");
                return null;
            }

             var tenderIndustry = new TenderIndustry
            {
                TenderIndustryName = request.tenderIndustry.TenderIndustryName
            };

             await _db.TenderIndustries.AddAsync(tenderIndustry, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            
            var tenderIndustryDto = new TenderIndustryDto
            {
                TenderIndustryId = tenderIndustry.TenderIndustryId,
                TenderIndustryName = tenderIndustry.TenderIndustryName
            };

            
            return tenderIndustryDto;
        }
    }

}
