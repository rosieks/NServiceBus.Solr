namespace NServiceBus.Solr
{
    using NServiceBus.Features;
    using NServiceBus.ObjectBuilder;
    using NServiceBus.Solr.Infrastructure;

    public abstract class ConfigureSolrIntegration : Feature, IWantToRunBeforeConfiguration
    {
        public IConfigureComponents Configurer { get; set; }

        void IWantToRunBeforeConfiguration.Init()
        {
            NServiceBus.Configure.TypesToScan.Remove(typeof(SolrPingPeriodicCheck<>));
            this.Configure();
        }

        protected abstract void Configure();

        public override bool IsEnabledByDefault
        {
            get
            {
                return true;
            }
        }

        protected TriggerDeltaImportFluent<TCollection> TriggerDeltaImportFor<TCollection>(bool throttleErrors = true)
        {
            return new TriggerDeltaImportFluent<TCollection>(
                NServiceBus.Configure.Instance.Configurer,
                throttleErrors);
        }

        protected PingFluent<TCollection> Ping<TCollection>()
        {
            return new PingFluent<TCollection>(
                NServiceBus.Configure.Instance.Configurer);
        }
    }
}
