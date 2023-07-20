using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAPI1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
.AddAzureMonitorTraceExporter(options =>
{
options.ConnectionString = "InstrumentationKey=abaf2cc5-14b8-43c4-95b9-6db0e1c0ccdd;IngestionEndpoint=https://eastus2-3.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus2.livediagnostics.monitor.azure.com/";
});

            var metricsProvider = Sdk.CreateMeterProviderBuilder()
                .AddAzureMonitorMetricExporter(options =>
                {
                    options.ConnectionString = "InstrumentationKey=abaf2cc5-14b8-43c4-95b9-6db0e1c0ccdd;IngestionEndpoint=https://eastus2-3.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus2.livediagnostics.monitor.azure.com/";
                });

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddAzureMonitorLogExporter(options1 =>
                    {
                        options1.ConnectionString = "InstrumentationKey=abaf2cc5-14b8-43c4-95b9-6db0e1c0ccdd;IngestionEndpoint=https://eastus2-3.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus2.livediagnostics.monitor.azure.com/";
                    });

                });
            });
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
