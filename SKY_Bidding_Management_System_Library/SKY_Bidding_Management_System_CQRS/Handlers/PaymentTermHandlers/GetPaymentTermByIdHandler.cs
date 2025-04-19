using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.PaymentTermsQueries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.PaymentTermHandlers
{
    public record GetPaymentTermByIdHandler(AppDbContext Context) : IRequestHandler<GetPaymentTermByIdQuery, PaymentTermDto>
    {
        public async Task<PaymentTermDto> Handle(GetPaymentTermByIdQuery request, CancellationToken cancellationToken)
        {
            var paymentTerm = await Context.PaymentTerms
                .Where(pt => pt.PaymentTermId == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (paymentTerm == null)
            {
                return null;  
            }

            return new PaymentTermDto
            {
                PaymentTermId = paymentTerm.PaymentTermId,
                PaymentSchedule = paymentTerm.PaymentSchedule,
                PaymentMethod = paymentTerm.PaymentMethod,
                PenaltiesForDelays = paymentTerm.PenaltiesForDelays
            };
        }
    }
     

}
