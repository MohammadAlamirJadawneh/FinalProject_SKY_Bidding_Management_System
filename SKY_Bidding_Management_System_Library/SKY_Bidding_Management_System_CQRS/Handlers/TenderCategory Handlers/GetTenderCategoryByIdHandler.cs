using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderCategory_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderCategory_Handlers
{
    public record GetTenderCategoryByIdHandler(AppDbContext Db) : IRequestHandler<GetTenderCategoryByIdQuery, TenderCategoryDto>
    {
        public async Task<TenderCategoryDto> Handle(GetTenderCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var tenderCategory = await Db.TenderCategories
                .Where(e => e.TenderCategoryId == request.tenderCategoryId)
                .Select(e => new TenderCategoryDto
                {
                    TenderCategoryId = e.TenderCategoryId,
                    TenderCategoryName = e.TenderCategoryName
                })
                .FirstOrDefaultAsync(cancellationToken);

            return tenderCategory;
        }
    }

    
}
