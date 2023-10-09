using System.ComponentModel;
using Courses.Web.Extensions;

namespace Courses.Web.Utilities.ImageHandler;

public static class PathTools
{
    public static string GetStaticFilePath(StaticFilePath path, StaticFileType type, StaticFileUseCase useCase)
    {
        string baseAddress = $"/content/{path.GetDescription()}/";
        switch (type)
        {
            case StaticFileType.Main:
                break;
            case StaticFileType.Thumbnail:
                baseAddress += "/thumbs/";
                break;
        }

        switch (useCase)
        {
            case StaticFileUseCase.Show:
                break;
            case StaticFileUseCase.Save:
                baseAddress = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{baseAddress}");
                break;
        }

        return baseAddress;
    }
}

public enum StaticFilePath
{
    [Description("courses")] Course,
    [Description("videos")] Video,
}

public enum StaticFileType
{
    Main,
    Thumbnail
}

public enum StaticFileUseCase
{
    Show,
    Save
}