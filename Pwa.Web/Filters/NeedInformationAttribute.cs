using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Pwa.Application.Contracts.Account.Statistic;
using Wangkanai.Detection.Services;

namespace Pwa.Web.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NeedInformationAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var service = context.HttpContext.RequestServices.GetRequiredService<IDetectionService>();
            var statisticApplication = context.HttpContext.RequestServices.GetRequiredService<IStatisticApplication>();

            var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var requestPath = context.HttpContext.Request.Path;

            CreateStatisticDto statistic = new()
            {
                Browser = service.Browser.Name.ToString(),
                Device = service.Device.Type.ToString(),
                Os = service.Platform.Name.ToString(),
                Version = service.Browser.Version.ToString(),
                IpAddress = ipAddress,
                Path = requestPath
            };

            var result = await statisticApplication.Add(statistic);
            if (result.Success) await next.Invoke();
        }
    }
}
