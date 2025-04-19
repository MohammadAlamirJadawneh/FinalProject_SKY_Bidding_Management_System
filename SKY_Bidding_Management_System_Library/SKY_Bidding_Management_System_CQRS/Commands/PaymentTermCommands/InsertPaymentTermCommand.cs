using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands
{
    public record InsertPaymentTermCommand(string PaymentSchedule,
    string PaymentMethod, string PenaltiesForDelays) : IRequest<int>;

     
}
