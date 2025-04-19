using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.BidEvaluation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.BidEvaluation_Queries;

namespace SKY_Bidding_Management_System_Library.Service.BidEvaluationService
{

    public class BidEvaluationService : IBidEvaluationService
    {
        private readonly IMediator _mediator;

        public BidEvaluationService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<List<BidEvaluationDto>> GetAllBidEvaluationsAsync()
        {
            var query = new GetAllBidEvaluationsQuery();
            return await _mediator.Send(query);
        }

        public async Task<BidEvaluationDto> GetBidEvaluationByIdAsync(int BidEvaluationId)
        {
            var query = new GetBidEvaluationByIdQuery(BidEvaluationId);
            return await _mediator.Send(query);
        }

        public async Task<BidEvaluationDto> InsertBidEvaluation(InsertBidEvaluationDto BidEvaluation)
        {
            var command = new InsertBidEvaluationCommand(BidEvaluation);
            if (command == null)
            {
                return null;
            }
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<BidEvaluationDto> UpdateBidEvaluation(int id, UpdateBidEvaluationCommand BidEvaluation)
        {
           
            var result = await _mediator.Send(BidEvaluation);
            if (result == null)
            {
                return null;
            }
            return result;
        }
        public async Task<bool> DeleteBidEvaluationById(int BidEvaluationId)
        {
            var command = new DeleteBidEvaluationCommand(BidEvaluationId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
            return result;
        }


    }
}
