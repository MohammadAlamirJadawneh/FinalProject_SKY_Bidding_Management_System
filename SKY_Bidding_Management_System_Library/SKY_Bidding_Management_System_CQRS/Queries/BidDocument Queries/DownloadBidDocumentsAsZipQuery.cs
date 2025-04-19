using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidDocument_Queries
{

    public record DownloadBidDocumentsAsZipQuery(int BidDocumentId) : IRequest<FileContentResult?>;

}
