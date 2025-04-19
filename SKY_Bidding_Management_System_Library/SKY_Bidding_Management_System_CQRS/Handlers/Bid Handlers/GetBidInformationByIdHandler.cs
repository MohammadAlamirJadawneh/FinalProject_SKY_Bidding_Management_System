using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{

    public record GetBidInformationByIdHandler(AppDbContext Context) : IRequestHandler<GetBidInformationByIdQuery, BidderInformationDto>
    {
        public async Task<BidderInformationDto> Handle(GetBidInformationByIdQuery request, CancellationToken cancellationToken)
        {
            var bid = await Context.Bids
                .FirstOrDefaultAsync(b => b.BidId == request.BidId, cancellationToken);

            if (bid == null) return null;

            return new BidderInformationDto(
                bid.CompanyName,
                bid.RegistrationNumber,
                bid.Address,
                bid.Email,
                bid.Phone
            );
        }
    }
     

}
