using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidDocument;
using SKY_Bidding_Management_System_Library.Service.BidDocumentService;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]
    [ApiController]
    [Route("api/[controller]")]
    public class BidDocumentController : ControllerBase
    {
        private readonly IBidDocumentService _bidDocumentService;

        public BidDocumentController(IBidDocumentService bidDocumentService)
        {
            _bidDocumentService = bidDocumentService;
        }
         [HttpPost]
        public async Task<IActionResult> InsertBidDocument([FromForm] InsertBidDocumentDto dto)
        {
        
            if (dto.BidDocumentFile == null || dto.BidDocumentFile.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            
            var result = await _bidDocumentService.InsertBidDocumentAsync(dto.BidDocumentFile, dto.BidId);

            
            return Ok(result);
        }

         [HttpPut("{BidDocumentId}")]
        public async Task<IActionResult> UpdateBidDocument(int bidDocumentId, [FromForm] UpdateBidDocumentDto command)
        {
            
            if (bidDocumentId != command.BidDocumentId)
            {
                return BadRequest("BidDocumentId mismatch.");
            }

            var result = await _bidDocumentService.UpdateBidDocumentAsync(command);

            if (result == null)
            {
                return NotFound($"Bid with ID {bidDocumentId} not found. Or FileName not found Or  or ContentType not found Or BidDocumentFile not found ");
            }
            return Ok(result);
        }

         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bidDocumentService.GetAllBidDocumentsAsync();
            if (result == null)
            {
                return NotFound($"BidDocument Entity dont have Any Bids.");
            }
            return Ok(result);
        }



         [HttpDelete("{BidDocumentId}")]
        public async Task<IActionResult> Delete(int BidDocumentId)
        {
            var result = await _bidDocumentService.DeleteBidDocumentAsync(BidDocumentId);
            if (!result)
            {
                return NotFound($"BidDocumentId with ID {BidDocumentId} was not found.");
            }
            return Ok(result);
        }

        [HttpGet("download/{BidDocumentId}")]
        public async Task<IActionResult> DownloadBidDocuments(int BidDocumentId)
        {
            var fileResult = await _bidDocumentService.DownloadBidDocumentsAsZipAsync(BidDocumentId);

            if (fileResult == null)
                return NotFound($"No documents found for Bid with ID {BidDocumentId}.");

            return fileResult;
        }


    }

}
