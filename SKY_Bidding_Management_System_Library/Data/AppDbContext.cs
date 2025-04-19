using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.Models;
namespace SKY_Bidding_Management_System_Library.Data
{
    //public class AppDbContext : IdentityDbContext<
    //   AppUser,
    //   IdentityRole<int>,
    //   int,
    //   IdentityUserClaim<int>,
    //   IdentityUserRole<int>,
    //   IdentityUserLogin<int>,
    //   IdentityRoleClaim<int>,
    //   IdentityUserToken<int>>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<BidDocument> BidDocuments { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderDocument> TenderDocuments { get; set; }
        public DbSet<TenderAward> TenderAwards { get; set; }
        public DbSet<TenderCategory> TenderCategories { get; set; }
        public DbSet<TenderEvaluation> TenderEvaluations { get; set; }
        public DbSet<BidEvaluation> BidEvaluations { get; set; }
        public DbSet<TenderLocation> TenderLocations { get; set; }
        public DbSet<TenderType> TenderTypes { get; set; }
        public DbSet<TenderIndustry> TenderIndustries { get; set; }
        public DbSet<EligibilityCriteria> EligibilityCriterias { get; set; }
        public DbSet<TenderEligibility> TenderEligibilities { get; set; }
        public DbSet<SubmissionGuideline> SubmissionGuidelines { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<FinancialProposalItem> FinancialProposalItems { get; set; }
        public DbSet<SupportingDocument> SupportingDocuments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*
                        modelBuilder.Entity<IdentityUserLogin<string>>()
                        .HasKey(login => login.UserId);


                        modelBuilder.Entity<Bid>()
                       .HasMany(b => b.BidDocument)
                       .WithOne(bd => bd.Bid)
                       .HasForeignKey(bd => bd.BidId);

                        var roleAdmin = "role-admin-id";
                        var roleUser = "role-user-id";

                        modelBuilder.Entity<IdentityRole>().HasData(
                                   new IdentityRole
                                   {
                                       Id = roleAdmin,
                                       Name = "Admin",
                                       NormalizedName = "ADMIN",
                                       ConcurrencyStamp = "static-security-stamp-001",
                                   },
                new IdentityRole
                {
                    Id = roleUser,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "static-security-stamp-001",
                }
            );
            */



            modelBuilder.Entity<TenderCategory>().HasData(
                   new TenderCategory { TenderCategoryId = 1, TenderCategoryName = "Construction" },
                   new TenderCategory { TenderCategoryId = 2, TenderCategoryName = "IT Services" },
                   new TenderCategory { TenderCategoryId = 3, TenderCategoryName = "Consulting" },
                   new TenderCategory { TenderCategoryId = 4, TenderCategoryName = "Healthcare" },
                   new TenderCategory { TenderCategoryId = 5, TenderCategoryName = "Transport" }
               );

            modelBuilder.Entity<TenderType>().HasData(
                new TenderType { TenderTypeId = 1, TenderTypeName = "Open" },
                new TenderType { TenderTypeId = 2, TenderTypeName = "Selective" },
                new TenderType { TenderTypeId = 3, TenderTypeName = "Negotiated" },
                new TenderType { TenderTypeId = 4, TenderTypeName = "Framework Agreement" },
                new TenderType { TenderTypeId = 5, TenderTypeName = "Dynamic Purchasing" }
            );

            modelBuilder.Entity<TenderLocation>().HasData(
                new TenderLocation { TenderLocationId = 1, TenderLocationName = "Amman" },
                new TenderLocation { TenderLocationId = 2, TenderLocationName = "Irbid" },
                new TenderLocation { TenderLocationId = 3, TenderLocationName = "Aqaba" },
                new TenderLocation { TenderLocationId = 4, TenderLocationName = "Zarqa" },
                new TenderLocation { TenderLocationId = 5, TenderLocationName = "Madaba" }
            );

            modelBuilder.Entity<TenderIndustry>().HasData(
                new TenderIndustry { TenderIndustryId = 1, TenderIndustryName = "Energy" },
                new TenderIndustry { TenderIndustryId = 2, TenderIndustryName = "Technology" },
                new TenderIndustry { TenderIndustryId = 3, TenderIndustryName = "Telecom" },
                new TenderIndustry { TenderIndustryId = 4, TenderIndustryName = "Agriculture" },
                new TenderIndustry { TenderIndustryId = 5, TenderIndustryName = "Manufacturing" }
            );

            modelBuilder.Entity<PaymentTerm>().HasData(
                new PaymentTerm { PaymentTermId = 1, PaymentSchedule = "Monthly", PaymentMethod = "Bank Transfer", PenaltiesForDelays = "1% per week" },
                new PaymentTerm { PaymentTermId = 2, PaymentSchedule = "Quarterly", PaymentMethod = "Cheque", PenaltiesForDelays = "2% per month" },
                new PaymentTerm { PaymentTermId = 3, PaymentSchedule = "Upon Completion", PaymentMethod = "Bank Transfer", PenaltiesForDelays = "3% total" },
                new PaymentTerm { PaymentTermId = 4, PaymentSchedule = "Bi-weekly", PaymentMethod = "Cash", PenaltiesForDelays = "0.5% per day" },
                new PaymentTerm { PaymentTermId = 5, PaymentSchedule = "Annually", PaymentMethod = "Online", PenaltiesForDelays = "5% annual fee" }
            );

            modelBuilder.Entity<Bid>().HasData(
    new Bid { BidId = 1, CompanyName = "ABC Corp", RegistrationNumber = "REG123", Address = "123 Street", Email = "contact@abccorp.com", Phone = "123-456-7890", TenderId = 1, BidderId = "1b1959a1-0e94-497f-bfca-69388716b042", SubmissionDate = new DateTime(2023, 1, 14) },
    new Bid { BidId = 2, CompanyName = "XYZ Ltd", RegistrationNumber = "REG124", Address = "456 Avenue", Email = "contact@xyzltd.com", Phone = "987-654-3210", TenderId = 2, BidderId = "1b1959a1-0e94-497f-bfca-69388716b042", SubmissionDate = new DateTime(2023, 1, 14) },
    new Bid { BidId = 3, CompanyName = "Tech Solutions", RegistrationNumber = "REG125", Address = "789 Road", Email = "support@techsol.com", Phone = "321-654-9870", TenderId = 3, BidderId = "1b1959a1-0e94-497f-bfca-69388716b042", SubmissionDate = new DateTime(2023, 1, 14) },
    new Bid { BidId = 4, CompanyName = "Innovate Ltd", RegistrationNumber = "REG126", Address = "1010 Lane", Email = "info@innovate.com", Phone = "654-321-0987", TenderId = 4, BidderId = "1b1959a1-0e94-497f-bfca-69388716b042", SubmissionDate = new DateTime(2023, 1, 14) },
    new Bid { BidId = 5, CompanyName = "Global Ventures", RegistrationNumber = "REG127", Address = "2020 Blvd", Email = "contact@globalventures.com", Phone = "432-567-1234", TenderId = 5, BidderId = "1b1959a1-0e94-497f-bfca-69388716b042", SubmissionDate = new DateTime(2023, 1, 14) }
);
            modelBuilder.Entity<BidDocument>().HasData(
                new BidDocument { BidDocumentId = 1, BidDocumentName = "Proposal Document 1", BidDocumentContentType = "application/pdf", BidDocumentData = null, BidDocumentUploadedDate = new DateTime(2023, 1, 14), BidId = 1 },
                new BidDocument { BidDocumentId = 2, BidDocumentName = "Proposal Document 2", BidDocumentContentType = "application/pdf", BidDocumentData = null, BidDocumentUploadedDate = new DateTime(2023, 1, 14), BidId = 2 },
                new BidDocument { BidDocumentId = 3, BidDocumentName = "Proposal Document 3", BidDocumentContentType = "application/pdf", BidDocumentData = null, BidDocumentUploadedDate = new DateTime(2023, 1, 14), BidId = 3 },
                new BidDocument { BidDocumentId = 4, BidDocumentName = "Proposal Document 4", BidDocumentContentType = "application/pdf", BidDocumentData = null, BidDocumentUploadedDate = new DateTime(2023, 1, 14), BidId = 4 },
                new BidDocument { BidDocumentId = 5, BidDocumentName = "Proposal Document 5", BidDocumentContentType = "application/pdf", BidDocumentData = null, BidDocumentUploadedDate = new DateTime(2023, 1, 14), BidId = 5 }
            );
            modelBuilder.Entity<Tender>().HasData(
                new Tender { TenderId = 1, TenderIssuedBy = "1b1959a1-0e94-497f-bfca-69388716b042", TenderTitle = "Construction of Bridge", TenderDescription = "Bridge construction project", TenderBudget = 500000, TenderIssueDate = new DateTime(2023, 1, 14), TenderClosingDate = new DateTime(2023, 1, 14), TenderStatus = TenderStatusEnum.Open, Email = "contact@tender1.com", EligibilityCriteria = "Must have 5 years of experience", CategoryId = 1, IndustryId = 1, TenderTypeId = 1, LocationId = 1 },
                new Tender { TenderId = 2, TenderIssuedBy = "1b1959a1-0e94-497f-bfca-69388716b042", TenderTitle = "Road Maintenance", TenderDescription = "Maintenance of roads", TenderBudget = 200000, TenderIssueDate = new DateTime(2023, 1, 14), TenderClosingDate = new DateTime(2023, 1, 14), TenderStatus = TenderStatusEnum.Closed, Email = "contact@tender2.com", EligibilityCriteria = "Must be registered contractor", CategoryId = 2, IndustryId = 1, TenderTypeId = 2, LocationId = 2 },
                new Tender { TenderId = 3, TenderIssuedBy = "1b1959a1-0e94-497f-bfca-69388716b042", TenderTitle = "Building Renovation", TenderDescription = "Renovation of office building", TenderBudget = 300000, TenderIssueDate = new DateTime(2023, 1, 14), TenderClosingDate = new DateTime(2023, 1, 14), TenderStatus = TenderStatusEnum.Open, Email = "contact@tender3.com", EligibilityCriteria = "Must have renovation experience", CategoryId = 3, IndustryId = 2, TenderTypeId = 3, LocationId = 3 },
                new Tender { TenderId = 4, TenderIssuedBy = "1b1959a1-0e94-497f-bfca-69388716b042", TenderTitle = "Bridge Inspection", TenderDescription = "Inspection of old bridges", TenderBudget = 100000, TenderIssueDate = new DateTime(2023, 1, 14), TenderClosingDate = new DateTime(2023, 1, 14), TenderStatus = TenderStatusEnum.Open, Email = "contact@tender4.com", EligibilityCriteria = "Certified structural engineers only", CategoryId = 4, IndustryId = 2, TenderTypeId = 1, LocationId = 4 },
                new Tender { TenderId = 5, TenderIssuedBy = "1b1959a1-0e94-497f-bfca-69388716b042", TenderTitle = "Bridge Construction", TenderDescription = "New bridge construction", TenderBudget = 1000000, TenderIssueDate = new DateTime(2023, 1, 14), TenderClosingDate = new DateTime(2023, 1, 14), TenderStatus = TenderStatusEnum.Closed, Email = "contact@tender5.com", EligibilityCriteria = "Must have large scale project experience", CategoryId = 5, IndustryId = 1, TenderTypeId = 2, LocationId = 5 }
            );
            modelBuilder.Entity<TenderDocument>().HasData(
                new TenderDocument { TenderDocumentId = 1, TenderDocumentName = "Tender Document 1", TenderDocumentContentType = "application/pdf", TenderDocumentData = null, TenderDocumentUploadedDate = new DateTime(2023, 1, 14), TenderId = 1 },
                new TenderDocument { TenderDocumentId = 2, TenderDocumentName = "Tender Document 2", TenderDocumentContentType = "application/pdf", TenderDocumentData = null, TenderDocumentUploadedDate = new DateTime(2023, 1, 14), TenderId = 2 },
                new TenderDocument { TenderDocumentId = 3, TenderDocumentName = "Tender Document 3", TenderDocumentContentType = "application/pdf", TenderDocumentData = null, TenderDocumentUploadedDate = new DateTime(2023, 1, 14), TenderId = 3 },
                new TenderDocument { TenderDocumentId = 4, TenderDocumentName = "Tender Document 4", TenderDocumentContentType = "application/pdf", TenderDocumentData = null, TenderDocumentUploadedDate = new DateTime(2023, 1, 14), TenderId = 4 },
                new TenderDocument { TenderDocumentId = 5, TenderDocumentName = "Tender Document 5", TenderDocumentContentType = "application/pdf", TenderDocumentData = null, TenderDocumentUploadedDate = new DateTime(2023, 1, 14), TenderId = 5 }
            );
            modelBuilder.Entity<TenderAward>().HasData(
                new TenderAward { TenderAwardId = 1, TenderId = 1, BidId = 1, AwardDate = new DateTime(2023, 1, 14), AwardStatus = "Awarded" },
                new TenderAward { TenderAwardId = 2, TenderId = 2, BidId = 2, AwardDate = new DateTime(2023, 1, 14), AwardStatus = "Awarded" },
                new TenderAward { TenderAwardId = 3, TenderId = 3, BidId = 3, AwardDate = new DateTime(2023, 1, 14), AwardStatus = "Awarded" },
                new TenderAward { TenderAwardId = 4, TenderId = 4, BidId = 4, AwardDate = new DateTime(2023, 1, 14), AwardStatus = "Awarded" },
                new TenderAward { TenderAwardId = 5, TenderId = 5, BidId = 5, AwardDate = new DateTime(2023, 1, 14), AwardStatus = "Awarded" }
            );

            modelBuilder.Entity<TenderEvaluation>().HasData(
       new TenderEvaluation { TenderEvaluationId = 1, TenderId = 1, ScoreTenderEvaluation = 85, TenderEvaluationNotes = "Good proposal with solid budget and timeline." },
       new TenderEvaluation { TenderEvaluationId = 2, TenderId = 2, ScoreTenderEvaluation = 78, TenderEvaluationNotes = "Proposal needs improvement on the technical side." },
       new TenderEvaluation { TenderEvaluationId = 3, TenderId = 3, ScoreTenderEvaluation = 92, TenderEvaluationNotes = "Excellent proposal, well-aligned with the project goals." },
       new TenderEvaluation { TenderEvaluationId = 4, TenderId = 4, ScoreTenderEvaluation = 80, TenderEvaluationNotes = "Average proposal, a few key areas need more detail." },
       new TenderEvaluation { TenderEvaluationId = 5, TenderId = 5, ScoreTenderEvaluation = 88, TenderEvaluationNotes = "Strong technical background, proposal is well-structured." }
   );


            modelBuilder.Entity<BidEvaluation>().HasData(
                new BidEvaluation { BidEvaluationId = 1, BidId = 1, BidEvaluationScore = 83, BidEvaluationNotes = "Competent bid with clear financial breakdown.", EvaluatedAt = new DateTime(2023, 1, 14) },
                new BidEvaluation { BidEvaluationId = 2, BidId = 2, BidEvaluationScore = 75, BidEvaluationNotes = "Missing some important documents in the bid.", EvaluatedAt = new DateTime(2023, 1, 14) },
                new BidEvaluation { BidEvaluationId = 3, BidId = 3, BidEvaluationScore = 90, BidEvaluationNotes = "Well-executed bid with excellent risk management plan.", EvaluatedAt = new DateTime(2023, 1, 14) },
                new BidEvaluation { BidEvaluationId = 4, BidId = 4, BidEvaluationScore = 80, BidEvaluationNotes = "Technical proposal needs more clarity.", EvaluatedAt = new DateTime(2023, 1, 14) },
                new BidEvaluation { BidEvaluationId = 5, BidId = 5, BidEvaluationScore = 87, BidEvaluationNotes = "Strong team experience, bid is well-presented.", EvaluatedAt = new DateTime(2023, 1, 14) }
            );

            modelBuilder.Entity<EligibilityCriteria>().HasData(
                new EligibilityCriteria { EligibilityCriteriaId = 1, Description = "Must have at least 3 years of experience in construction.", TenderId = 1 },
                new EligibilityCriteria { EligibilityCriteriaId = 2, Description = "Company must be ISO certified.", TenderId = 2 },
                new EligibilityCriteria { EligibilityCriteriaId = 3, Description = "Proposals should include a sustainability plan.", TenderId = 3 },
                new EligibilityCriteria { EligibilityCriteriaId = 4, Description = "Must provide references from past projects.", TenderId = 4 },
                new EligibilityCriteria { EligibilityCriteriaId = 5, Description = "Bidder must have a local office in the country.", TenderId = 5 }
            );
            modelBuilder.Entity<TenderEligibility>().HasData(
       new TenderEligibility { TenderEligibilityId = 1, TenderId = 1, IsRegisteredCompany = true, HasMinimumExperience = true, IsFinanciallyStable = true, HasPastExperience = true, CompliesWithIndustryStandards = true },
       new TenderEligibility { TenderEligibilityId = 2, TenderId = 2, IsRegisteredCompany = true, HasMinimumExperience = false, IsFinanciallyStable = true, HasPastExperience = false, CompliesWithIndustryStandards = true },
       new TenderEligibility { TenderEligibilityId = 3, TenderId = 3, IsRegisteredCompany = true, HasMinimumExperience = true, IsFinanciallyStable = true, HasPastExperience = true, CompliesWithIndustryStandards = false },
       new TenderEligibility { TenderEligibilityId = 4, TenderId = 4, IsRegisteredCompany = true, HasMinimumExperience = true, IsFinanciallyStable = false, HasPastExperience = true, CompliesWithIndustryStandards = true },
       new TenderEligibility { TenderEligibilityId = 5, TenderId = 5, IsRegisteredCompany = false, HasMinimumExperience = true, IsFinanciallyStable = true, HasPastExperience = true, CompliesWithIndustryStandards = true }
   );


            modelBuilder.Entity<SubmissionGuideline>().HasData(
                new SubmissionGuideline { SubmissionGuidelineId = 1, TenderId = 1, RequiredDocument = "Company Registration Certificate", TechnicalProposal = "Detailed technical proposal with methodology", FinancialProposal = "Complete cost breakdown", CompanyProfile = "Company history and portfolio" },
                new SubmissionGuideline { SubmissionGuidelineId = 2, TenderId = 2, RequiredDocument = "Proof of experience", TechnicalProposal = "Project approach and team qualifications", FinancialProposal = "Estimated budget for project", CompanyProfile = "Company team structure" },
                new SubmissionGuideline { SubmissionGuidelineId = 3, TenderId = 3, RequiredDocument = "Certifications", TechnicalProposal = "Risk mitigation strategy", FinancialProposal = "Financial stability report", CompanyProfile = "Mission and vision statement" },
                new SubmissionGuideline { SubmissionGuidelineId = 4, TenderId = 4, RequiredDocument = "Past project references", TechnicalProposal = "Solution design", FinancialProposal = "Cost analysis", CompanyProfile = "Company management details" },
                new SubmissionGuideline { SubmissionGuidelineId = 5, TenderId = 5, RequiredDocument = "Tax registration", TechnicalProposal = "Project timeline", FinancialProposal = "Cost breakdown for phases", CompanyProfile = "Client portfolio" }
            );


            modelBuilder.Entity<FinancialProposalItem>().HasData(
                new FinancialProposalItem { FinancialProposalItemId = 1, ItemDescription = "Construction material", Quantity = 100, UnitPrice = 50, BidId = 1 },
                new FinancialProposalItem { FinancialProposalItemId = 2, ItemDescription = "Labor costs", Quantity = 200, UnitPrice = 30, BidId = 1 },
                new FinancialProposalItem { FinancialProposalItemId = 3, ItemDescription = "Equipment rental", Quantity = 5, UnitPrice = 1500, BidId = 2 },
                new FinancialProposalItem { FinancialProposalItemId = 4, ItemDescription = "Consulting services", Quantity = 10, UnitPrice = 250, BidId = 2 },
                new FinancialProposalItem { FinancialProposalItemId = 5, ItemDescription = "Training sessions", Quantity = 8, UnitPrice = 500, BidId = 3 }
            );


            modelBuilder.Entity<SupportingDocument>().HasData(
                new SupportingDocument { SupportingDocumentId = 1, BidId = 1, DocumentName = "Tax Registration", Description = "Document certifying the company's tax registration" },
                new SupportingDocument { SupportingDocumentId = 2, BidId = 1, DocumentName = "ISO Certification", Description = "International quality management certification" },
                new SupportingDocument { SupportingDocumentId = 3, BidId = 2, DocumentName = "Company Profile", Description = "Detailed profile of the bidding company" },
                new SupportingDocument { SupportingDocumentId = 4, BidId = 3, DocumentName = "Financial Stability Report", Description = "Audit report confirming financial stability" },
                new SupportingDocument { SupportingDocumentId = 5, BidId = 4, DocumentName = "References", Description = "Client references from past projects" }
            );

            modelBuilder.Entity<Tender>()
         .Property(t => t.TenderStatus)
         .HasConversion<string>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().
                    SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }



            base.OnModelCreating(modelBuilder);
        }

    }
}
