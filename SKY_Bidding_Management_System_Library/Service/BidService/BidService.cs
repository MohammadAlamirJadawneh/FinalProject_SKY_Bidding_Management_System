using MediatR;
using Microsoft.AspNetCore.Mvc;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Bid_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.SupportingDocumentsTextCommands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.Bid_Queries;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.SupportingDocumentsTextQueries;
using System.Text;

namespace SKY_Bidding_Management_System_Library.Service.BidService
{
    public class BidService : IBidService
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        public BidService(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public Task<BidDto> InsertBidAsync(InsertBidCommand command) => _mediator.Send(command);

        public Task<BidDto> UpdateBidAsync(UpdateBidCommand command) => _mediator.Send(command);
        public Task<bool> DeleteBidAsync(DeleteBidCommand command) => _mediator.Send(command);
        public Task<BidDto> GetBidByIdAsync(GetBidByIdQuery query) => _mediator.Send(query);
        public Task<List<BidDto>> GetAllBidsAsync(GetAllBidsQuery query) => _mediator.Send(query);


        public async Task<FileContentResult> DownloadBidDocumentsAsZipAsync(int bidId)
        {
            return await _mediator.Send(new DownloadBidDocumentsZipQuery(bidId));

        }


        public async Task<byte[]> GenerateBidSubmissionDocumentAsync(int bidId)
        {
            
            var query = new GetBidInformationByIdQuery(bidId);
            var bidderInformation = await _mediator.Send(query);

            if (bidderInformation == null)
            {
                return null;
            }

         
            var documentContent = BidDocumentGenerator.GenerateBidSubmissionText(
                bidderInformation.BidId,
                bidderInformation.CompanyName,
                bidderInformation.RegistrationNumber,
                bidderInformation.Address,
                bidderInformation.Email,
                bidderInformation.Phone

            );

             
            return Encoding.UTF8.GetBytes(documentContent);
        }

        public async Task<byte[]> GenerateBidProposalDocumentAsync(int bidId)
        {
             
            var bidProposal = await _mediator.Send(new GetBidProposalQuery(bidId));
            if (bidProposal == null)
            {
                return null;
            }
            

            var documentContent = BidProposalGenerator.GenerateBidProposalText(bidProposal);
            
            
            return Encoding.UTF8.GetBytes(documentContent);
        }

        public async Task<string> GenerateSupportingDocumentsText(int bidId)
        {
             
            var supportingDocuments = await _mediator.Send(new GetSupportingDocumentsQuery(bidId));

           
            if (!supportingDocuments.Any())
            {
                return null ;
            }

           
            return await _mediator.Send(new GenerateSupportingDocumentsTextCommand(bidId, supportingDocuments));
        }


        public async Task<string> GenerateDeclarationText(string companyName, string authorizedSignatory, DateTime submissionDate)
        {
             
                var declaration = new DeclarationDto
                {
                    CompanyName = companyName,
                    AuthorizedSignatory = authorizedSignatory,
                    SubmissionDate = submissionDate
                };
            if (declaration == null)
            {
                return null;
            }
                var command = new GenerateDeclarationCommand(declaration);

                
                return await _mediator.Send(command);
             
        }

         
    }


}
