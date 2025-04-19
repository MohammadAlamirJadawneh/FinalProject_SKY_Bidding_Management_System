using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderCategory_Handlers
{

    public record UpdateTenderCategoryHandler : IRequestHandler<UpdateTenderCategoryCommand, TenderCategoryDto>
    {
        private readonly AppDbContext _db;

        public UpdateTenderCategoryHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TenderCategoryDto> Handle(UpdateTenderCategoryCommand request, CancellationToken cancellationToken)
        {
             if (await _db.TenderCategories
                .AnyAsync(tl => tl.TenderCategoryName == request.tenderCategoryName, cancellationToken))
            {
                Console.WriteLine("TenderCategory with the same name already exists.");
                return null;
            }

             var tenderCategory = await _db.TenderCategories.FindAsync(request.tenderCategoryId);

            if (tenderCategory == null)
            {
                Console.WriteLine("TenderCategory not found.");
                return null;
            }

             tenderCategory.TenderCategoryName = request.tenderCategoryName;

             await _db.SaveChangesAsync(cancellationToken);

             return new TenderCategoryDto
            {
                TenderCategoryId = tenderCategory.TenderCategoryId,
                TenderCategoryName = tenderCategory.TenderCategoryName
            };
        }
    }
}
