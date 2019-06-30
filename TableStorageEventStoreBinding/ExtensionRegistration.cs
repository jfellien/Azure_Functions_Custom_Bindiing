using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using TableStorageEventStoreBinding;

[assembly: WebJobsStartup(typeof(ExtensionRegistration))]

namespace TableStorageEventStoreBinding
{
    public class ExtensionRegistration : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<TableStorageEventStoreExtension>();
        }
    }
}