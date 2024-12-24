using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FileUpload.Components.Security;

[AllowUnauthorized]
[ExcludeFromCodeCoverage]
public class AllowUnauthorizedController : AuthorizeController
{
    [HttpGet]
    public ViewResult AuthorizedAction()
    {
        return View();
    }
}
