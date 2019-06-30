using System;
using Microsoft.Azure.WebJobs.Description;

namespace TableStorageEventStoreBinding
{
    /// <summary>
    ///     Attribute used to bind a parameter to an Azure Table Storage used as EventStore to store Business Events.
    ///     Data will posted to Table Storage when the method completes.
    /// </summary>
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public sealed class TableStorageEventStoreAttribute : Attribute
    {
        /// <summary>
        ///     Key of function.json configuration
        /// </summary>
        [AutoResolve]
        public string ConnectionStringName { get; set; }

        /// <summary>
        ///     Name of Stream where the Event Date will be saved or retrieved from.
        ///     Use a data field of your data package described in curly braces to make it dynamic. :)
        /// </summary>
        [AutoResolve]
        public string EventStreamName { get; set; }
    }
}