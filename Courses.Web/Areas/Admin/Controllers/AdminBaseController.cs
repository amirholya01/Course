using Microsoft.AspNetCore.Mvc;

namespace Courses.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBaseController : Controller
{
    public void SetTempDataMessage(TempMessageType type, string message)
    {
        switch (type)
        {
            case TempMessageType.Success:
                TempData["SuccessMessage"] = message;
                break;
            case TempMessageType.Info:
                TempData["InfoMessage"] = message;
                break;
            case TempMessageType.Warning:
                TempData["WarningMessage"] = message;
                break;
            case TempMessageType.Danger:
                TempData["DangerMessage"] = message;
                break;
        }
    }
}

public enum TempMessageType
{
    Success,
    Info,
    Warning,
    Danger
}