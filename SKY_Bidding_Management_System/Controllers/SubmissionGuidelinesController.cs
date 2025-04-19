using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.Service.SubmissionGuidelineService;
using System.Text;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize( )]

    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionGuidelinesController : ControllerBase
    {
        private readonly ISubmissionGuidelineService _service;

        public SubmissionGuidelinesController(ISubmissionGuidelineService service)
        {
            _service = service;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("GetSubmissionGuidelines/{tenderId}")]
        public async Task<IActionResult> GetSubmissionGuidelines(int tenderId)
        {


            var submissionGuidelines = await _service.GetSubmissionGuidelinesByTenderIdAsync(tenderId);
            if (submissionGuidelines == null)

            {
                return NotFound($" tender  submission document with ID {tenderId} could not be generated.");

            }

            var guidelineText = SubmissionGuidelineDocumentTemplateGenerator.GenerateSubmissionGuidelineText(submissionGuidelines);
            if (guidelineText.Length == 0)
            {
                return NotFound($" tender proposal document with ID {tenderId} could not be generated.");

            }

            var bytes = Encoding.UTF8.GetBytes(guidelineText);


            return File(bytes, "text/plain", $"Tender_SubmissionGuidelines_{tenderId}.txt");

        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPost]
        public async Task<IActionResult> Create(List<SubmissionGuidelineDto> guidelines)
        {
            if (guidelines == null)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _service.AddSubmissionGuidelinesAsync(guidelines);
            return result ? Ok() : BadRequest();
        }








    }

}
