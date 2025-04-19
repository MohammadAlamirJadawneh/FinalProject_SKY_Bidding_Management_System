using System.ComponentModel.DataAnnotations;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class PaymentTerm
    {

        [Key]
        public int PaymentTermId { get; set; }
        public string PaymentSchedule { get; set; }
        public string PaymentMethod { get; set; }
        public string PenaltiesForDelays { get; set; }
    }

}
