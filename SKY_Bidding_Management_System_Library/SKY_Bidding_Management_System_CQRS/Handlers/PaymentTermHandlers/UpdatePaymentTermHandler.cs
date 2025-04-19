using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.PaymentTermHandlers
{
    public record UpdatePaymentTermCommandHandler(AppDbContext Context) : IRequestHandler<UpdatePaymentTermCommand, PaymentTerm>
    {
        public async Task<PaymentTerm> Handle(UpdatePaymentTermCommand request, CancellationToken cancellationToken)
        {
           
            var paymentTerm = await Context.PaymentTerms
                .FindAsync(request.Id);

            if (paymentTerm == null)
            {
                throw new KeyNotFoundException("Payment term not found");
            }
 
            paymentTerm.PaymentSchedule = request.PaymentSchedule;
            paymentTerm.PaymentMethod = request.PaymentMethod;
            paymentTerm.PenaltiesForDelays = request.PenaltiesForDelays;

          
            await Context.SaveChangesAsync(cancellationToken);

            return paymentTerm;
        }
    }

     

}
