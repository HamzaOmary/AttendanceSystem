using AttendanceSystem.Domain;
using AttendanceSystem.Domain.Interfaces.Repository;
using AttendanceSystem.Domain.Interfaces.Service;
using AttendanceSystem.Domain.Services;
using AttendanceSystem.Infra.Repository;
using AttendanceSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
//using AttendanceSystem.Domain.AppDbContex;



var builder = WebApplication.CreateBuilder(args);

//////////////////////add CORS policy //////////////////////////////////

var allowedOrigins = builder.Configuration.GetValue<string>("allowOrigin")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy => 
        policy.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader());

});

////////////////////////////////////////////////////////////////

builder.Services.AddAuthorization();/////////////////////////*******

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Attendance System API", Version = "v1" });

    // Add the custom file upload operation filter
    c.OperationFilter<AttendanceSystem.API.Swagger.FileUploadOperationFilter>();
});/////////////////////////////





////////////////////////////////////////////////////////////////////////

// Register DbContext with SQL Server connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository interfaces with their implementations
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IRollRepository, RollRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ICollegeRepository, CollegeRepository>();
builder.Services.AddScoped<IDashboardStatisticsRepository, DashboardStatisticsRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// Register service interfaces with their implementations
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IClassRoomService, ClassRoomService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IRollService, RollService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICollegeService, CollegeService>();
builder.Services.AddScoped<IDashboardStatisticsService, DashboardStatisticsService>();
builder.Services.AddScoped<IReportService, ReportService>();

 

////////////////////////////////////////////////////////////////////////

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



////////////////////////////////////////////////////////////////////////



var app = builder.Build();

////////////////////////////////////////////////////////////

// Apply any pending migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Apply pending migrations
}



////////////////////////////////////////////////////////////
///


////////////////////////////////////////////////////////////

// Serve static files from the configured folder
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(builder.Configuration["ImageSettings:ImageFolderPath"]),
//    RequestPath = "/UserImages"
//});


////////////////////////////////////////////////////////////



////////////////////////////////////////////////////////////
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Use the CORS Policy
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//app.UseRouting();

app.MapControllers();

app.Run();



