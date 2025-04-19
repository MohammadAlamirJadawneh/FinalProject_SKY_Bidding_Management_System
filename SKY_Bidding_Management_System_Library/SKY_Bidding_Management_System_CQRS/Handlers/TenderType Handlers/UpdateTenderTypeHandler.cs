using MediatR;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderType;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderType_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderType_Handlers
{


    public record UpdateTenderTypeHandler : IRequestHandler<UpdateTenderTypeCommand, TenderTypeDto>
    {
        private readonly AppDbContext _db;

        public UpdateTenderTypeHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TenderTypeDto> Handle(UpdateTenderTypeCommand request, CancellationToken cancellationToken)
        {
            if (await _db.TenderTypes
                .AnyAsync(tl => tl.TenderTypeName == request.tenderTypeName, cancellationToken))
            {
                Console.WriteLine("TenderType with the same name already exists.");
                return null;
            }

            
            var tenderType = await _db.TenderTypes.FindAsync(request.tenderTypeId);

            if (tenderType == null)
            {
                Console.WriteLine("TenderType not found.");
                return null;
            }

           
            tenderType.TenderTypeName = request.tenderTypeName;

            
            await _db.SaveChangesAsync(cancellationToken);

         
            return new TenderTypeDto
            {
                TenderTypeId = tenderType.TenderTypeId,
                TenderTypeName = tenderType.TenderTypeName
            };
        }
    }
}
