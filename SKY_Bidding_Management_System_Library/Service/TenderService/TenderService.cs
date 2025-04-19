using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data.DTOs.EligibilityCriteria;
using SKY_Bidding_Management_System_Library.Data.DTOs.Tender;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidEvaluationCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.EligibilityCriteriaCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.EligibilityCriteriaQueries;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Service.TenderService
{
    public class TenderService : ITenderService
    {
        private readonly IMediator _mediator;

        public TenderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TenderDto> GetTenderByIdAsync(int tenderId)
        {
            var query = new SKY_Bidding_Management_System_CQRS.Queries.Tender_Queries.GetTenderByIdQuery(tenderId);
            var result= await _mediator.Send(query);

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<TenderDto>> GetAllTendersAsync()
        {
            var query = new GetAllTenderQuery();
            var result= await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderDto> InsertTenderAsync(InsertTenderCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderDto> UpdateTenderAsync(UpdateTenderCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> DeleteTenderAsync(int tenderId)
        {
            var command = new DeleteTenderCommand(tenderId);
            var result= await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
            return result;
        }
        public async Task<IEnumerable<TenderDto>> GetOpenTendersAsync()
        {
            var result = await _mediator.Send(new GetOpenTendersQuery());
            if (result == null)
            {
                return null;
            }
            return result;
        }
        public async Task<FileContentResult?> DownloadTenderDocumentsAsZipAsync(int tenderId)
        {
            
            var query = new DownloadTenderDocumentsAsZipQuery(tenderId);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<string> GenerateTenderOverviewAsync(int tenderId)
        {
            var result = await _mediator.Send(new GenerateTenderOverviewQuery(tenderId));
            if (result == null)
            {
                return null;
            }
            return result;
        }
        public async Task<TenderScopeDto> GetTenderScopeAsync(int tenderId)
        {
            var result = await _mediator.Send(new GetTenderScopeQuery(tenderId));
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task SetEligibilityCriteriaAsync(SetEligibilityCriteriaCommand criteriaCommand)
        {
          

            await _mediator.Send(criteriaCommand);

        }

        public async Task<EligibilityCriteriaDto> GetEligibilityCriteriaAsync(int tenderId)
        {
            
            var query = new GetEligibilityCriteriaQuery(tenderId);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<byte[]> GenerateTenderContactInfoAsync(int tenderId)
        {
            
            var query = new GetTenderByIdQuery(tenderId);  
 
            var tender = await _mediator.Send(query);

            if (tender == null)
            {
                return null;
            }

             
            var documentContent = TenderContactInformationGenerator.GenerateContactInfoText(tender);

         
            return Encoding.UTF8.GetBytes(documentContent);
        }

        public async Task RefreshTenderStatusesAsync(CancellationToken cancellationToken)
        {
            await _mediator.Send(new RefreshToUpdateTenderStatusCommand(), cancellationToken);
        }

    }

}
