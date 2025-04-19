using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderEvaluation_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderEvaluation_Queries;

namespace SKY_Bidding_Management_System_Library.Service.TenderEvaluationService
{
    public class TenderEvaluationService : ITenderEvaluationService
    {
        private readonly IMediator _mediator;

        public TenderEvaluationService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<List<TenderEvaluationDto>> GetAllTenderEvaluationsAsync()
        {
            var query = new GetAllTenderEvaluationsQuery();

          var result=  await _mediator.Send(query); 
            if (result == null)
            {
                return null;
            }

            return result;
            
        }

        public async Task<TenderEvaluationDto> GetTenderEvaluationByIdAsync(int tenderEvaluationId)
        {
            var query = new GetTenderEvaluationByIdQuery(tenderEvaluationId);
          var result=  await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }

            return result;
             
        }

        public async Task<TenderEvaluationDto> InsertTenderEvaluation(InsertTenderEvaluationDto tenderEvaluation)
        {
            var command = new InsertTenderEvaluationCommand(tenderEvaluation);
            if (command == null)
            {
                return null;
            }
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }

            return result;
          
        }

        public async Task<TenderEvaluationDto> UpdateTenderEvaluation(int id, UpdateTenderEvaluationCommand tenderEvaluation)
        {
            if (tenderEvaluation == null)
            {
                return null;
            }
            var result = await _mediator.Send(tenderEvaluation);
            if (result == null)
            {
                return null;
            }

             
            return result;
        }
        public async Task<bool> DeleteTenderEvaluationById(int tenderEvaluationId)
        {
            var command = new DeleteTenderEvaluationCommand(tenderEvaluationId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }

            return result;
        }
    }
}
