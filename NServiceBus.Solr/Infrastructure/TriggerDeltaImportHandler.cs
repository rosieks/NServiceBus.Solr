namespace NServiceBus.Solr.Infrastructure
{
    using System;
    using NServiceBus.Logging;
    using SolrNet;

    internal class TriggerDeltaImportHandler<TDocument, TEvent> : IHandleMessages<TEvent>
    {
        private static readonly ILog Log = LogManager.LoggerFactory.GetLogger(typeof(TriggerDeltaImportHandler<TDocument, TEvent>));
        private readonly ISolrBasicOperations<TDocument> operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerDeltaImportHandler{TDocument, TEvent}"/> class.
        /// </summary>
        /// <param name="operations">Solr operations.</param>
        public TriggerDeltaImportHandler(ISolrBasicOperations<TDocument> operations)
        {
            this.operations = operations;
        }

        public bool ThrottleErrors { get; set; }

        public void Handle(TEvent message)
        {
            try
            {
                this.operations.Send(new SolrDeltaImportCommand());
            }
            catch (Exception ex)
            {
                if (this.ThrottleErrors)
                {
                    Log.Warn("Unable to send delta import command for " + typeof(TDocument).FullName, ex);
                }
                else
                { 
                    throw;
                }
            }
        }
    }
}
