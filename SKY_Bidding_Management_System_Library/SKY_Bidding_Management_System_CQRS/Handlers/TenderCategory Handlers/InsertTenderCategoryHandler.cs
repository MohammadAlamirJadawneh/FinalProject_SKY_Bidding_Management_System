using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderCategory_Handlers
{

    public record InsertTenderCategoryHandler : IRequestHandler<InsertTenderCategoryCommand, TenderCategoryDto>
    {
        private readonly AppDbContext _db;

        public InsertTenderCategoryHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TenderCategoryDto> Handle(InsertTenderCategoryCommand request, CancellationToken cancellationToken)
        {
             if (await _db.TenderCategories
                .AnyAsync(tl => tl.TenderCategoryName == request.tenderCategory.TenderCategoryName, cancellationToken))
            {
                Console.WriteLine("TenderCategory with the same name already exists.");
                return null;
            }

             var tenderCategory = new TenderCategory
            {
                TenderCategoryName = request.tenderCategory.TenderCategoryName
            };

             await _db.TenderCategories.AddAsync(tenderCategory, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

             var tenderCategoryDto = new TenderCategoryDto
            {
                TenderCategoryId = tenderCategory.TenderCategoryId,
                TenderCategoryName = tenderCategory.TenderCategoryName
            };

           
            return tenderCategoryDto;
        }
    }
}
