namespace SKY_Bidding_Management_System_Library.Data.DTOs.Tender
{
    public class TenderScopeDto
    {
        public string ProjectDescription { get; set; }
        public List<string> Deliverables { get; set; }
        public List<TenderTimelineItem> ExpectedTimeline { get; set; }
    }

}
