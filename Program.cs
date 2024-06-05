using CityInfoApi.DBContext;
using CityInfoApi.Repositories;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; //support xml returns
}).AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

builder.Services.AddDbContext<CityInfoDBContext>(option =>
{
    option.UseSqlite(builder.Configuration["ConnectionStrings:CityConnectionString"]);
});
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
var app = builder.Build();
#region Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting(); // enable routing in the app
app.UseAuthorization();
// controller/action/parametr

app.UseEndpoints(endpoints => {
    endpoints?.MapControllers();

});

#endregion

app.Run();
