namespace SKY_Bidding_Management_System_Library.Data.DTOs.EligibilityCriteria
{
    public class EligibilityCriteriaDto
    {
        public bool IsRegisteredCompany { get; set; }
        public bool HasMinimumExperience { get; set; }
        public bool IsFinanciallyStable { get; set; }
        public bool HasPastExperience { get; set; }
        public bool CompliesWithIndustryStandards { get; set; }
        public int TenderId { get; set; }
    }

}
