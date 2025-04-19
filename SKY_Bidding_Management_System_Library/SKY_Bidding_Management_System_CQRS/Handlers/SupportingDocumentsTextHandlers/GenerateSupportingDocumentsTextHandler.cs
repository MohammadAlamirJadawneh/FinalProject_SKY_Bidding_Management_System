using MediatR;
using SKY_Bidding_Management_System_Library.Helpers;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.SupportingDocumentsTextCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.SupportingDocumentsTextCommandHandlers
{
    public record GenerateSupportingDocumentsTextCommandHandler : IRequestHandler<GenerateSupportingDocumentsTextCommand, string>
    {
        public Task<string> Handle(GenerateSupportingDocumentsTextCommand request, CancellationToken cancellationToken)
        {
            
            var text = SupportingDocumentGenerator.GenerateSupportingDocumentsText(request.SupportingDocuments);

            return Task.FromResult(text);
        }
    }

     






}
