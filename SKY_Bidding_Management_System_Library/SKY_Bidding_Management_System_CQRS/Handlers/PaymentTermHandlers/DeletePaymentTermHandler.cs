using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.PaymentTermHandlers
{
    public record DeletePaymentTermHandler(AppDbContext Context) : IRequestHandler<DeletePaymentTermCommand, bool>
    {
        public async Task<bool> Handle(DeletePaymentTermCommand request, CancellationToken cancellationToken)
        {
            var paymentTerm = await Context.PaymentTerms.FindAsync(request.Id);
            if (paymentTerm == null)
            {
                return false;  
            }

            Context.PaymentTerms.Remove(paymentTerm);
            await Context.SaveChangesAsync(cancellationToken);
            return true; // Success
        }
    }

     
}
