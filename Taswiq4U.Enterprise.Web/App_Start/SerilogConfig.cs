
using Serilog;
using SerilogWeb.Classic.Enrichers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Serilog.Enrichers;
using System.Web.Hosting;

namespace Saudiceos.Enterprise.Web
{
    public class SerilogConfig
    {
        public static ILogger CreateLogger()
        {
            var logpath = HostingEnvironment.MapPath("~");
            var config = new LoggerConfiguration()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("ApplicationName", AssemblyTitle)
                .Enrich.With<HttpRequestClientHostIPEnricher>()
                .Enrich.With<HttpRequestRawUrlEnricher>()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<UserNameEnricher>()
                //.Enrich.WithProperty("RuntimeVersion", Environment.Version)
                // this ensures that calls to LogContext.PushProperty will cause the logger to be enriched
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.Seq(ConfigurationManager.AppSettings["SeqServer"], apiKey: ConfigurationManager.AppSettings["SeqApiKey"])
                .WriteTo.File(Path.Combine(logpath, "Logs\\EricSunTestLog-{Date}.log"), retainedFileCountLimit: null, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {SourceContext} - ({MachineName}|{HttpRequestId}|{UserName}) {Message}{NewLine}{Exception}");
            return config.CreateLogger();
        }

        public static string AssemblyTitle
        {
            get
            {
                var attributes = typeof(SerilogConfig).Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title.Length > 0)
                        return titleAttribute.Title;
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
            }
        }
    }
}