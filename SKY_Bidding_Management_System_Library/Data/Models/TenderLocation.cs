using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SKY_Bidding_Management_System_Library.Data.Models
{
    public class TenderLocation
    {
        [Key]
        public int TenderLocationId { get; set; }
        public string TenderLocationName { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Tender>? Tenders { get; set; }
    }
}
