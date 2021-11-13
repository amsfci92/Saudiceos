using FluentValidation.Mvc;
using Microsoft.Owin;
using Owin;
using Serilog;
using System.IO;

[assembly: OwinStartupAttribute(typeof(Saudiceos.Enterprise.Web.Startup))]
namespace Saudiceos.Enterprise.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            FluentValidationModelValidatorProvider.Configure();
            Log.Logger = SerilogConfig.CreateLogger();
        }
    }
}
