using Microsoft.AspNetCore.Mvc.ModelBinding;
using FileUpload.Components.Notifications;

namespace FileUpload.Validators;

public interface IValidator : IDisposable
{
    Alerts Alerts { get; set; }
    ModelStateDictionary ModelState { get; set; }
}
