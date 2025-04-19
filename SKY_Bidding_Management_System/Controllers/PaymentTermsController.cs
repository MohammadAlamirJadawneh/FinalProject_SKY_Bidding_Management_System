using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.Service.PaymentTermService;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands;
using System.Text;

namespace SKY_Bidding_Management_System.Controllers
{
    [Authorize( )]

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermsController : ControllerBase
    {
        private readonly IPaymentTermService _paymentTermService;

        public PaymentTermsController(IPaymentTermService paymentTermService)
        {
            _paymentTermService = paymentTermService;
        }
     
        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet]
        public async Task<IActionResult> GetPaymentTerms()
        {

            var paymentTerms = await _paymentTermService.GetPaymentTermsAsync();
            if (paymentTerms == null)
            {
                return NotFound($"paymentTerm Entity dont have Any paymentTerms.");
            }
            return Ok(paymentTerms);

        }


        [Authorize(Roles = $"{ClsRoles.roleUser},{ClsRoles.roleAdmin}")]

        [HttpGet("GetPaymentTerm/{id}")]
        public async Task<IActionResult> GetPaymentTermById(int id)
        {

            var paymentTerm = await _paymentTermService.GetPaymentTermByIdAsync(id);

            if (paymentTerm == null)
            {
                return NotFound($"Bid Term with ID {id} was not found.");
            }


            var paymentTermText = PaymentTermTextGenerator.GeneratePaymentTermText(paymentTerm);


            var bytes = Encoding.UTF8.GetBytes(paymentTermText);


            return File(bytes, "text/plain", $"PaymentTerm_{id}.txt");

        }

        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPost]
        public async Task<IActionResult> CreatePaymentTerm([FromBody] PaymentTermDto paymentTermDto)
        {
            if (paymentTermDto == null)
            {
                return BadRequest("Invalid data.");
            }


            var result = await _paymentTermService.AddPaymentTermAsync(
                paymentTermDto.PaymentSchedule,
                paymentTermDto.PaymentMethod,
                paymentTermDto.PenaltiesForDelays
            );

            if (result == null)
            {
                return BadRequest("BidETerm with the same name already exists");
            }
            return Ok();

        }

        [Authorize(Roles = $" {ClsRoles.roleAdmin}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePaymentTermCommand command)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            if (id != command.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _paymentTermService.UpdatePaymentTermAsync(id, command);


            if (result == null)
            {

                return NotFound($"BidTerm with ID {id} not found.");

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

            var result = await _paymentTermService.DeletePaymentTermAsync(id);

            if (!result)
            {
                return NotFound($"BidTerm with ID {id} not found.");
                 
            }
            return Ok($"BidTerm with ID {id} is Deleted Successfully");

         }






    }

}
