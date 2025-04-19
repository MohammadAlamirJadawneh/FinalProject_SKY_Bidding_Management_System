
using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;
namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{

    public record GenerateTenderOverviewHandler(AppDbContext Context)
    : IRequestHandler<GenerateTenderOverviewQuery, string>
    {
        public async Task<string> Handle(GenerateTenderOverviewQuery request, CancellationToken cancellationToken)
        {
            var tender = await Context.Tenders
                .Include(t => t.TenderCategory)
                .Include(t => t.TenderType)
                .FirstOrDefaultAsync(t => t.TenderId == request.TenderId, cancellationToken);

            if (tender == null)
                throw new Exception("Tender not found.");

            var overview = TenderDocumentTemplateGenerator.GenerateTenderDocumentText(tender);
            return overview;
        }
    }

     

}
