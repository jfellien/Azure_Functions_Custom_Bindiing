using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace TableStorageEventStoreBinding
{
    /// <summary>
    ///     Takes the data and sends to a bounded Azure Table Storage.
    /// </summary>
    internal class TableStorageEventStream : IAsyncCollector<EventBag>
    {
        private readonly TableStorageEventStoreAttribute _attribute;
        private readonly TableStorageEventStoreExtension _extension;

        public TableStorageEventStream(TableStorageEventStoreAttribute attribute,
            TableStorageEventStoreExtension extension)
        {
            _attribute = attribute;
            _extension = extension;
        }

        public Task AddAsync(EventBag eventBag, CancellationToken cancellationToken = default)
        {
            eventBag.PartitionKey = FirstOrDefault(_attribute.EventStreamName, _extension.DefaultStreamName);
            eventBag.RowKey = Guid.NewGuid().ToString();

            return Task.CompletedTask;
            ;
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        private static string FirstOrDefault(params string[] values)
        {
            return values.FirstOrDefault(v => !string.IsNullOrEmpty(v));
        }
    }
}