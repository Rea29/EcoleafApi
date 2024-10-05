using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore;
using HotChocolate.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft;
using Common.Token;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using EcoleafAPI;
using EcoleafAPI.GraphQL.MutationsTypes;
using EcoleafAPI.GraphQL.QueryTypes;
using HotChocolate.Types.Pagination;
using Datalayer;
using EcoleafAPI.Services.Queries.Users;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var jwtKey = configuration.GetValue<string>("JwtRequirements:Key");

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var AllowedOrigins = "AllowedOrigins";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(9999); // HTTP port
    options.ListenAnyIP(9991, listenOptions => listenOptions.UseHttps()); // HTTPS port
    options.ListenAnyIP(5227); // HTTP port
    options.ListenAnyIP(7066, listenOptions => listenOptions.UseHttps()); // HTTPS port
});

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowedOrigins,
        builder =>
        {
            builder.AllowAnyOrigin() //WithOrigins(GlobalSettings.CORSAllowedOrigin)
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});





//builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
//{
//    sqlOptions.CommandTimeout(180);  // Adjust command timeout if needed
//}));

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: AllowedOrigins,
//        builder =>
//        {
//            builder.AllowAnyOrigin() //WithOrigins(GlobalSettings.CORSAllowedOrigin)
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//        });
//});









//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        policy =>
//        {
//            // Allow requests from the React app's LAN IP
//           policy.WithOrigins("http://192.168.1.5:5000", "http://192.168.8.101:5000") // Replace with your React app's IP and port 
//                 .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});
//builder.Services.AddGetUsersQueryAsyncApplication();

builder.Services.AddAuthorization();
builder.Services.GetUsersQueryAsyncApplication();
builder.Services.GetProjectAndMaterialRequisitionSlipsQueryAsyncApplication();
builder.Services.GetModulesQueryAsyncApplication();
builder.Services.UserModuleMutationAsyncApplication();
builder.Services.EmployeesMutationMutationAsyncApplication();
builder.Services.AddScoped<IRepositoryService, RepositoryService>();
builder.Services.AddScoped<IJwtAuthentication, JwtAuthentication>();

//query
builder.Services.AddScoped<GetUsersQueryService>();
builder.Services.AddScoped<GetModulesQueryAsync>();
builder.Services.AddScoped<GetProjectAndMaterialRequisitionSlipsQueryService>();
//mutation
builder.Services.AddScoped<UserModuleMutationService>();
builder.Services.AddScoped<EmployeesMutationService>();


//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersQueryAsync).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);  // Adjust the timeout
//    serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
//});

builder.Services
    .AddGraphQLServer()
     .AddQueryType(q => q.Name("Query"))
    .AddType<HumanResourceManagementQuery>()
    .AddType<MaterialRequisitionSlipQuery>()
    .AddType<MaterialsInventoryQuery>()
    .AddType<PowerToolsInventoryQuery>()
    .AddType<ProjectMonitoringManagementQuery>()
    .AddType<AccountingManagementQuery>()
    .AddType<ProjectSummaryExpenseQuery>()
    .AddType<ProtectivePersonalEquipmentInventoryQuery>()
    .AddType<PurchaseOrderQuery>()
    .AddType<ProgressReportQuery>()
    .AddType<WareHouseInventoryQuery>()
    .AddType<UsersQuery>()

    .AddMutationType(q => q.Name("Mutation"))
    .AddType<HumanResourceManagementMutation>()
    .AddType<MaterialRequisitionSlipMutation>()
    .AddType<PowerToolsInventoryMutation>()
    .AddType<PersonalProtectiveEquipmentInventoryMutation>()
    .AddType<AccountingManagementSystemMutation>()
    .AddType<MaterialsInventoryMutation>()
    .AddType<ProjectMonitoringManagementMutation>()
    .AddType<ProjectSummaryExpenseMutation>()
    .AddType<PurchaseOrderMutation>()
    .AddType<ProgressReportMutation>()
    .AddType<UsersMutation>()
    .AddType<LocationQuery>()
    .AddType<ModulesQuery>()


    .AddUploadType()
    .AddProjections()
    
    .AddFiltering()
    .AddSorting()
     .SetPagingOptions(new PagingOptions
     {
         MaxPageSize = int.MaxValue - 1,
         DefaultPageSize = int.MaxValue - 1,
         IncludeTotalCount = true
     })

     .AddAuthorization();

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
//app.UseCors("AllowSpecificOrigin"); // Apply CORS policy
app.UseCors(AllowedOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();
app.MapControllers();


app.Run();
