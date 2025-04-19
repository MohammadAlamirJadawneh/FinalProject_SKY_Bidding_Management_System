using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderType_Queries;

namespace SKY_Bidding_Management_System_Library.Service.TenderTypeService
{
    public class TenderTypeService : ITenderTypeService
    {
        

        private readonly IMediator _mediator;

        public TenderTypeService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<List<TenderTypeDto>> GetAllTenderTypesAsync()
        {
            var query = new GetAllTenderTypesQuery();
           var result=   await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderTypeDto> GetTenderTypeByIdAsync(int tenderTypeId)
        {
            var query = new GetTenderTypeByIdQuery(tenderTypeId);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderTypeDto> InsertTenderType(InsertTenderTypeDto tenderType)
        {
            var command = new InsertTenderTypeCommand(tenderType);
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

        public async Task<TenderTypeDto> UpdateTenderType(int tenderTypeId, UpdateTenderTypeCommand tenderType)
        {
            var command = new UpdateTenderTypeCommand(tenderTypeId, tenderType.tenderTypeName);
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


        public async Task<bool> DeleteTenderTypeById(int tenderTypeId)
        {
            var command = new DeleteTenderTypeCommand(tenderTypeId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
            return result;
        }


    }
}
