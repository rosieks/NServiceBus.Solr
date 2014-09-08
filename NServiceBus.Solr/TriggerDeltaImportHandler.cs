namespace NServiceBus.Solr
{
    using System;
    using NServiceBus.Logging;
    using SolrNet;

    public class TriggerDeltaImportHandler<TDocument, TEvent> : IHandleMessages<TEvent>
    {
        private static readonly ILog Log = LogManager.LoggerFactory.GetLogger(typeof(TriggerDeltaImportHandler<TDocument, TEvent>));
        private readonly ISolrBasicOperations<TDocument> operations;

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
