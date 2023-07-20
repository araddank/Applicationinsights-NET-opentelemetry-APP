using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddAzureMonitorTraceExporter(options =>
            {
                options.ConnectionString = "InstrumentationKey=xxxxxxxxxxx;IngestionEndpoint=https://eastus2-3.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus2.livediagnostics.monitor.azure.com/";
            }).AddOtlpExporter();

            var metricsProvider = Sdk.CreateMeterProviderBuilder()
                .AddAzureMonitorMetricExporter(options =>
                {
                    options.ConnectionString = "InstrumentationKey=xxxxxxxxxxxxxxx;IngestionEndpoint=https://eastus2-3.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus2.livediagnostics.monitor.azure.com/";
                }).AddOtlpExporter();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddAzureMonitorLogExporter(options1 =>
                    {
                        options1.ConnectionString = "InstrumentationKey=xxxxxxxxxxxxxxxx;IngestionEndpoint=https://eastus2-3.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus2.livediagnostics.monitor.azure.com/";
                    });

                });
            });

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
