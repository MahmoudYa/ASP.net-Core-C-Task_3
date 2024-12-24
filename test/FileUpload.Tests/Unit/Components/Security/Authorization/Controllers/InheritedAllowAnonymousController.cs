using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FileUpload.Components.Security;

[ExcludeFromCodeCoverage]
public class InheritedAllowAnonymousController : AllowAnonymousController
{
    [HttpGet]
    public ViewResult InheritanceAction()
    {
        return View();
    }
}
