using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.Bid;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.BidCommands
{
    public record GenerateDeclarationCommand(DeclarationDto DeclarationDto) : IRequest<string>;

     

}
