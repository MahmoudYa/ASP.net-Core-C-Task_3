using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FileUpload.Components.Security;

[ExcludeFromCodeCoverage]
public class NotAttributedController : Controller
{
    [HttpGet]
    public ViewResult Action()
    {
        return View();
    }
}
