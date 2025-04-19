using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries
{

    public record DownloadBidDocumentsZipQuery(int BidId) : IRequest<FileContentResult>;

}
