namespace NServiceBus.Solr.Infrastructure
{
    using System;
    using NServiceBus.ObjectBuilder;
    using ServiceControl.Plugin.CustomChecks;
    using SolrNet;
    using SolrNet.Exceptions;

    internal class SolrPingPeriodicCheck<TCollection> : PeriodicCheck
    {
        public SolrPingPeriodicCheck(string collectionName, TimeSpan interval)
            : base(string.Format("Solr collection {0} availability check", collectionName), "Solr", interval)
        {
        }

        public IBuilder Builder { get; set; }

        public override CheckResult PerformCheck()
        {
            try
            {
                var basicOperations = this.Builder.Build<ISolrBasicOperations<TCollection>>();

                var responseHeader = basicOperations.Ping();

                return CheckResult.Pass;
            }
            catch (SolrConnectionException ex)
            {
                return CheckResult.Failed(ex.Message);
            }
        }
    }
}
