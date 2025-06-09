# AI Image Classifier

> 🎓 **Academic Project** — developed as part of Programming intelligent systems at University of Economics in Carcow.

This is a web application for classifying images and finding similar images using the power of machine learning models. The application allows users to upload an image, classify it using a pre-trained model, and display similar images fetched from Google Custom Search API.

## Features

- **Image Classification**: The application uses the Hugging Face API to classify images.
- **Similar Images Search**: Once the image is classified, it searches for similar images using Google Custom Search API.
- **Responsive UI**: The interface is modern and responsive, providing a smooth user experience on both desktop and mobile devices.

## Technologies Used

- **ASP.NET Core**: The application is built using ASP.NET Core MVC for the backend.
- **Hugging Face API**: Used for image classification with the `ResNet-50` model.
- **Google Custom Search API**: Used to search for similar images based on the classified image label.
- **Bootstrap**: Used for styling the frontend with a modern, responsive design.

## Setup Instructions

### Prerequisites

Ensure you have the following installed:

- [.NET 8+ SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)
- A **Hugging Face** API Token (for the classification service).
- A **Google Custom Search API Key** and a **Search Engine ID (CX)** (for fetching similar images).

### Steps to Run

1. **Clone the Repository**

   ```bash
   git clone https://github.com/calKU0/AIImageClassifier.git
   cd AIImageClassifier
   ```

2. **Install Dependencies**

   Run the following command to restore the required packages:

   ```bash
   dotnet restore
   ```

3. **Set up Configuration**

   Add your API keys and configuration to the `appsettings.json` file:

   ```json
   {
     "HuggingFace": {
       "ApiToken": "your_huggingface_api_token"
     },
     "Google": {
       "ApiKey": "your_google_api_key",
       "cx": "your_google_cx"
     }
   }
   ```

4. **Run the Application**

   Once everything is set up, you can run the application using the following command:

   ```bash
   dotnet run
   ```

   The application will be available at `http://localhost:5000`.

5. **Upload an Image**

   - Navigate to the homepage.
   - Upload an image, and the application will display:
     - The classified label of the image along with a confidence score.
     - A preview of the uploaded image.
     - A set of similar images fetched from the Google Custom Search API.

## How It Works

1. **Image Upload**: The user uploads an image via a form. The image is sent to the server.
2. **Image Classification**: The server sends the image to the Hugging Face API (`microsoft/resnet-50` model) to classify the image. The response contains a label for the image along with a confidence score.

3. **Similar Image Search**: Using the label of the classified image, the application makes a request to the Google Custom Search API to find similar images.

4. **Display Results**: The classified label, confidence score, image preview, and similar images are displayed to the user in a modern, responsive UI.

## Folder Structure

```
AIImageClassifier/
├── Controllers/
│   └── HomeController.cs       # Handles image upload and classification logic
├── Models/
│   └── ImageInputModel.cs      # Model for handling the uploaded image and results
│   └── ClassificationResult.cs # Defines the classification result structure
├── Services/
│   └── IImageClassifier.cs     # Interface for image classification services
│   └── HuggingFaceImageClassifier.cs # Implements the classification logic using Hugging Face API
├── Views/
│   └── Home/
│       └── Index.cshtml        # View for image upload, preview, and results display
├── appsettings.json            # Application configuration (API Keys, etc.)
├── Startup.cs                  # Application configuration and middleware setup
├── Program.cs                  # Main entry point of the application
└── README.md                   # This file
```

## Custom Search API

For searching similar images, the app uses **Google Custom Search API**. Ensure you set up your Google Custom Search Engine properly.

1. Go to [Google Custom Search Engine](https://cse.google.com/cse/) and create a search engine.
2. Enable image search and set up the API.
3. Add the API key and the CX (Search Engine ID) to your `appsettings.json`.

## Troubleshooting

### Errors with Hugging Face API

- Make sure the API token is valid and has the required permissions.
- Check that the `ResNet-50` model is available in Hugging Face's model hub.

### Errors with Google Custom Search API

- Ensure that the API key and the `cx` value are correct.
- Double-check that image search is enabled in the Google Custom Search settings.

## Contributions

If you would like to contribute to this project, feel free to fork the repository, make your changes, and submit a pull request. Any contributions are welcome!

## License

This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.
