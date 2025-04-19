using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.TenderEvaluationService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands;

namespace SKY_Bidding_Management_System.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TenderEvaluationController : ControllerBase
    {


        private readonly ITenderEvaluationService _tenderEvaluationService;


        public TenderEvaluationController(ITenderEvaluationService tenderEvaluationService)
        {
            _tenderEvaluationService = tenderEvaluationService;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]
         
        public async Task<IActionResult> GetAllTenderEvaluations()
        {
            var tenderEvaluations = await _tenderEvaluationService.GetAllTenderEvaluationsAsync();
            if (tenderEvaluations == null)
            {
                return NotFound($"TenderEvaluation  Entity dont have Any TenderEvaluations.");
            }
            return Ok(tenderEvaluations);
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("{TenderEvaluationId}")]

        public async Task<ActionResult<TenderEvaluation>> GetTenderEvaluationById(int tenderEvaluationById)
        {

            var tenderEvaluation = await _tenderEvaluationService.GetTenderEvaluationByIdAsync(tenderEvaluationById);

            if (tenderEvaluation == null)
            {
                return NotFound($"Tender Evaluation with ID {tenderEvaluationById} was not found.");
            }
            return Ok(tenderEvaluation);


        }



        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPost]
        public async Task<IActionResult> InsertTenderEvaluations([FromBody] InsertTenderEvaluationDto tenderEvaluationDto)
        {
            if (tenderEvaluationDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _tenderEvaluationService.InsertTenderEvaluation(tenderEvaluationDto);
            if (result == null)
            {
                return BadRequest("TenderEvaluation with the same name already exists");
            }
            return Ok(result);
        }






        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenderEvaluation(int id, [FromBody] UpdateTenderEvaluationCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.TenderEvaluationId)
            {
                return BadRequest("ID mismatch.");
            }

            var result = await _tenderEvaluationService.UpdateTenderEvaluation(id, command);
            if (result == null)
            {
                return BadRequest("TenderEvaluation with the same name already exists");
            }
            return Ok(result);



        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenderEvaluation(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderEvaluationService.DeleteTenderEvaluationById(id);

            if (!result)
            {
                return NotFound("TenderEvaluation not found.");
            }
            return Ok($"TenderEvaluation with ID {id} is Deleted Successfully");

        }
    }
}
