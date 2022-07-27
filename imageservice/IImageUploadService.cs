namespace CVs.imageservice

{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile Im);
    }
}
