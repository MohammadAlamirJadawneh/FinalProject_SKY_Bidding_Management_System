using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderType
    {
        [Key]
        public int TenderTypeId { get; set; }
        public string TenderTypeName { get; set; }
        public virtual ICollection<Tender> Tenders { get; set; }
    }
}
