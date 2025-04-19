using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands
{
    public record DeletePaymentTermCommand(   int Id ) : IRequest<bool>;
     

}
