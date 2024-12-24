namespace FileUpload.Resources;

internal class ResourceDictionary : ConcurrentDictionary<String, String?>
{
    public ResourceDictionary()
        : base(StringComparer.OrdinalIgnoreCase)
    {
    }
}
