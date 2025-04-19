using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;
using System.IO.Compression;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{
    public record DownloadBidDocumentsZipHandler(AppDbContext Context) : IRequestHandler<DownloadBidDocumentsZipQuery, FileContentResult>
    {
        public async Task<FileContentResult> Handle(DownloadBidDocumentsZipQuery request, CancellationToken cancellationToken)
        {
            var documents = await Context.BidDocuments
                .Where(doc => doc.BidId == request.BidId)
                .ToListAsync(cancellationToken);

            if (documents == null || documents.Count == 0)
                return null;

            using var memoryStream = new MemoryStream();
            using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var doc in documents)
                {
                    var entry = zip.CreateEntry(doc.BidDocumentName, CompressionLevel.Fastest);
                    using var entryStream = entry.Open();
                    await entryStream.WriteAsync(doc.BidDocumentData, 0, doc.BidDocumentData.Length, cancellationToken);
                }
            }

            memoryStream.Position = 0;
            var zipName = $"Bid_{request.BidId}_Documents.zip";
            return new FileContentResult(memoryStream.ToArray(), "application/zip")
            {
                FileDownloadName = zipName
            };
        }
    }
     
}
