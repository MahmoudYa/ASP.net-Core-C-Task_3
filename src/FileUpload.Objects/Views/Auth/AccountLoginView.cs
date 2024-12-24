using FileUpload.Components.Mvc;

namespace FileUpload.Objects;

public class AccountLoginView : AView
{
    [StringLength(32)]
    public String Username { get; set; }

    [NotTrimmed]
    [StringLength(32)]
    public String Password { get; set; }

    public String? ReturnUrl { get; set; }
}