# My Next.js Image Upload Application

This project is a Next.js application that allows users to upload an image and ask a question regarding that image. The uploaded image is processed and sent to a .NET API for further handling.

## Project Structure

```
my-nextjs-app
├── pages
│   ├── api
│   │   └── upload.ts        # API route for uploading images
│   ├── index.tsx            # Main entry point of the application
│   └── upload.tsx           # Upload page for image and question
├── public
│   └── images               # Directory for storing uploaded images
├── styles
│   └── globals.css          # Global CSS styles
├── components
│   └── UploadForm.tsx       # Component for the upload form
├── next.config.js           # Configuration settings for Next.js
├── package.json              # npm configuration file
├── tsconfig.json            # TypeScript configuration file
└── README.md                # Documentation for the project
```

## Features

- **Image Upload**: Users can upload an image file.
- **Question Input**: Users can ask a question related to the uploaded image.
- **API Integration**: The application communicates with a .NET API to process the uploaded image and question.

## Getting Started

1. Clone the repository:
   ```
   git clone <repository-url>
   cd my-nextjs-app
   ```

2. Install dependencies:
   ```
   npm install
   ```

3. Run the development server:
   ```
   npm run dev
   ```

4. Open your browser and navigate to `http://localhost:3000` to view the application.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or features.

## License

This project is licensed under the MIT License.