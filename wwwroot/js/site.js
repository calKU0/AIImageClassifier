document.addEventListener('DOMContentLoaded', function () {
    var previewImage = document.getElementById("previewImage");

    // If model.UploadedImageBase64 is not empty, the image preview should be visible
    if (previewImage.src && previewImage.src !== "#") {
        // Make sure the image preview stays visible after form submission
        previewImage.style.display = "block"; // Force visibility
    }
});