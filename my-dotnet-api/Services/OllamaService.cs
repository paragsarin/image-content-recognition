using Microsoft.Extensions.AI;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace MyDotNetApi.Services
{
    public class OllamaService
    {
        private readonly IChatClient _ollamaClient;

        public OllamaService(IChatClient ollamaClient)
        {
            _ollamaClient = ollamaClient;
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
       
    }
}