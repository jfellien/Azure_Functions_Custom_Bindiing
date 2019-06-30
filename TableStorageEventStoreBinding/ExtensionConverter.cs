using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;

namespace TableStorageEventStoreBinding
{
    internal static class ExtensionConverter
    {
        public static ExtensionConfigContext AddStringConverter(this ExtensionConfigContext context)
        {
            return context.AddConverter<string, EventBag>(input => JsonConvert.DeserializeObject<EventBag>(input));
        }
    }
}