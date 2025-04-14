using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.AI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using MyDotNetApi.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"),"llava:7b")) ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery();
// Configure CORS to allow everything
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll"); // Use the CORS policy
app.UseAntiforgery();
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
 app.MapPost("/upload", async ( IChatClient  _ollamaService, [FromForm] IFormFile image, [FromForm] string question) =>
{
     if (image == null || string.IsNullOrEmpty(question))
            {
               
            }

            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                stream.Position = 0;
             
                    var message = new ChatMessage(ChatRole.User,question);
                    message.Contents.Add(new DataContent(UploadController.ReadFully(stream),"image/png"));
                    
                    var response = await _ollamaService.GetResponseAsync(message);
                    return Results.Ok(response);
                
            }
}).DisableAntiforgery();

app.MapPost("/upload/base64", async (IChatClient _ollamaService, [FromBody] Base64ImageRequest request) =>
{
    if (string.IsNullOrEmpty(request.Base64Image))
    {
        return Results.BadRequest("Base64 image data is required.");
    }

    byte[] imageBytes = Convert.FromBase64String(request.Base64Image);
    using (var stream = new MemoryStream(imageBytes))
    {
        var message = new ChatMessage(ChatRole.User, "Describe the image");
        message.Contents.Add(new DataContent(UploadController.ReadFully(stream), "image/png"));
        var response = await _ollamaService.GetResponseAsync(message);
        
        return Results.Ok(response);
    }
}).DisableAntiforgery();


app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
public class Base64ImageRequest
{
    public string ?Base64Image { get; set; }
}