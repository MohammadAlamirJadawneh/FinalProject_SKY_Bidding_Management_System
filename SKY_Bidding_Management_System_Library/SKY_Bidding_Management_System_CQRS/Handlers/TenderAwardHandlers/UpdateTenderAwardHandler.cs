using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderAward;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderAwardCommands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderAwardHandlers
{
    public record UpdateTenderAwardHandler : IRequestHandler<UpdateTenderAwardCommand, TenderAwardDto>
    {
        private readonly AppDbContext _db;

        public UpdateTenderAwardHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TenderAwardDto> Handle(UpdateTenderAwardCommand request, CancellationToken cancellationToken)
        {
            
            if (await _db.TenderAwards
                .AnyAsync(a => a.TenderId == request.TenderId
                            && a.BidId == request.BidId
                            && a.TenderAwardId != request.TenderAwardId, cancellationToken))
            {
                Console.WriteLine("TenderAward with the same Tender and Bid already exists.");
                return null;
            }

             var tenderAward = await _db.TenderAwards.FindAsync(request.TenderAwardId);

            if (tenderAward == null)
            {
                Console.WriteLine("TenderAward not found.");
                return null;
            }

             tenderAward.TenderId = request.TenderId;
            tenderAward.BidId = request.BidId;
            tenderAward.AwardDate = request.AwardDate;
            tenderAward.AwardStatus = request.AwardStatus;

             await _db.SaveChangesAsync(cancellationToken);

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
