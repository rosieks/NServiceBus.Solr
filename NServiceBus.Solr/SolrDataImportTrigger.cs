namespace NServiceBus.Solr
{
    using NServiceBus.Features;
    using NServiceBus.ObjectBuilder;

    public abstract class SolrDataImportTrigger : Feature, IWantToRunBeforeConfiguration
    {
        public IConfigureComponents Configurer { get; set; }

        void IWantToRunBeforeConfiguration.Init()
        {
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
    }
}
