using Microsoft.AspNetCore.Mvc;
using FileUpload.Components.Lookups;
using FileUpload.Components.Security;
using FileUpload.Data;
using FileUpload.Objects;
using NonFactors.Mvc.Lookup;

namespace FileUpload.Controllers;

[AllowUnauthorized]
public class Lookup : AController
{
    private IUnitOfWork UnitOfWork { get; }

    public Lookup(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    [HttpGet]
    public JsonResult Role(LookupFilter filter)
    {
        return Json(new MvcLookup<Role, RoleView>(UnitOfWork) { Filter = filter }.GetData());
    }

    protected override void Dispose(Boolean disposing)
    {
        UnitOfWork.Dispose();

        base.Dispose(disposing);
    }
}
