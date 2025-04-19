using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.BidEvaluationService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SKY_Bidding_Management_System.Controllers
{


    [Authorize()]

    [Route("api/[controller]")]
    [ApiController]
    public class BidEvaluationController : ControllerBase
    {


        private readonly IBidEvaluationService _BidEvaluationService;


        public BidEvaluationController(IBidEvaluationService BidEvaluationService)
        {
            _BidEvaluationService = BidEvaluationService;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]


        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAllBidEvaluations()
        {
            var bidEvaluations = await _BidEvaluationService.GetAllBidEvaluationsAsync();
            if (bidEvaluations == null)
            {
                return NotFound($"BidEvaluation Entity dont have Any BidEvaluations.");
            }
            return Ok(bidEvaluations);
        }


        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]


        [HttpGet("{bidEvaluationId}")]
        public async Task<ActionResult<BidEvaluation>> GetBidEvaluationById(int bidEvaluationId)
        {
            if (bidEvaluationId <= 0 )
            {
                return BadRequest("Invalid ID.");
            }
            var bidEvaluation = await _BidEvaluationService.GetBidEvaluationByIdAsync(bidEvaluationId);
            if (bidEvaluation == null)
            {
                return NotFound($"Bid Evaluation with ID {bidEvaluationId} was not found.");
            }
            return Ok(bidEvaluation);
        }



        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPost]
        public async Task<IActionResult> InsertBidEvaluations([FromBody] InsertBidEvaluationDto BidEvaluationDto)
        {
            if (BidEvaluationDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _BidEvaluationService.InsertBidEvaluation(BidEvaluationDto);
            if (result == null)
            {
                return BadRequest("BidEvaluation with the same name already exists");
            }
            return Ok(result);
        }






        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBidEvaluation(int id, [FromBody] UpdateBidEvaluationCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.BidEvaluationId)
            {
                return BadRequest("ID mismatch.");
            }




            var result = await _BidEvaluationService.UpdateBidEvaluation(id, command);
            if (result == null)
            {

                return NotFound($"BidEvaluation with ID {id} not found.");

            }
            return Ok(result);





        }

        [Authorize(Roles =ClsRoles.roleAdmin)]


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBidEvaluation(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _BidEvaluationService.DeleteBidEvaluationById(id);

            if (!result)
            {
                return NotFound($"BidEvaluation with ID {id} not found.");

            }
            return Ok($"BidEvaluation with ID {id} is Deleted Successfully");

        }
    }
}
