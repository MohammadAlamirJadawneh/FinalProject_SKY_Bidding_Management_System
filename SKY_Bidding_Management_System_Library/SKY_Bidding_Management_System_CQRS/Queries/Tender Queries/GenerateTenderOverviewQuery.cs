using MediatR;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries
{

    public record GenerateTenderOverviewQuery(int TenderId) : IRequest<string>;

}
