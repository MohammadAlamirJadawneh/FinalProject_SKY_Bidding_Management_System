using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderCategory
    {
        [Key]
        public int TenderCategoryId { get; set; }
        public string TenderCategoryName { get; set; }
        public virtual ICollection<Tender> Tenders { get; set; }
    }
}
