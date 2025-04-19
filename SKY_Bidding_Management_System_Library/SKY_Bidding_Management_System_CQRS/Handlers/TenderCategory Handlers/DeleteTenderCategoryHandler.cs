using MediatR;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Handlers.TenderCategory_Handlers
{

    public record DeleteTenderCategoryHandler : IRequestHandler<DeleteTenderCategoryCommand, bool>
    {
        private readonly AppDbContext _db;

        public DeleteTenderCategoryHandler(AppDbContext db)
        {

            _db = db;
        }

        public async Task<bool> Handle(DeleteTenderCategoryCommand request, CancellationToken cancellationToken)
        {
            var tenderCategory = await _db.TenderCategories.FindAsync(request.TenderCategoryId);

            if (tenderCategory == null)
            {
                Console.WriteLine($"tenderCategory with ID {request.TenderCategoryId} not found.");
                return false;
            }

            _db.TenderCategories.Remove(tenderCategory);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
