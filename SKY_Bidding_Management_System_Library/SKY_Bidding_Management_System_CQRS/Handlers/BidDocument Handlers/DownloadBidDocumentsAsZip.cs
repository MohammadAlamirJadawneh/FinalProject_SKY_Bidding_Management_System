using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidDocument_Queries;
using System.IO.Compression;
namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.BidDocument_Handlers
{
    public record DownloadBidDocumentsAsZipHandler(AppDbContext Db) : IRequestHandler<DownloadBidDocumentsAsZipQuery, FileContentResult?>
    {
        public async Task<FileContentResult?> Handle(DownloadBidDocumentsAsZipQuery request, CancellationToken cancellationToken)
        {
            var documents = await Db.BidDocuments
                .Where(d => d.BidDocumentId == request.BidDocumentId)
                .ToListAsync(cancellationToken);

            if (documents == null || !documents.Any())
                return null;

            using var memoryStream = new MemoryStream();
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var doc in documents)
                {
                    var entry = archive.CreateEntry(doc.BidDocumentName, CompressionLevel.Fastest);
                    using var entryStream = entry.Open();
                    await entryStream.WriteAsync(doc.BidDocumentData, 0, doc.BidDocumentData.Length, cancellationToken);
                }
            }

            return new FileContentResult(memoryStream.ToArray(), "application/zip")
            {
                FileDownloadName = $"Bid_{request.BidDocumentId}_Documents.zip"
            };
        }
    }
     




}
