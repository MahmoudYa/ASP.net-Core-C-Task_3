using FileUpload.Components.Mvc;

namespace FileUpload.Objects;

public class ProfileDeleteView : AView
{
    [NotTrimmed]
    [StringLength(32)]
    public String Password { get; set; }
}
