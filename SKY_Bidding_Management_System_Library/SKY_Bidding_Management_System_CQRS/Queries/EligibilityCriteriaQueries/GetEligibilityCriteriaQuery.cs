using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.EligibilityCriteria;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.EligibilityCriteriaQueries
{
    public record GetEligibilityCriteriaQuery(int TenderId) : IRequest<EligibilityCriteriaDto>;

   

}
