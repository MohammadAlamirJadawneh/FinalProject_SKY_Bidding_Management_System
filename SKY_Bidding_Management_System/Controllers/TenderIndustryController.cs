using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.TenderIndustryService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize()]

    [Route("api/[controller]")]
    [ApiController]
    public class TenderIndustryController : ControllerBase
    {


        private readonly ITenderIndustryService _tenderIndustryService;


        public TenderIndustryController(ITenderIndustryService tenderIndustryService)
        {
            _tenderIndustryService = tenderIndustryService;
        }
        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]


        public async Task<IActionResult> GetAllTenderIndustrys()
        {
            var tenderIndustries = await _tenderIndustryService.GetAllTenderIndustrysAsync();
            if (tenderIndustries == null)
            {
                return NotFound($"TenderIndustry Entity dont have Any TenderIndustries.");
            }
            return Ok(tenderIndustries);
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]


        [HttpGet("{TenderIndustryId}")]

        public async Task<ActionResult<TenderIndustry>> GetTenderIndustryById(int tenderIndustryById)
        {
            if (tenderIndustryById <= 0)
            {
                return BadRequest("Invalid ID.");
            }
            var tenderIndustry = await _tenderIndustryService.GetTenderIndustryByIdAsync(tenderIndustryById);

            if (tenderIndustry == null)
            {
                return NotFound($"Tender Industry with ID {tenderIndustryById} was not found.");
            }
            return Ok(tenderIndustry);


        }



        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPost]
        public async Task<IActionResult> InsertTenderIndustrys([FromBody] InsertTenderIndustryDto tenderIndustryDto)
        {
            if (tenderIndustryDto == null || string.IsNullOrWhiteSpace(tenderIndustryDto.TenderIndustryName))
                return BadRequest("Invalid data.");

            var result = await _tenderIndustryService.InsertTenderIndustry(tenderIndustryDto);
            if (result == null)
            {
                return BadRequest("TenderIndustry with the same name already exists");
            }
            return Ok(result);
        }






        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenderIndustry(int id, [FromBody] UpdateTenderIndustryCommand command)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            if (command == null || string.IsNullOrWhiteSpace(command.tenderIndustryName))
            {
                return BadRequest("Invalid data.");
            }



            var result = await _tenderIndustryService.UpdateTenderIndustry(id, command);
            if (result == null)
            {
                return BadRequest("TenderIndustry with the same name already exists");
            }
            return Ok(result);





        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenderIndustry(int id)
        {
            // Ensure the id is valid
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderIndustryService.DeleteTenderIndustryById(id);

            if (!result)
            {
                return NotFound("TenderIndustry not found.");
            }

            return Ok("TenderIndustry deleted successfully.");
        }
    }
}
