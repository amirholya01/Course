namespace Courses.Web.Utilities.ImageHandler
{
    public static class FileExtensions
    {
        public static void AddImageToServer(this IFormFile? image, string fileName, string originalPath, int? width, int? height, string? thumbPath, string? deleteFileName, bool checkImageContent = true)
        {
            if (image != null && image.IsImage(checkImageContent))
            {
                if (!Directory.Exists(originalPath))
                    Directory.CreateDirectory(originalPath);

                if (!string.IsNullOrEmpty(deleteFileName))
                {
                    if (File.Exists(originalPath + deleteFileName))
                        File.Delete(originalPath + deleteFileName);

                    if (!string.IsNullOrEmpty(thumbPath))
                    {
                        if (File.Exists(thumbPath + deleteFileName))
                            File.Delete(thumbPath + deleteFileName);
                    }
                }

                string finalPath = originalPath + fileName;

                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    if (!Directory.Exists(finalPath)) image.CopyTo(stream);
                }

                if (!string.IsNullOrEmpty(thumbPath))
                {
                    if (!Directory.Exists(thumbPath))
                        Directory.CreateDirectory(thumbPath);

                    ImageOptimizer resizer = new ImageOptimizer();

                    if (width != null && height != null)
                        resizer.ImageResizer(originalPath + fileName, thumbPath + fileName, width, height);
                }
            }
        }

        public static void AddFileToServer(this IFormFile? file, string fileName, string originalPath, string? deleteFileName)
        {
            if (file != null)
            {
                if (!Directory.Exists(originalPath))
                    Directory.CreateDirectory(originalPath);

                if (!string.IsNullOrEmpty(deleteFileName))
                {
                    if (File.Exists(originalPath + deleteFileName))
                        File.Delete(originalPath + deleteFileName);
                }

                string finalPath = originalPath + fileName;

                using (var stream = new FileStream(finalPath, FileMode.Create))
                {
                    if (!Directory.Exists(finalPath)) file.CopyTo(stream);
                }
            }
        }
        
        public static void DeleteImage(this string imageName, string originalPath, string? thumbnailPath)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                if (File.Exists(originalPath + imageName))
                    File.Delete(originalPath + imageName);

                if (!string.IsNullOrEmpty(thumbnailPath))
                {
                    if (File.Exists(thumbnailPath + imageName))
                        File.Delete(thumbnailPath + imageName);
                }
            }
        }
    }
}
