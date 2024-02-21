using CloudinaryDotNet.Actions;

namespace RunApp.Servies.IServices
{
    //services are abstraction for non-database calls
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}