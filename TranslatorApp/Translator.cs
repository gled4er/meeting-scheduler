using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Autofac;
using MicrosoftGraph.Services;
using TranslatorApp.Model;

namespace TranslatorApp
{
    public static class HelloSequence
    {
        [FunctionName("Scheduler")]
        public static async Task<string> Run(
            [OrchestrationTrigger] DurableOrchestrationContext context)
        {

            var request = context.GetInput<TranslatorRequest>();
            var output = await context.CallFunctionAsync<string>("MeetingScheduler", request);

            return output;
        }

        [FunctionName("MeetingScheduler")]
        public static string DocumentTranslator([ActivityTrigger] TranslatorRequest request)
        {
            var containerBuilder = new ContainerBuilder();

            #region Dependency Injection Setup 

            containerBuilder.Register<ILoggingService>(b => new LoggingService());
            containerBuilder.Register<IHttpService>(b => new HttpService(b.Resolve<ILoggingService>()));
            var container = containerBuilder.Build();

            #endregion

            string result = string.Empty;

            return result;
        }
    }
}
