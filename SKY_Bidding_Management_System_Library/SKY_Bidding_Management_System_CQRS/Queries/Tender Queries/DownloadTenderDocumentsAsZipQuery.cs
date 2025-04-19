using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries
{
    public record DownloadTenderDocumentsAsZipQuery(int TenderId) : IRequest<FileContentResult?>;

}
