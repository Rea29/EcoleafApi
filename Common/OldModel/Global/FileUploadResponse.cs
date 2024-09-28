namespace Common.ViewModels
{
    public class FileUploadResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string ImagePath { get; set; }

        public string ImageGuid { get; set; }
    }
}
