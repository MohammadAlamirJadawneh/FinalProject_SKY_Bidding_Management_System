using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidDocument_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidDocument_Queries;

namespace SKY_Bidding_Management_System_Library.Service.BidDocumentService
{
    public class BidDocumentService : IBidDocumentService
    {
        private readonly IMediator _mediator;

        public BidDocumentService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<BidDocumentDto> InsertBidDocumentAsync(IFormFile file, int bidId)
        {
           
            var fileName = file.FileName;
            var contentType = file.ContentType;
            byte[] data;

           
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                data = memoryStream.ToArray();   
            }
 
            var command = new InsertBidDocumentCommand(fileName, contentType, data, bidId);

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
        }



        public async Task<List<BidDocumentDto>> GetAllBidDocumentsAsync()
        {
            var query = new GetAllBidDocumentsQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> DeleteBidDocumentAsync(int id)
        {
            var command = new DeleteBidDocumentCommand(id);
            if (command == null)
            {
                return false;
            }
            return await _mediator.Send(command);
        }


        public async Task<BidDocumentDto> UpdateBidDocumentAsync(UpdateBidDocumentDto command)
        {
             
           
             

            
            byte[] fileData = null;
            if (command.BidDocumentFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await command.BidDocumentFile.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }
            }

            
            var updateCommand = new UpdateBidDocumentCommand(
                command.BidDocumentId,
                command.FileName,
                command.ContentType,
                fileData
            );

           
            return await _mediator.Send(updateCommand);
        }

        public async Task<FileContentResult?> DownloadBidDocumentsAsZipAsync(int BidDocumentId)
        {
            var query = new DownloadBidDocumentsAsZipQuery(BidDocumentId);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }


    }

}
