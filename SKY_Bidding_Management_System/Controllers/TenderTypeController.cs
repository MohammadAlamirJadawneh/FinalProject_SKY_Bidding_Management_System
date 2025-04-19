using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.TenderTypeService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands;

namespace SKY_Bidding_Management_System.Controllers
{


    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TenderTypeController : ControllerBase
    {


        private readonly ITenderTypeService _tenderTypeService;


        public TenderTypeController(ITenderTypeService tenderTypeService)
        {
            _tenderTypeService = tenderTypeService;
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]
 

        public async Task<IActionResult> GetAllTenderTypes()
        {
            var tenderTypes = await _tenderTypeService.GetAllTenderTypesAsync();
            if (tenderTypes == null)
            {
                return NotFound($"tenderType Entity dont have Any tenderTypes.");
            }
            return Ok(tenderTypes);
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("{TenderTypeId}")]

        public async Task<ActionResult<TenderType>> GetTenderTypeById(int tenderTypeById)
        {
            if (tenderTypeById <= 0)
            {
                return BadRequest("Invalid ID.");
            }
            var tenderType = await _tenderTypeService.GetTenderTypeByIdAsync(tenderTypeById);

            if (tenderType == null)
            {
                return NotFound($"Tender Type with ID {tenderTypeById} was not found.");
            }
            return Ok(tenderType);


        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]


        [HttpPost]
        public async Task<IActionResult> InsertTenderTypes([FromBody] InsertTenderTypeDto tenderTypeDto)
        {
            if (tenderTypeDto == null)
                return BadRequest("Invalid data.");

            var result = await _tenderTypeService.InsertTenderType(tenderTypeDto);
            if (result == null)
            {
                return BadRequest("TenderType with the same name already exists");
            }
            return Ok(result);
        }




        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenderType(int id, [FromBody] UpdateTenderTypeCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.tenderTypeId)
            {
                return BadRequest("ID mismatch.");
            }


            var result = await _tenderTypeService.UpdateTenderType(id, command);
            if (result == null)
            {
                return BadRequest("TenderType with the same name already exists");
            }
            return Ok(result);



        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenderType(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderTypeService.DeleteTenderTypeById(id);

            if (!result)
            {
                return NotFound("TenderType not found.");
            }
            return Ok($"TenderType with ID {id} is Deleted Successfully");

        }
    }
}
