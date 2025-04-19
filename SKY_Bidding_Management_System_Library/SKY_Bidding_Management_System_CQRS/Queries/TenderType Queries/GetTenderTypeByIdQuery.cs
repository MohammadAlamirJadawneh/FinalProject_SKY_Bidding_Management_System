using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderType_Queries
{

    public record GetTenderTypeByIdQuery(int tenderTypeId) : IRequest<TenderTypeDto>;
 
}
