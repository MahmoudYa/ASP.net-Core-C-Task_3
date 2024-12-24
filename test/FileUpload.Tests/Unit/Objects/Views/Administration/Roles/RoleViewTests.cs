using FileUpload.Components.Tree;

namespace FileUpload.Objects;

public class RoleViewTests
{
    [Fact]
    public void RoleView_CreatesEmpty()
    {
        MvcTree actual = new RoleView().Permissions;

        Assert.Empty(actual.SelectedIds);
        Assert.Empty(actual.Nodes);
    }
}
