using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Tenderding_Management_System_Library.Data.DTOs.TenderDocument;
using SKY_Tenderding_Management_System_Library.Service.TenderDocumentService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SKY_Tenderding_Management_System.Controllers
{
    [Authorize( )]

    [ApiController]
    [Route("api/[controller]")]
    public class TenderDocumentController : ControllerBase
    {
        private readonly ITenderDocumentService _tenderDocumentService;

        public TenderDocumentController(ITenderDocumentService TenderDocumentService)
        {
            _tenderDocumentService = TenderDocumentService;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tenderDocumentService.GetAllTenderDocumentsAsync();
            if (result == null)
            {
                return NotFound($"TenderDocument Entity dont have Any TenderDocuments.");
            }
            return Ok(result);
        }
        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("download/{tenderDocumentId}")]
        public async Task<IActionResult> DownloadTenderDocuments(int tenderDocumentId)
        {
            var fileResult = await _tenderDocumentService.DownloadTenderDocumentsAsZipAsync(tenderDocumentId);

            if (fileResult == null)
                return NotFound($"No documents found for Tender with ID {tenderDocumentId}.");

            return fileResult;
        }

        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPost]
        public async Task<IActionResult> InsertTenderDocument([FromForm] InsertTenderDocumentDto dto)
        {

            if (dto.TenderDocumentFile == null  )
            {
                return BadRequest("No files uploaded.");
            }

             
            var result = await _tenderDocumentService.InsertTenderDocumentAsync(dto.TenderDocumentFile, dto.TenderId);

            if (result == null)
            {
                return BadRequest("Failed to Tender Document.");
            }
            return Ok(result);
        }







        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]


        [HttpPut("{TenderDocumentId}")]
        public async Task<IActionResult> UpdateTenderDocument(int TenderDocumentId, [FromForm] UpdateTenderDocumentDto command)
        {
            if (TenderDocumentId <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            

            if (TenderDocumentId != command.TenderDocumentId)
            {
                return BadRequest("TenderDocumentId mismatch.");
            }

            var result = await _tenderDocumentService.UpdateTenderDocumentAsync(command);
            if (result == null)
            {

                return NotFound($"TenderDocument with ID {TenderDocumentId} not found.");

            }
            return Ok(result);
        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int TenderDocumentId)
        {
            if (TenderDocumentId <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderDocumentService.DeleteTenderDocumentAsync(TenderDocumentId);
            if (!result)
            {
                return NotFound($"TenderDocumentId with ID {TenderDocumentId} was not found.");
            }
            return Ok(result);
        }


      



    }

}
