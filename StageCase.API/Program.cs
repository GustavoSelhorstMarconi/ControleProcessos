using StageCase.Application.Helpers;
using StageCase.Infra.Data;
using StageCase.Infra.IoC.InversionControl;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAutoMapper(typeof(StageCaseProfiler));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        options.IncludeXmlComments(xmlPath);
    });

builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

app.MapControllers();

app.Run();
