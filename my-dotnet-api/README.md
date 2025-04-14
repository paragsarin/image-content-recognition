# My .NET API Project

This project is a .NET API that connects to a locally running Ollama model using Microsoft.Extensions.AI. It provides an endpoint for uploading images along with a question to be processed by the Ollama model.

## Project Structure

```
my-dotnet-api
├── Controllers
│   └── UploadController.cs
├── Models
│   └── UploadRequest.cs
├── Services
│   └── OllamaService.cs
├── appsettings.json
├── Program.cs
├── Startup.cs
└── README.md
```

## Setup Instructions

1. **Clone the repository**:
   ```
   git clone <repository-url>
   cd my-dotnet-api
   ```

2. **Install dependencies**:
   Ensure you have the necessary .NET SDK installed. Run the following command to restore the dependencies:
   ```
   dotnet restore
   ```

3. **Configuration**:
   Update the `appsettings.json` file with the necessary configuration settings for connecting to the Ollama model.

4. **Run the application**:
   Use the following command to run the application:
   ```
   dotnet run
   ```

5. **Access the API**:
   The API will be available at `http://localhost:<port>/api/upload`. You can use tools like Postman or curl to test the endpoint.

## Usage Example

To upload an image and a question, send a POST request to `/api/upload` with the following form data:

- **image**: The image file to be processed.
- **question**: The question related to the image.

Example using curl:
```
curl -X POST http://localhost:<port>/api/upload -F "image=@path/to/image.jpg" -F "question=What is in this image?"
```

## License

This project is licensed under the MIT License. See the LICENSE file for more details.