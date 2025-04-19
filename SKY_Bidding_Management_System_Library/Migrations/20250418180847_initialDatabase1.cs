using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SKY_Bidding_Management_System_Library.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-admin-id");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-user-id");

            migrationBuilder.AlterColumn<string>(
                name: "TenderStatus",
                table: "Tenders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "EligibilityCriterias",
                columns: new[] { "EligibilityCriteriaId", "Description", "TenderId" },
                values: new object[,]
                {
                    { 1, "Must have at least 3 years of experience in construction.", 1 },
                    { 2, "Company must be ISO certified.", 2 },
                    { 3, "Proposals should include a sustainability plan.", 3 },
                    { 4, "Must provide references from past projects.", 4 },
                    { 5, "Bidder must have a local office in the country.", 5 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTerms",
                columns: new[] { "PaymentTermId", "PaymentMethod", "PaymentSchedule", "PenaltiesForDelays" },
                values: new object[,]
                {
                    { 1, "Bank Transfer", "Monthly", "1% per week" },
                    { 2, "Cheque", "Quarterly", "2% per month" },
                    { 3, "Bank Transfer", "Upon Completion", "3% total" },
                    { 4, "Cash", "Bi-weekly", "0.5% per day" },
                    { 5, "Online", "Annually", "5% annual fee" }
                });

            migrationBuilder.InsertData(
                table: "TenderCategories",
                columns: new[] { "TenderCategoryId", "TenderCategoryName" },
                values: new object[,]
                {
                    { 1, "Construction" },
                    { 2, "IT Services" },
                    { 3, "Consulting" },
                    { 4, "Healthcare" },
                    { 5, "Transport" }
                });

            migrationBuilder.InsertData(
                table: "TenderIndustries",
                columns: new[] { "TenderIndustryId", "TenderIndustryName" },
                values: new object[,]
                {
                    { 1, "Energy" },
                    { 2, "Technology" },
                    { 3, "Telecom" },
                    { 4, "Agriculture" },
                    { 5, "Manufacturing" }
                });

            migrationBuilder.InsertData(
                table: "TenderLocations",
                columns: new[] { "TenderLocationId", "TenderLocationName" },
                values: new object[,]
                {
                    { 1, "Amman" },
                    { 2, "Irbid" },
                    { 3, "Aqaba" },
                    { 4, "Zarqa" },
                    { 5, "Madaba" }
                });

            migrationBuilder.InsertData(
                table: "TenderTypes",
                columns: new[] { "TenderTypeId", "TenderTypeName" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Selective" },
                    { 3, "Negotiated" },
                    { 4, "Framework Agreement" },
                    { 5, "Dynamic Purchasing" }
                });

            migrationBuilder.InsertData(
                table: "Tenders",
                columns: new[] { "TenderId", "CategoryId", "EligibilityCriteria", "Email", "IndustryId", "LocationId", "TenderBudget", "TenderClosingDate", "TenderDescription", "TenderIssueDate", "TenderIssuedBy", "TenderStatus", "TenderTitle", "TenderTypeId" },
                values: new object[,]
                {
                    { 1, 1, "Must have 5 years of experience", "contact@tender1.com", 1, 1, 500000m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bridge construction project", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1b1959a1-0e94-497f-bfca-69388716b042", "Open", "Construction of Bridge", 1 },
                    { 2, 2, "Must be registered contractor", "contact@tender2.com", 1, 2, 200000m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maintenance of roads", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1b1959a1-0e94-497f-bfca-69388716b042", "Closed", "Road Maintenance", 2 },
                    { 3, 3, "Must have renovation experience", "contact@tender3.com", 2, 3, 300000m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Renovation of office building", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1b1959a1-0e94-497f-bfca-69388716b042", "Open", "Building Renovation", 3 },
                    { 4, 4, "Certified structural engineers only", "contact@tender4.com", 2, 4, 100000m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inspection of old bridges", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1b1959a1-0e94-497f-bfca-69388716b042", "Open", "Bridge Inspection", 1 },
                    { 5, 5, "Must have large scale project experience", "contact@tender5.com", 1, 5, 1000000m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "New bridge construction", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1b1959a1-0e94-497f-bfca-69388716b042", "Closed", "Bridge Construction", 2 }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "BidId", "Address", "BidderId", "CompanyName", "Email", "Phone", "RegistrationNumber", "SubmissionDate", "TechnicalSummary", "TenderId" },
                values: new object[,]
                {
                    { 1, "123 Street", "1b1959a1-0e94-497f-bfca-69388716b042", "ABC Corp", "contact@abccorp.com", "123-456-7890", "REG123", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, "456 Avenue", "1b1959a1-0e94-497f-bfca-69388716b042", "XYZ Ltd", "contact@xyzltd.com", "987-654-3210", "REG124", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, "789 Road", "1b1959a1-0e94-497f-bfca-69388716b042", "Tech Solutions", "support@techsol.com", "321-654-9870", "REG125", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 4, "1010 Lane", "1b1959a1-0e94-497f-bfca-69388716b042", "Innovate Ltd", "info@innovate.com", "654-321-0987", "REG126", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 },
                    { 5, "2020 Blvd", "1b1959a1-0e94-497f-bfca-69388716b042", "Global Ventures", "contact@globalventures.com", "432-567-1234", "REG127", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 }
                });

            migrationBuilder.InsertData(
                table: "SubmissionGuidelines",
                columns: new[] { "SubmissionGuidelineId", "CompanyProfile", "FinancialProposal", "RequiredDocument", "TechnicalProposal", "TenderId" },
                values: new object[,]
                {
                    { 1, "Company history and portfolio", "Complete cost breakdown", "Company Registration Certificate", "Detailed technical proposal with methodology", 1 },
                    { 2, "Company team structure", "Estimated budget for project", "Proof of experience", "Project approach and team qualifications", 2 },
                    { 3, "Mission and vision statement", "Financial stability report", "Certifications", "Risk mitigation strategy", 3 },
                    { 4, "Company management details", "Cost analysis", "Past project references", "Solution design", 4 },
                    { 5, "Client portfolio", "Cost breakdown for phases", "Tax registration", "Project timeline", 5 }
                });

            migrationBuilder.InsertData(
                table: "TenderDocuments",
                columns: new[] { "TenderDocumentId", "DocumentContent", "TenderDocumentContentType", "TenderDocumentData", "TenderDocumentName", "TenderDocumentUploadedDate", "TenderId" },
                values: new object[,]
                {
                    { 1, null, "application/pdf", null, "Tender Document 1", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, null, "application/pdf", null, "Tender Document 2", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, null, "application/pdf", null, "Tender Document 3", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, null, "application/pdf", null, "Tender Document 4", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, null, "application/pdf", null, "Tender Document 5", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "TenderEligibilities",
                columns: new[] { "TenderEligibilityId", "CompliesWithIndustryStandards", "HasMinimumExperience", "HasPastExperience", "IsFinanciallyStable", "IsRegisteredCompany", "TenderId" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, 1 },
                    { 2, true, false, false, true, true, 2 },
                    { 3, false, true, true, true, true, 3 },
                    { 4, true, true, true, false, true, 4 },
                    { 5, true, true, true, true, false, 5 }
                });

            migrationBuilder.InsertData(
                table: "TenderEvaluations",
                columns: new[] { "TenderEvaluationId", "ScoreTenderEvaluation", "TenderEvaluationNotes", "TenderId" },
                values: new object[,]
                {
                    { 1, 85m, "Good proposal with solid budget and timeline.", 1 },
                    { 2, 78m, "Proposal needs improvement on the technical side.", 2 },
                    { 3, 92m, "Excellent proposal, well-aligned with the project goals.", 3 },
                    { 4, 80m, "Average proposal, a few key areas need more detail.", 4 },
                    { 5, 88m, "Strong technical background, proposal is well-structured.", 5 }
                });

            migrationBuilder.InsertData(
                table: "BidDocuments",
                columns: new[] { "BidDocumentId", "BidDocumentContentType", "BidDocumentData", "BidDocumentName", "BidDocumentUploadedDate", "BidId" },
                values: new object[,]
                {
                    { 1, "application/pdf", null, "Proposal Document 1", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "application/pdf", null, "Proposal Document 2", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "application/pdf", null, "Proposal Document 3", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "application/pdf", null, "Proposal Document 4", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "application/pdf", null, "Proposal Document 5", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "BidEvaluations",
                columns: new[] { "BidEvaluationId", "BidEvaluationNotes", "BidEvaluationScore", "BidId", "EvaluatedAt" },
                values: new object[,]
                {
                    { 1, "Competent bid with clear financial breakdown.", 83m, 1, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Missing some important documents in the bid.", 75m, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Well-executed bid with excellent risk management plan.", 90m, 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Technical proposal needs more clarity.", 80m, 4, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Strong team experience, bid is well-presented.", 87m, 5, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FinancialProposalItems",
                columns: new[] { "FinancialProposalItemId", "BidId", "ItemDescription", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "Construction material", 100, 50m },
                    { 2, 1, "Labor costs", 200, 30m },
                    { 3, 2, "Equipment rental", 5, 1500m },
                    { 4, 2, "Consulting services", 10, 250m },
                    { 5, 3, "Training sessions", 8, 500m }
                });

            migrationBuilder.InsertData(
                table: "SupportingDocuments",
                columns: new[] { "SupportingDocumentId", "BidId", "Description", "DocumentName" },
                values: new object[,]
                {
                    { 1, 1, "Document certifying the company's tax registration", "Tax Registration" },
                    { 2, 1, "International quality management certification", "ISO Certification" },
                    { 3, 2, "Detailed profile of the bidding company", "Company Profile" },
                    { 4, 3, "Audit report confirming financial stability", "Financial Stability Report" },
                    { 5, 4, "Client references from past projects", "References" }
                });

            migrationBuilder.InsertData(
                table: "TenderAwards",
                columns: new[] { "TenderAwardId", "AwardDate", "AwardStatus", "BidId", "TenderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awarded", 1, 1 },
                    { 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awarded", 2, 2 },
                    { 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awarded", 3, 3 },
                    { 4, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awarded", 4, 4 },
                    { 5, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awarded", 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDocuments",
                keyColumn: "BidDocumentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BidDocuments",
                keyColumn: "BidDocumentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BidDocuments",
                keyColumn: "BidDocumentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BidDocuments",
                keyColumn: "BidDocumentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BidDocuments",
                keyColumn: "BidDocumentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BidEvaluations",
                keyColumn: "BidEvaluationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BidEvaluations",
                keyColumn: "BidEvaluationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BidEvaluations",
                keyColumn: "BidEvaluationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BidEvaluations",
                keyColumn: "BidEvaluationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BidEvaluations",
                keyColumn: "BidEvaluationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EligibilityCriterias",
                keyColumn: "EligibilityCriteriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EligibilityCriterias",
                keyColumn: "EligibilityCriteriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EligibilityCriterias",
                keyColumn: "EligibilityCriteriaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EligibilityCriterias",
                keyColumn: "EligibilityCriteriaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EligibilityCriterias",
                keyColumn: "EligibilityCriteriaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FinancialProposalItems",
                keyColumn: "FinancialProposalItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FinancialProposalItems",
                keyColumn: "FinancialProposalItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FinancialProposalItems",
                keyColumn: "FinancialProposalItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FinancialProposalItems",
                keyColumn: "FinancialProposalItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FinancialProposalItems",
                keyColumn: "FinancialProposalItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentTerms",
                keyColumn: "PaymentTermId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubmissionGuidelines",
                keyColumn: "SubmissionGuidelineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubmissionGuidelines",
                keyColumn: "SubmissionGuidelineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubmissionGuidelines",
                keyColumn: "SubmissionGuidelineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubmissionGuidelines",
                keyColumn: "SubmissionGuidelineId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubmissionGuidelines",
                keyColumn: "SubmissionGuidelineId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SupportingDocuments",
                keyColumn: "SupportingDocumentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SupportingDocuments",
                keyColumn: "SupportingDocumentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SupportingDocuments",
                keyColumn: "SupportingDocumentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SupportingDocuments",
                keyColumn: "SupportingDocumentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SupportingDocuments",
                keyColumn: "SupportingDocumentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderAwards",
                keyColumn: "TenderAwardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderAwards",
                keyColumn: "TenderAwardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderAwards",
                keyColumn: "TenderAwardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderAwards",
                keyColumn: "TenderAwardId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderAwards",
                keyColumn: "TenderAwardId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderDocuments",
                keyColumn: "TenderDocumentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderDocuments",
                keyColumn: "TenderDocumentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderDocuments",
                keyColumn: "TenderDocumentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderDocuments",
                keyColumn: "TenderDocumentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderDocuments",
                keyColumn: "TenderDocumentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderEligibilities",
                keyColumn: "TenderEligibilityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderEligibilities",
                keyColumn: "TenderEligibilityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderEligibilities",
                keyColumn: "TenderEligibilityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderEligibilities",
                keyColumn: "TenderEligibilityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderEligibilities",
                keyColumn: "TenderEligibilityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderEvaluations",
                keyColumn: "TenderEvaluationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderEvaluations",
                keyColumn: "TenderEvaluationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderEvaluations",
                keyColumn: "TenderEvaluationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderEvaluations",
                keyColumn: "TenderEvaluationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderEvaluations",
                keyColumn: "TenderEvaluationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderIndustries",
                keyColumn: "TenderIndustryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderIndustries",
                keyColumn: "TenderIndustryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderIndustries",
                keyColumn: "TenderIndustryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderTypes",
                keyColumn: "TenderTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderTypes",
                keyColumn: "TenderTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "BidId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tenders",
                keyColumn: "TenderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tenders",
                keyColumn: "TenderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tenders",
                keyColumn: "TenderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tenders",
                keyColumn: "TenderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tenders",
                keyColumn: "TenderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderCategories",
                keyColumn: "TenderCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderCategories",
                keyColumn: "TenderCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderCategories",
                keyColumn: "TenderCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderCategories",
                keyColumn: "TenderCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderCategories",
                keyColumn: "TenderCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderIndustries",
                keyColumn: "TenderIndustryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderIndustries",
                keyColumn: "TenderIndustryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderLocations",
                keyColumn: "TenderLocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderLocations",
                keyColumn: "TenderLocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderLocations",
                keyColumn: "TenderLocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderLocations",
                keyColumn: "TenderLocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderLocations",
                keyColumn: "TenderLocationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenderTypes",
                keyColumn: "TenderTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenderTypes",
                keyColumn: "TenderTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenderTypes",
                keyColumn: "TenderTypeId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "TenderStatus",
                table: "Tenders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "role-admin-id", "static-security-stamp-001", "Admin", "ADMIN" },
                    { "role-user-id", "static-security-stamp-001", "User", "USER" }
                });
        }
    }
}
