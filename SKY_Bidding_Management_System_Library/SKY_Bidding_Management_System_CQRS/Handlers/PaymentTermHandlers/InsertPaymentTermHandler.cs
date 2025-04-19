using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.PaymentTermHandlers
{
    public record InsertPaymentTermHandler(AppDbContext Context) : IRequestHandler<InsertPaymentTermCommand, int>
    {
        public async Task<int> Handle(InsertPaymentTermCommand request, CancellationToken cancellationToken)
        {
            var paymentTerm = new PaymentTerm
            {
                PaymentSchedule = request.PaymentSchedule,
                PaymentMethod = request.PaymentMethod,
                PenaltiesForDelays = request.PenaltiesForDelays
            };

            Context.PaymentTerms.Add(paymentTerm);
            await Context.SaveChangesAsync(cancellationToken);

            return paymentTerm.PaymentTermId;  
        }
    }

     

}
