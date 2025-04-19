using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.Data.Models;

using SKY_Bidding_Management_System_Library.Service.TenderLocationService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands;


namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TenderLocationController : ControllerBase
    {


        private readonly ITenderLocationService _tenderLocationService;


        public TenderLocationController(ITenderLocationService tenderLocationService)
        {
            _tenderLocationService = tenderLocationService;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]
   

        public async Task<IActionResult> GetAllTenderLocations()
        {
            var tenderLocations = await _tenderLocationService.GetAllTenderLocationsAsync();
            if (tenderLocations == null)
            {
                return NotFound($"TenderLocation Entity dont have Any TenderLocations.");
            }
            return Ok(tenderLocations);
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("{TenderLocationId}")]

        public async Task<ActionResult<TenderLocation>> GetTenderLocationById(int tenderLocationById)
        {
            if (tenderLocationById <= 0)
            {
                return BadRequest("Invalid ID.");
            }
            var tenderLocation = await _tenderLocationService.GetTenderLocationByIdAsync(tenderLocationById);

            if (tenderLocation == null)
            {
                return NotFound($"Tender Location with ID {tenderLocationById} was not found.");
            }
            return Ok(tenderLocation);


        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]


        [HttpPost]
        public async Task<IActionResult> InsertTenderLocations([FromBody] InsertTenderLocationDto tenderLocationDto)
        {
            if (tenderLocationDto == null  )
                return BadRequest("Invalid data.");

            var result = await _tenderLocationService.InsertTenderLocation(tenderLocationDto);
            if (result == null)
            {
                return BadRequest("TenderLocation with the same name already exists");
            }
            return Ok(result);
        }





        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenderLocation(int id, [FromBody] UpdateTenderLocationCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.tenderLocationId)
            {
                return BadRequest("ID mismatch.");
            }


             
                var result = await _tenderLocationService.UpdateTenderLocation(id, command);
                if (result == null)
                {
                    return BadRequest("TenderLocation with the same name already exists");
                }
                return Ok(result);
            


        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenderLocation(int id)
        {
           
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderLocationService.DeleteTenderLocationById(id);

            if (!result)
            {
                return NotFound("TenderLocation not found.");
            }

            return Ok($"TenderLocation with ID {id} is Deleted Successfully");
        }
    }
}
