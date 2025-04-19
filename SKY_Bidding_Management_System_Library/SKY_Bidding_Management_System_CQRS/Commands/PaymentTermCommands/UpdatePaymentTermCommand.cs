using MediatR;
using SKY_Bidding_Management_System_Library.Data.Models;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands
{
    public record UpdatePaymentTermCommand(
     int Id,
     string PaymentSchedule,
     string PaymentMethod,
     string PenaltiesForDelays
 ) : IRequest<PaymentTerm>;
     


}
