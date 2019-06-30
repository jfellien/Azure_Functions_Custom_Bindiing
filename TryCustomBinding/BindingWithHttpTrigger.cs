using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using TableStorageEventStoreBinding;

namespace TryCustomBinding
{
    public static class BindingWithHttpTrigger
    {
        [FunctionName("BindingWithHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "store-event")]
            HttpRequest req,
            [TableStorageEventStore(ConnectionStringName = "TableStorageEventStore", EventStreamName = "default")]
            IAsyncCollector<string> businessEvent,
            ILogger log)
        {
            await businessEvent.AddAsync(await req.ReadAsStringAsync());

            return new OkObjectResult("Happen");
        }
    }
}