using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDotNetApi.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;
namespace MyDotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IChatClient _ollamaService;

        public UploadController(IChatClient ollamaService)
        {
            _ollamaService = ollamaService;
        }
public static byte[] ReadFully(Stream input)
{
    byte[] buffer = new byte[16*1024];
    using (MemoryStream ms = new MemoryStream())
    {
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
        }
        return ms.ToArray();
    }
}
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile image, [FromForm] string question){
            if (image == null || string.IsNullOrEmpty(question))
            {
                return BadRequest("Image and question are required.");
            }

            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);
                stream.Position = 0;
            
                    var message = new ChatMessage(ChatRole.User,question);
                    message.Contents.Add(new DataContent(ReadFully(stream),"image/png"));
                    
                    var response = await _ollamaService.GetResponseAsync(message);
                    return Ok(response);
                
            }
        }
    }
}