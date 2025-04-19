using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.PaymentTermsQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SKY_Bidding_Management_System_Library.Service.PaymentTermService
{
    public class PaymentTermService : IPaymentTermService
    {
        private readonly IMediator _mediator;

        public PaymentTermService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<int> AddPaymentTermAsync(string paymentSchedule, string paymentMethod, string penaltiesForDelays)
        {
            
            var command = new InsertPaymentTermCommand(paymentSchedule, paymentMethod, penaltiesForDelays);
            if (command == null)
            {
                return 0;
            }
            return await _mediator.Send(command);
        }


        public async Task<List<PaymentTermDto>> GetPaymentTermsAsync()
        {
            var query = new GetPaymentTermsQuery();
            if (query == null)
            {
                return null;
            }
            return await _mediator.Send(query);
        }
        public async Task<PaymentTermDto> GetPaymentTermByIdAsync(int id)
        {
            var paymentTerm = await _mediator.Send(new GetPaymentTermByIdQuery(id));
            if (paymentTerm == null)
            {
                return null;
            }
            return paymentTerm;
        }

        public async Task<PaymentTerm> UpdatePaymentTermAsync(int id, UpdatePaymentTermCommand command)
        {
          var  paymentTerm = await _mediator.Send(command);
            if (paymentTerm == null)
            {
                return null;
            }
            return paymentTerm;  
        }

        public async Task<bool> DeletePaymentTermAsync(int id)
        {
            var paymentTerm = await _mediator.Send(new DeletePaymentTermCommand(id));
            if (paymentTerm == null)
            {
                return false;
            }

            return paymentTerm;
        }
    }
}
