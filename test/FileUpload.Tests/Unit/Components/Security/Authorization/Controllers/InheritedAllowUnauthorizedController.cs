using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FileUpload.Components.Security;

[ExcludeFromCodeCoverage]
public class InheritedAllowUnauthorizedController : AllowUnauthorizedController
{
    [HttpGet]
    public ViewResult InheritanceAction()
    {
        return View();
    }
}
