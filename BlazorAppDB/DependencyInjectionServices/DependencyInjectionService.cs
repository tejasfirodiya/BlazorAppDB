using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Syncfusion.Licensing;

namespace BlazorAppDB.DependencyInjectionServices;
public static class DependencyInjectionService
{
    // ReSharper disable once MethodTooLong
    public static void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        builder.Services.AddScoped(x =>
        {
            var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            Debug.Assert(actionContext != null, nameof(actionContext) + " != null");

            var factory = x.GetRequiredService<IUrlHelperFactory>();

            return factory.GetUrlHelper(actionContext);
        });

        SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicenseService.LicenseKeyBlazor);
    }
}