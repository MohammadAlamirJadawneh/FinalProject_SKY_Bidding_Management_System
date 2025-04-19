using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SKY_Bidding_Management_System.Extentions;
using SKY_Bidding_Management_System_Library;
using SKY_Bidding_Management_System_Library.Data;
using SKY_Bidding_Management_System_Library.Data.DataInitializer;
using SKY_Bidding_Management_System_Library.Data.Models;
using SKY_Bidding_Management_System_Library.Service.AccountService;
using SKY_Bidding_Management_System_Library.Service.BidDocumentService;
using SKY_Bidding_Management_System_Library.Service.BidEvaluationService;
using SKY_Bidding_Management_System_Library.Service.BidService;
using SKY_Bidding_Management_System_Library.Service.PaymentTermService;
using SKY_Bidding_Management_System_Library.Service.SubmissionGuidelineService;
using SKY_Bidding_Management_System_Library.Service.TenderAwardService;
using SKY_Bidding_Management_System_Library.Service.TenderCategoryService;
using SKY_Bidding_Management_System_Library.Service.TenderEvaluationService;
using SKY_Bidding_Management_System_Library.Service.TenderIndustryService;
using SKY_Bidding_Management_System_Library.Service.TenderLocationService;
using SKY_Bidding_Management_System_Library.Service.TenderService;
using SKY_Bidding_Management_System_Library.Service.TenderTypeService;
using SKY_Tenderding_Management_System_Library.Service.TenderDocumentService;



namespace SKY_Bidding_Management_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(op =>
                            op.UseLazyLoadingProxies()
                            .UseSqlServer(builder.Configuration.GetConnectionString("DbSQLConnectionString")));


            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGenJwtAuth();





            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MyLib).Assembly));
            builder.Services.AddMediatR(cfg =>
   cfg.RegisterServicesFromAssembly(typeof(MyLib).Assembly));
            //builder.Services.AddMediatR(typeof(MyLib).Assembly);

            //builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();



            //email confim  
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false; // You can change this based on your needs
            })
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));


            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ITenderLocationService, TenderLocationService>();
            builder.Services.AddScoped<ITenderTypeService, TenderTypeService>();
            builder.Services.AddScoped<ITenderIndustryService, TenderIndustryService>();

            builder.Services.AddScoped<ITenderEvaluationService, TenderEvaluationService>();
            builder.Services.AddScoped<ITenderCategoryService, TenderCategoryService>();
            builder.Services.AddScoped<IBidEvaluationService, BidEvaluationService>();
            builder.Services.AddScoped<ITenderAwardService, TenderAwardService>();
            builder.Services.AddScoped<ITenderDocumentService, TenderDocumentService>();
            builder.Services.AddScoped<IBidDocumentService, BidDocumentService>();
            builder.Services.AddScoped<IBidService, BidService>();
            builder.Services.AddScoped<ITenderService, TenderService>();
            builder.Services.AddScoped<ISubmissionGuidelineService, SubmissionGuidelineService>();
            builder.Services.AddScoped<IPaymentTermService, PaymentTermService>();






            builder.Services.AddCustomJwtAuth(builder.Configuration);




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();


            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await IdentityDataInitializer.SeedRolesAsync(roleManager);
            }

            app.Run();
        }


    }
}
