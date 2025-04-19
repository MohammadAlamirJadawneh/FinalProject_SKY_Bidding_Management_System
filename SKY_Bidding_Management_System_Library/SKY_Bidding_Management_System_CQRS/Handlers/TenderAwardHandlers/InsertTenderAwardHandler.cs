using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderAwardHandlers
{
    public record InsertTenderAwardHandler(AppDbContext Db) : IRequestHandler<InsertTenderAwardCommand, TenderAwardDto>
    {
        public async Task<TenderAwardDto> Handle(InsertTenderAwardCommand request, CancellationToken cancellationToken)
        {
          
            if (await Db.TenderAwards
                .AnyAsync(a => a.TenderId == request.TenderAward.TenderId
                            && a.BidId == request.TenderAward.BidId, cancellationToken))
            {
                Console.WriteLine("TenderAward for this Tender and Bid already exists.");
                return null!;
            }

         
            var tenderAward = new TenderAward
            {
                TenderId = request.TenderAward.TenderId,
                BidId = request.TenderAward.BidId,
                AwardDate = request.TenderAward.AwardDate,
                AwardStatus = request.TenderAward.AwardStatus
            };

             
            await Db.TenderAwards.AddAsync(tenderAward, cancellationToken);
            await Db.SaveChangesAsync(cancellationToken);

         
            return new TenderAwardDto
            {
                TenderAwardId = tenderAward.TenderAwardId,
                TenderId = tenderAward.TenderId,
                BidId = tenderAward.BidId,
                AwardDate = tenderAward.AwardDate,
                AwardStatus = tenderAward.AwardStatus
            };
        }
    }
 

}
