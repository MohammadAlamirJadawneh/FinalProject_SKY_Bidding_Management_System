using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderCategory_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderCategory_Handlers
{
    public record GetAllTenderCategoriesHandler(AppDbContext Db) : IRequestHandler<GetAllTenderCategoriesQuery, List<TenderCategoryDto>>
    {
        public async Task<List<TenderCategoryDto>> Handle(GetAllTenderCategoriesQuery request, CancellationToken cancellationToken)
        {
            var tenderCategories = await Db.TenderCategories
                .Select(t => new TenderCategoryDto
                {
                    TenderCategoryId = t.TenderCategoryId,
                    TenderCategoryName = t.TenderCategoryName
                })
                .ToListAsync(cancellationToken);

            return tenderCategories;
        }
    }

    
}
