using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace TableStorageEventStoreBinding
{
    /// <summary>
    ///     Contains the configuration for that binding
    /// </summary>
    [Extension("TableStorageEventStore")]
    public class TableStorageEventStoreExtension : IExtensionConfigProvider
    {
        public string DefaultStreamName { get; set; }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddStringConverter();

            context.AddBindingRule<TableStorageEventStoreAttribute>()
                .BindToCollector(attribute => new TableStorageEventStream(attribute, this));
        }
    }
}