using Ddtatest.Configuration;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

// Add services to the container.
builder.AddAppLogger();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationCors();
builder.Services.AddAppVersioning();
builder.Services.AddAppSwagger(mainSettings, swaggerSettings);
builder.Services.AddAppControllerAndViews();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseAppSwagger();
app.UseAppControllerAndViews();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();
