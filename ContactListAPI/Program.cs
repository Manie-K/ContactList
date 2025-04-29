using System.Text;
using ContactListAPI.Data;
using ContactListAPI.DataMapping;
using ContactListAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container. 
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


// Configure dbContext
builder.Services.AddDbContext<ContactListDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultLocalConnection"));
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(ContactMapperProfile));

// Configure JWT authentication
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendOnly",policy => {
            //TODO: Allow only frontend app
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //TODO: Add xml to swagger docs
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontendOnly");
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
