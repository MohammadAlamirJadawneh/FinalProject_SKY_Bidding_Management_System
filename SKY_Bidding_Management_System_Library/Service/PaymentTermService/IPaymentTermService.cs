using SKY_Bidding_Management_System_Library.Data.DTOs.NewFolder;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.PaymentTermCommands;

namespace SKY_Bidding_Management_System_Library.Service.PaymentTermService
{
    public interface IPaymentTermService
    {
        Task<int> AddPaymentTermAsync(string paymentSchedule, string paymentMethod, string penaltiesForDelays);
        Task<List<PaymentTermDto>> GetPaymentTermsAsync();
        Task<PaymentTermDto> GetPaymentTermByIdAsync(int id);
        Task<PaymentTerm> UpdatePaymentTermAsync(int id, UpdatePaymentTermCommand command);
        Task<bool> DeletePaymentTermAsync(int id);
    }
}
