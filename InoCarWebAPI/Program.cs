using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data;
using InoCar.Data.Entities;
using InoCar.Repositories;
using InoCar.Repositories.Impl;
using InoCar.Repositories.Interfaces;
using InoCar.Services;
using InoCar.Services.Impl;
using InoCar.Services.Interfaces;
using InoCar.Servises.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<InoCarContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API WSVAP (WebSmartView)", Version = "v1" });
    // c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InoCar API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Support",
            Email = "support@inocar.local"
        },
        Description = "InoCar API gives access to car data. It was made to make integrations easier and reliable."
    });
    option.IncludeXmlComments(System.IO.Path.Combine(System.AppContext.BaseDirectory, "InoCarWebAPI.xml"));
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                                }
                            },
                            new string[]{}
                }
                });
});
builder.Services.AddScoped<ICarRepository, CarRepositoryImpl>();
builder.Services.AddScoped<ICarService, CarServiceImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<ICarCertificateRepository, CarCertificateRepositoryImpl>();
builder.Services.AddScoped<ICarCertificateService, CarCertificateServiceImpl>();
builder.Services.AddScoped<IUserCodeService, UserCodeServiceImpl>();
builder.Services.AddScoped<IDealershipRepository, DealershipRepositoryImpl>();
builder.Services.AddScoped<IDealershipService, DealershipServiceImpl>();
builder.Services.AddScoped<IServiceConsultantRepository, ServiceConsultantRepositoryImpl>();
builder.Services.AddScoped<IServiceConsultantService, ServiceConsultantServiceImpl>();
builder.Services.AddScoped<IServiceRequestRepository, ServiceRequestRepositoryImpl>();
builder.Services.AddScoped<IServiceRequest, ServiceRequestServiceImpl>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepositoryImpl>();
builder.Services.AddScoped<IVisitReasonService, VisitReasonServiceImpl>();
builder.Services.AddScoped<IVisitReasonRepository, VisitReasonRepositoryImpl>();
builder.Services.AddScoped<IRemoveCarReasonService, RemoveCarReasonServiceImpl>();
builder.Services.AddScoped<IRemoveCarReasonRepository, RemoveCarReasonRepositoryImpl>();
builder.Services.AddScoped<IRecommendationService, RecommendationServiceImpl>();
builder.Services.AddScoped<IRecommendationRepository, RecommendationRepositoryImpl>();
builder.Services.AddScoped<IPersonalOfferService, PersonalOfferServiceImpl>();
builder.Services.AddScoped<IPersonalOfferRepository, PersonalOfferRepositoryImpl>();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
builder.Services.AddScoped<ITimeSlotService, TimeSlotServiceImpl>();
builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepositoryImpl>();
builder.Services.AddScoped<IMaintenanceWorkService, MaintenanceWorkServiceImpl>();
builder.Services.AddScoped<IMaintenanceWorkRepository, MaintenanceWorkRepositoryImpl>();

builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<InoCarContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(x =>
{


    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();
