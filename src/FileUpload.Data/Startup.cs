using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace FileUpload.Data;

[ExcludeFromCodeCoverage]
public class Startup
{
    private String Connection { get; }

    public Startup(IHostEnvironment host)
    {
        Connection = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(host.ContentRootPath)!.FullName)
            .AddJsonFile("FileUpload.Web/configuration.json")
            .AddJsonFile($"FileUpload.Web/configuration.{host.EnvironmentName.ToLower()}.json", optional: true)
            .Build()["Data:Connection"];
    }

    public void Configure()
    {
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<Context>(options => options.UseSqlServer(Connection));
    }
}
