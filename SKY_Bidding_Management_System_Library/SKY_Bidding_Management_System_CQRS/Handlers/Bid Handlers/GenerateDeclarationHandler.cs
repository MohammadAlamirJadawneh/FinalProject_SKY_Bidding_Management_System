using MediatR;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Bid_Handlers
{
    public record GenerateDeclarationHandler : IRequestHandler<GenerateDeclarationCommand, string>
    {
        public Task<string> Handle(GenerateDeclarationCommand request, CancellationToken cancellationToken)
        {
            
            var declarationText = DeclarationTextGenerator.GenerateDeclarationText(request.DeclarationDto);

            return Task.FromResult(declarationText);
        }
    }
 
}
