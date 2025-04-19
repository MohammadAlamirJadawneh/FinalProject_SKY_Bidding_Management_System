using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderLocation;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderLocation_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries;

namespace SKY_Bidding_Management_System_Library.Service.TenderLocationService
{
    public class TenderLocationService : ITenderLocationService
    {
        

        private readonly IMediator _mediator;

        public TenderLocationService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<List<TenderLocationDto>> GetAllTenderLocationsAsync()
        {
            var query = new GetAllTenderLocationsQuery();
            var result= await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderLocationDto> GetTenderLocationByIdAsync(int tenderLocationId)
        {
            var query = new GetTenderLocationByIdQuery(tenderLocationId);
            var result= await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderLocationDto> InsertTenderLocation(InsertTenderLocationDto tenderLocation)
        {
            var command = new InsertTenderLocationCommand(tenderLocation);

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderLocationDto> UpdateTenderLocation(int tenderLocationId, UpdateTenderLocationCommand tenderLocation)
        {
            var command = new UpdateTenderLocationCommand(tenderLocationId, tenderLocation.tenderLocationName);


            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
        }


        public async Task<bool> DeleteTenderLocationById(int tenderLocationId)
        {
            var command = new DeleteTenderLocationCommand(tenderLocationId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
            return result;

        }


    }
}
