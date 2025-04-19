using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderType_Handlers
{
    public record InsertTenderIndustryHandler(AppDbContext Db) : IRequestHandler<InsertTenderIndustryCommand, TenderIndustryDto>
    {
        public async Task<TenderIndustryDto> Handle(InsertTenderIndustryCommand request, CancellationToken cancellationToken)
        {
            if (await Db.TenderIndustries
                .AnyAsync(tl => tl.TenderIndustryName == request.tenderIndustry.TenderIndustryName, cancellationToken))
            {
                throw new InvalidOperationException("TenderIndustry with the same name already exists.");
            }

            var tenderIndustry = new TenderIndustry
            {
                TenderIndustryName = request.tenderIndustry.TenderIndustryName
            };

            await Db.TenderIndustries.AddAsync(tenderIndustry, cancellationToken);
            await Db.SaveChangesAsync(cancellationToken);

            var tenderIndustryDto = new TenderIndustryDto
            {
                TenderIndustryId = tenderIndustry.TenderIndustryId,
                TenderIndustryName = tenderIndustry.TenderIndustryName
            };

            return tenderIndustryDto;
        }
    }




}
