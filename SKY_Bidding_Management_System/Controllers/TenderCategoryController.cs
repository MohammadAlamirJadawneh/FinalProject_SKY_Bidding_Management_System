using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.TenderCategoryService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize()]

    [Route("api/[controller]")]
    [ApiController]
    public class TenderCategoryController : ControllerBase
    {


        private readonly ITenderCategoryService _tenderCategoryService;


        public TenderCategoryController(ITenderCategoryService tenderCategoryService)
        {
            _tenderCategoryService = tenderCategoryService;
        }
        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]
        [HttpGet]
        

        public async Task<IActionResult> GetAllTenderCategorys()
        {
            var tenderCategorys = await _tenderCategoryService.GetAllTenderCategoriesAsync();
            if (tenderCategorys == null)
            {
                return NotFound($"BidEvaluation Entity dont have Any BidEvaluations.");
            }
            return Ok(tenderCategorys);
        }

        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]
        [HttpGet("{TenderCategoryId}")]

        public async Task<ActionResult<TenderCategory>> GetTenderCategoryById(int tenderCategoryById)
        {

            var tenderCategory = await _tenderCategoryService.GetTenderCategoryByIdAsync(tenderCategoryById);

            if (tenderCategory == null)
            {
                return NotFound($"Tender Category with ID {tenderCategoryById} was not found.");
            }
            return Ok(tenderCategory);


        }



        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]
        [HttpPost]
        public async Task<IActionResult> InsertTenderCategorys([FromBody] InsertTenderCategoryDto tenderCategoryDto)
        {
            if (tenderCategoryDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _tenderCategoryService.InsertTenderCategory(tenderCategoryDto);
            if (result == null)
            {
                return BadRequest("TenderCategory with the same name already exists");
            }
            return Ok(result);
        }





        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenderCategory(int id, [FromBody] UpdateTenderCategoryCommand command)
        {
            if (id <= 0 || command == null)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.tenderCategoryId)
            {
                return BadRequest("ID mismatch.");
            }



            var result = await _tenderCategoryService.UpdateTenderCategory(id, command);
            if (result == null)
            {
                return BadRequest("TenderCategory with the same name already exists");
            }
            return Ok(result);



        }


        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenderCategory(int id)
        {
             if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var result = await _tenderCategoryService.DeleteTenderCategoryById(id);

            if (!result)
            {
                return NotFound("TenderCategory not found.");
            }
            return Ok($"TenderCategory with ID {id} is Deleted Successfully");

         }
    }
}
