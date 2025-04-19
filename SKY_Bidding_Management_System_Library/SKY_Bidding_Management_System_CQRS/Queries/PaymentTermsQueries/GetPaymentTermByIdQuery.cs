using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.PaymentTermsQueries
{
    public record GetPaymentTermByIdQuery(int Id) : IRequest<PaymentTermDto>;


}
