using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.TenderAwardService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize( )]

    [ApiController]
    [Route("api/[controller]")]
    public class TenderAwardController : ControllerBase
    {
        private readonly ITenderAwardService _tenderAwardService;

        public TenderAwardController(ITenderAwardService tenderAwardService)
        {
            _tenderAwardService = tenderAwardService;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]
        [HttpGet]
         
        public async Task<IActionResult> GetAll()
        {

            var tenderAwards = await _tenderAwardService.GetAllTenderAwardsAsync();
            if (tenderAwards == null)
            {
                return NotFound($"tenderAward Entity dont have Any tenderAwards.");
            }
            return Ok(tenderAwards);
        }
        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int tenderAwardById)
        {
            var tenderAwards = await _tenderAwardService.GetTenderAwardByIdAsync(tenderAwardById);

            if (tenderAwards == null)
            {
                return NotFound($"Tender Award with ID {tenderAwardById} was not found.");
            }
            return Ok(tenderAwards);

        }
        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertTenderAwardDto tenderAwardDto)
        {
            if (tenderAwardDto == null)
            {
                return BadRequest("Invalid data.");

            }

            var tenderAwards = await _tenderAwardService.InsertTenderAwardAsync(tenderAwardDto);
            if (tenderAwards == null)
            {
                return BadRequest("BidEvaluation with the same name already exists");
            }

            return Ok(tenderAwards);

        }
        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTenderAwardCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.TenderAwardId)
            {
                return BadRequest("ID mismatch.");
            }


            var result = await _tenderAwardService.UpdateTenderAwardAsync(id, command);
            if (result == null)
            {

                return NotFound($"TenderAward with ID {id} not found.");

            }
            return Ok(result);



        }
        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderAwardService.DeleteTenderAwardAsync(id);

            if (!result)
            {
                return NotFound("TenderAward not found.");
            }

            return Ok("TenderAward deleted successfully.");

        }
    }


}
