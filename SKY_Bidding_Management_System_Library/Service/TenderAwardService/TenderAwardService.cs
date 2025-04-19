using MediatR;
using Microsoft.AspNetCore.SignalR.Protocol;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderAward_Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SKY_Bidding_Management_System_Library.Service.TenderAwardService
{
    public class TenderAwardService : ITenderAwardService
    {
        private readonly IMediator _mediator;

        public TenderAwardService(IMediator mediator) => _mediator = mediator;

        public async Task<List<TenderAwardDto>> GetAllTenderAwardsAsync()
            => await _mediator.Send(new GetAllTenderAwardsQuery());

        public async Task<TenderAwardDto> GetTenderAwardByIdAsync(int id)
            => await _mediator.Send(new GetTenderAwardByIdQuery(id));

        public async Task<TenderAwardDto> InsertTenderAwardAsync(InsertTenderAwardDto dto)
            => await _mediator.Send(new InsertTenderAwardCommand(dto));

        public async Task<TenderAwardDto> UpdateTenderAwardAsync(int id, UpdateTenderAwardCommand command)
        {
            if (id != command.TenderAwardId) return null;
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> DeleteTenderAwardAsync(int id)
        {
            var result = await _mediator.Send(new DeleteTenderAwardCommand(id));
            
            if (result == null)
            {
                return false;
            }
            return result;
        }
    }
}
