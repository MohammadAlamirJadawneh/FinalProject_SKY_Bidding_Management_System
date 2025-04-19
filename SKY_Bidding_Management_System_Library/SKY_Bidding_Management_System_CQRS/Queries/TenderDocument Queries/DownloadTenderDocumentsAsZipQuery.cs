using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Queries.TenderDocument_Queries
{
    public record DownloadTenderDocumentsAsZipQuery(int tenderDocumentId) : IRequest<FileContentResult?>;


}
