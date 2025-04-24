using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;

namespace MovieApp.Repositories
{
    public class CloudinaryImageRepository : IImageRepository
    {
        public async Task<string> UploadAsync(IFormFile file)
        {
            DotEnv.Load();
            var cloudinaryUrl = Environment.GetEnvironmentVariable("CLOUDINARY_URL");
            Cloudinary cloudinary = new Cloudinary(cloudinaryUrl);
            cloudinary.Api.Secure = true;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                DisplayName = file.FileName
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.JsonObj["secure_url"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
