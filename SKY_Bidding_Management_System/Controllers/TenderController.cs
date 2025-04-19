using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.Service.TenderService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.EligibilityCriteriaCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;
using System.Text;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TenderController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService, UserManager<AppUser> userManager)
        {
            _tenderService = tenderService;
            _userManager = userManager;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]
        public async Task<IActionResult> GetAllTenders()
        {
            var tenders = await _tenderService.GetAllTendersAsync();
            if (tenders == null)
            {
                return NotFound($"Tender Entity dont have Any Tenders.");
            }
            return Ok(tenders);
        }


        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenderById(int id)
        {
            var tender = await _tenderService.GetTenderByIdAsync(id);
            if (tender == null)
            {
                return NotFound($"Tender with ID {id} not found.");
            }
            return Ok(tender);
        }



        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> InsertTender([FromForm] InsertTenderCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            if (command.Files == null || !command.Files.Any())
            {
                return BadRequest("No files uploaded.");
            }


            var result = await _tenderService.InsertTenderAsync(command);
            if (result == null)
            {
                return BadRequest("Failed to Insert Tender.");
            }
            return Ok(result);

        }

        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTender(int id, [FromBody] UpdateTenderCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.TenderId)
            {
                return BadRequest("ID mismatch.");
            }



            var updatedTender = await _tenderService.UpdateTenderAsync(command);
            if (updatedTender == null)
            {
                return NotFound($"Tender with ID {id} not found.");
            }

            return Ok(updatedTender);
        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTender(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderService.DeleteTenderAsync(id);
            if (!result)
            {
                return NotFound($"Tender with ID {id} not found.");
            }

            return Ok($"Tender with ID {id} is Deleted Successfully");

        }

        [HttpPut("refresh-status")]
        public async Task<IActionResult> RefreshTenderStatuses(CancellationToken cancellationToken)
        {
            await _tenderService.RefreshTenderStatusesAsync(cancellationToken);
            return Ok("Tender statuses updated successfully.");
        }


        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("open")]
        public async Task<IActionResult> GetOpenTenders()
        {

            var openTenders = await _tenderService.GetOpenTendersAsync();
            if (openTenders == null)
            {
                return NotFound($"Tenders with Status Is OPen was not found.");
            }
            return Ok(openTenders);

        }


        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("download/{tenderId}")]
        public async Task<IActionResult> DownloadTenderDocuments(int tenderId)
        {

            var fileResult = await _tenderService.DownloadTenderDocumentsAsZipAsync(tenderId);


            if (fileResult == null)
            {
                return NotFound($"No documents found for Tender with ID {tenderId}.");
            }

            return fileResult;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("GenerateTenderOverview/{tenderId}")]
        public async Task<IActionResult> GenerateTenderOverview(int tenderId)
        {

            var result = await _tenderService.GenerateTenderOverviewAsync(tenderId);
            if (result == null)
            {
                return NotFound($"No GenerateTenderOverviews found for Tender with ID {tenderId}.");
            }
            var bytes = Encoding.UTF8.GetBytes(result);
            return File(bytes, "text/plain", $"Tender_Overview_{tenderId}.txt");

        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("GetTenderScope/{tenderId}")]
        public async Task<IActionResult> GetTenderScope(int tenderId)
        {


            var tenderScope = await _tenderService.GetTenderScopeAsync(tenderId);
            if (tenderScope == null)
            {

                return NotFound($"No documents found for this tender {tenderId}.");
            }
            var tenderScopeText = TenderScopeDocumentTemplateGenerator.GenerateTenderScopeText(tenderScope);

            if (tenderScope == null)
            {

                return NotFound($"No documents found for this tender {tenderId}.");
            }
            var bytes = Encoding.UTF8.GetBytes(tenderScopeText);


            return File(bytes, "text/plain", $"Tender_Scope_{tenderId}.txt");

        }

        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]


        [HttpPost("SetEligibilityCriteria")]
        public async Task<IActionResult> SetEligibilityCriteria(SetEligibilityCriteriaCommand command)
        {

            await _tenderService.SetEligibilityCriteriaAsync(command);
            return Ok("Eligibility criteria updated successfully.");

        }


        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("GetEligibilityCriteria/{tenderId}")]
        public async Task<IActionResult> GetEligibilityCriteria(int tenderId)
        {


            var eligibility = await _tenderService.GetEligibilityCriteriaAsync(tenderId);
            if (eligibility == null)
            {

                return NotFound($"No GetEligibilityCriteria found for this tenderId{tenderId}.");
            }

            var eligibilityText = EligibilityCriteriaDocumentTemplateGenerator.GenerateEligibilityCriteriaText(eligibility);
            if (eligibilityText == null)
            {

                return NotFound($"No GetEligibilityCriteria found for this tenderId{tenderId}.");
            }

            var bytes = Encoding.UTF8.GetBytes(eligibilityText);


            return File(bytes, "text/plain", $"Tender_Eligibility_{tenderId}.txt");

        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("DownloadTenderDocumentContactInfo/{tenderId}")]
        public async Task<IActionResult> DownloadTenderDocumentContactInfo(int tenderId)
        {

            var documentContentBytes = await _tenderService.GenerateTenderContactInfoAsync(tenderId);

            if (documentContentBytes == null || documentContentBytes.Length == 0)
            {
                return NotFound($"TenderDocumentContactInfo documents text found for tender ID {tenderId}.");

            }


            return File(documentContentBytes, "text/plain", $"TenderDocument_ContactInfo_{tenderId}.txt");

        }



    }


}
