using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.BidService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;
using System.Text;
namespace SKY_Bidding_Management_System.Controllers
{

    [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]
    [ApiController]
    [Route("api/[controller]")]

    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService service)
        {
            _bidService = service;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAllBids()
        {
            var result = await _bidService.GetAllBidsAsync(new GetAllBidsQuery());
            if (result == null)
            {
                return NotFound($"Bid Entity dont have Any Bids.");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBidBy(int bidBy)
        {
            var result = await _bidService.GetBidByIdAsync(new GetBidByIdQuery(bidBy));
            if (result == null)
            {
                return NotFound($"Bid with ID {bidBy} not found.");
            }
            return Ok(result);
        }

        [HttpGet("download/{bidId}")]
        public async Task<IActionResult> DownloadBidDocuments(int bidId)
        {

            var fileResult = await _bidService.DownloadBidDocumentsAsZipAsync(bidId);

            if (fileResult == null)
            {

                return NotFound("No documents found for this bid.");
            }
            return fileResult;


        }


  
        [HttpPost()]
        public async Task<IActionResult> InsertBid([FromForm] InsertBidCommand command)
        {

            if (command.Files == null || !command.Files.Any())
            {
                return BadRequest("No files uploaded.");
            }

            var result = await _bidService.InsertBidAsync(command);
            if (result == null)
            {
                return BadRequest("Failed to Insert bid.");
            }

            return Ok(result);
        }
 

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBid(int id, [FromBody] UpdateBidCommand command)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }
            if (id != command.BidId)
            {
                return BadRequest("ID mismatch.");
            }
            var result = await _bidService.UpdateBidAsync(command);

            if (result == null)
            {
                return NotFound($"Bid with ID {id} not found.");
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int bidId , int tenderId)
        {
            if (bidId <= 0 || tenderId<=0)
            {
                return BadRequest("Invalid ID.");
            }
            var result = await _bidService.DeleteBidAsync(new DeleteBidCommand(bidId, tenderId));

            if (!result)
            {
                return NotFound($"Bid with ID {bidId} not found.");
            }

            return   Ok($"Bid with ID {bidId} is Deleted Successfully");
        }


       

        [HttpGet("downloadBidSubmissionDocument/{bidid}")]
        public async Task<IActionResult> DownloadBidSubmissionDocument(int bidid)
        {
             
                var documentContentBytes = await _bidService.GenerateBidSubmissionDocumentAsync(bidid);

                if (documentContentBytes == null || documentContentBytes.Length == 0)
                {
                return NotFound($" Bid submission document with ID {bidid} could not be generated.");
                 
                 }

                return File(documentContentBytes, "text/plain", $"BidSubmission_{bidid}.txt");
             
        }


        [HttpGet("downloadBidProposal/{bidid}")]
        public async Task<IActionResult> DownloadBidProposal(int bidid)
        {
             
                var documentContentBytes = await _bidService.GenerateBidProposalDocumentAsync(bidid);

                if (documentContentBytes == null || documentContentBytes.Length == 0)
                 {
                  return NotFound($" Bid proposal document with ID {bidid} could not be generated.");

                 }

                return File(documentContentBytes, "text/plain", $"BidProposal_{bidid}.txt");
           


        }


        [HttpGet("download-supporting-documents-text/{bidId}")]
        public async Task<IActionResult> DownloadSupportingDocumentsText(int bidId)
        {
             

                var supportingContentBytes = await _bidService.GenerateSupportingDocumentsText(bidId);
               if (supportingContentBytes == null || supportingContentBytes.Length == 0)
                   {
                    return NotFound( $"No supporting documents text found for Bid ID {bidId}." );
                }


                var documentContentBytes = Encoding.UTF8.GetBytes(supportingContentBytes);


                return File(documentContentBytes, "text/plain", $"SupportingDocuments_{bidId}.txt");
             
            
        }




        [HttpGet("downloadDeclaration")]
        public async Task<IActionResult> DownloadDeclaration(string companyName, string authorizedSignatory, DateTime submissionDate)
        {
           
                var declarationText = await _bidService.GenerateDeclarationText(companyName, authorizedSignatory, submissionDate);

                if (declarationText == null || declarationText.Length == 0)
                {
                    return NotFound( "Declaration could not be generated." );
                }

                var documentContentBytes = Encoding.UTF8.GetBytes(declarationText);

                return File(documentContentBytes, "text/plain", "Declaration.txt");
            
        }


    }
}

