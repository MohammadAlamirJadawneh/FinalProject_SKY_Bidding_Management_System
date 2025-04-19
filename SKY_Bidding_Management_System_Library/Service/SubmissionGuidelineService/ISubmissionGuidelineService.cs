using SKY_Bidding_Management_System_Library.Data.DTOs.SubmissionGuideline;

namespace SKY_Bidding_Management_System_Library.Service.SubmissionGuidelineService
{
    public interface ISubmissionGuidelineService
    {
        Task<bool> AddSubmissionGuidelinesAsync(List<SubmissionGuidelineDto> guidelines);
        Task<SubmissionGuidelineDto> GetSubmissionGuidelinesByTenderIdAsync(int tenderId);

    }

}
