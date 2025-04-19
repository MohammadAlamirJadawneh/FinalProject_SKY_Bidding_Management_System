using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;
using System.IO.Compression;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record DownloadTenderDocumentsAsZipHandler(AppDbContext DbContext)
    : IRequestHandler<DownloadTenderDocumentsAsZipQuery, FileContentResult?>
    {
        public async Task<FileContentResult?> Handle(DownloadTenderDocumentsAsZipQuery request, CancellationToken cancellationToken)
        {
            var documents = await DbContext.TenderDocuments
                .Where(doc => doc.TenderId == request.TenderId)
                .ToListAsync(cancellationToken);

            if (documents == null || !documents.Any())
                return null;

            using var memoryStream = new MemoryStream();
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var doc in documents)
                {
                    var entry = archive.CreateEntry(doc.TenderDocumentName, CompressionLevel.Fastest);
                    await using var entryStream = entry.Open();
                    await entryStream.WriteAsync(doc.TenderDocumentData, 0, doc.TenderDocumentData.Length, cancellationToken);
                }
            }

            return new FileContentResult(memoryStream.ToArray(), "application/zip")
            {
                FileDownloadName = $"Tender_{request.TenderId}_Documents.zip"
            };
        }
    }
     

}
