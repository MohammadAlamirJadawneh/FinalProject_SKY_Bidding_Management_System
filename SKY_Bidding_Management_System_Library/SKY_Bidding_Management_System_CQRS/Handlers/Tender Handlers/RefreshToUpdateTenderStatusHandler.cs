using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.Tender_Handlers
{
    public record RefreshToUpdateTenderStatusHandler(AppDbContext _context)
     : IRequestHandler<RefreshToUpdateTenderStatusCommand, Unit>
    {
        public async Task<Unit> Handle(RefreshToUpdateTenderStatusCommand request, CancellationToken cancellationToken)
        {
            var dateNow = DateTime.Now;

            var tendersToClose = await _context.Tenders
                .Where(t => t.TenderClosingDate <= dateNow)
                .ToListAsync(cancellationToken);

            foreach (var tender in tendersToClose)
            {
                tender.TenderStatus = TenderStatusEnum.Closed;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }



}
