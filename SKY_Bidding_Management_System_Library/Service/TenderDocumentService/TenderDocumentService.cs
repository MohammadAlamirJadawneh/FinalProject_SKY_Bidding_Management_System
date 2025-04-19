using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Tenderding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Commands.TenderDocument_Commands;
using SKY_Tenderding_Management_System_Library.SKY_Tenderding_Management_System_CQRS.Queries.TenderDocument_Queries;

namespace SKY_Tenderding_Management_System_Library.Service.TenderDocumentService
{
    public class TenderDocumentService : ITenderDocumentService
    {
        private readonly IMediator _mediator;

        public TenderDocumentService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<TenderDocumentDto> InsertTenderDocumentAsync(IFormFile file, int TenderId)
        {
            
            var fileName = file.FileName;
            var contentType = file.ContentType;
            byte[] data;

           
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                data = memoryStream.ToArray();   
            }

           
            var command = new InsertTenderDocumentCommand(fileName, contentType, data, TenderId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
             
        }




        public async Task<List<TenderDocumentDto>> GetAllTenderDocumentsAsync()
        {
            var query = new GetAllTenderDocumentsQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> DeleteTenderDocumentAsync(int id)
        {
            var command = new DeleteTenderDocumentCommand(id);
            if (command == null)
            {
                return false;
            }
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
            return result;
           
        }

        public async Task<TenderDocumentDto> UpdateTenderDocumentAsync(UpdateTenderDocumentDto command)
        {

            if (command.TenderDocumentId <= 0 || command.FileName == null || command.ContentType == null || command.TenderDocumentFile == null)
            {
                return null;
            }
             

           
            byte[] fileData = null;
            if (command.TenderDocumentFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await command.TenderDocumentFile.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }
            }

          
            var updateCommand = new UpdateTenderDocumentCommand(
                command.TenderDocumentId,
                command.FileName,
                command.ContentType,
                fileData
            );

           
              

            var result =   await _mediator.Send(updateCommand);
            if (result == null)
            {
                return null;
            }

            return result;
        }
        public async Task<FileContentResult?> DownloadTenderDocumentsAsZipAsync(int TenderDocumentId)
        {
            var query = new DownloadTenderDocumentsAsZipQuery(TenderDocumentId);
            var result= await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }

            return result;
        }




    }

}
