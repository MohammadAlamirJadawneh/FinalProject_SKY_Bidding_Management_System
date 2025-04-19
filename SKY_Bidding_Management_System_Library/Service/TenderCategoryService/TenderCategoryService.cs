using MediatR;
using SKY_Bidding_Management_System_Library.Data.DTOs.TenderCategory;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.TenderCategory_Commands;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Queries.TenderCategory_Queries;

namespace SKY_Bidding_Management_System_Library.Service.TenderCategoryService
{

    public class TenderCategoryService : ITenderCategoryService
    {
       

        private readonly IMediator _mediator;

        public TenderCategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<List<TenderCategoryDto>> GetAllTenderCategoriesAsync()
        {
            var query = new GetAllTenderCategoriesQuery();
          var  result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderCategoryDto> GetTenderCategoryByIdAsync(int tenderCategoryId)
        {
            var query = new GetTenderCategoryByIdQuery(tenderCategoryId);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<TenderCategoryDto> InsertTenderCategory(InsertTenderCategoryDto tenderCategory)
        {
            var command = new InsertTenderCategoryCommand(tenderCategory);
            if (command == null)
            {
                return null;
            }
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
            return result;
        }

        public async Task<TenderCategoryDto> UpdateTenderCategory(int tenderCategoryId, UpdateTenderCategoryCommand tenderCategory)
        {
            var command = new UpdateTenderCategoryCommand(tenderCategoryId, tenderCategory.tenderCategoryName);
            if (command == null)
            {
                return null;
            }
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return null;
            }
            return result;
         
        }


        public async Task<bool> DeleteTenderCategoryById(int tenderCategoryId)
        {
            var command = new DeleteTenderCategoryCommand(tenderCategoryId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return false;
            }
         
            return result;
        }


    }
}
