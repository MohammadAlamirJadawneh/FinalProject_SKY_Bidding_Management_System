using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderIndustry;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderIndustry_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderIndustry_Queries;

namespace SKY_Bidding_Management_System_Library.Service.TenderIndustryService
{
    public class TenderIndustryService : ITenderIndustryService
    {
        private readonly IMediator _mediator;

        public TenderIndustryService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<List<TenderIndustryDto>> GetAllTenderIndustrysAsync()
        {
            var query = new GetAllTenderIndustryQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderIndustryDto> GetTenderIndustryByIdAsync(int tenderIndustryId)
        {
            var query = new GetTenderIndustryByIdQuery(tenderIndustryId);
            var result= await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderIndustryDto> InsertTenderIndustry(InsertTenderIndustryDto tenderIndustry)
        {
            var command = new InsertTenderIndustryCommand(tenderIndustry);
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

        public async Task<TenderIndustryDto> UpdateTenderIndustry(int tenderIndustryId, UpdateTenderIndustryCommand tenderIndustry)
        {
            var command = new UpdateTenderIndustryCommand(tenderIndustryId, tenderIndustry.tenderIndustryName);
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


        public async Task<bool> DeleteTenderIndustryById(int tenderIndustryId)
        {
            var command = new DeleteTenderIndustryCommand(tenderIndustryId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
            return result;
        }


    }
}
