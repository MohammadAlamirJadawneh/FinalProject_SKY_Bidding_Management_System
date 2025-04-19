using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{

    public class TenderIndustry
    {
        [Key]
        public int TenderIndustryId { get; set; }
        public string TenderIndustryName { get; set; }
        public virtual ICollection<Tender> Tenders { get; set; }
    }
}
