using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderIndustry_Handler
{

    public record UpdateTenderIndustryHandler : IRequestHandler<UpdateTenderIndustryCommand, TenderIndustryDto>
    {
        private readonly AppDbContext _db;

        public UpdateTenderIndustryHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TenderIndustryDto> Handle(UpdateTenderIndustryCommand request, CancellationToken cancellationToken)
        {
            
            if (await _db.TenderIndustries
                .AnyAsync(tl => tl.TenderIndustryName == request.tenderIndustryName, cancellationToken))
            {
                Console.WriteLine("TenderIndustry with the same name already exists.");
                return null;
            }

             
            var tenderIndustry = await _db.TenderIndustries.FindAsync(request.tenderIndustryId);

            if (tenderIndustry == null)
            {
                Console.WriteLine("TenderIndustry not found.");
                return null;
            }

           
            tenderIndustry.TenderIndustryName = request.tenderIndustryName;

            
            await _db.SaveChangesAsync(cancellationToken);

            
            return new TenderIndustryDto
            {
                TenderIndustryId = tenderIndustry.TenderIndustryId,
                TenderIndustryName = tenderIndustry.TenderIndustryName
            };
        }
    }
}
