using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.PaymentTermsQueries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.PaymentTermHandlers
{
    public record GetPaymentTermsHandler(AppDbContext Context) : IRequestHandler<GetPaymentTermsQuery, List<PaymentTermDto>>
    {
        public async Task<List<PaymentTermDto>> Handle(GetPaymentTermsQuery request, CancellationToken cancellationToken)
        {
            return await Context.PaymentTerms
                .Select(pt => new PaymentTermDto
                {
                    PaymentTermId = pt.PaymentTermId,
                    PaymentSchedule = pt.PaymentSchedule,
                    PaymentMethod = pt.PaymentMethod,
                    PenaltiesForDelays = pt.PenaltiesForDelays
                })
                .ToListAsync(cancellationToken);
        }
    }
 

}
