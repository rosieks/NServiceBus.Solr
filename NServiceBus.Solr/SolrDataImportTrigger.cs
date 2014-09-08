namespace NServiceBus.Solr
{
    using NServiceBus.Features;
    using NServiceBus.ObjectBuilder;
    using NServiceBus.Unicast;

    public abstract class SolrDataImportTrigger : Feature, IWantToRunBeforeConfiguration
    {
        public IMessageHandlerRegistry MessageHandlerRegistry { get; set; }

        public IConfigureComponents Configurer { get; set; }

        public IBus Bus { get; set; }

        protected abstract void Configure();

        protected TriggerDeltaImportFluent<TCollection> TriggerDeltaImportFor<TCollection>(bool throttleErrors = true)
        {
            return new TriggerDeltaImportFluent<TCollection>(
                (MessageHandlerRegistry)this.MessageHandlerRegistry,
                NServiceBus.Configure.Instance.Configurer,
                throttleErrors);
        }

        public override void Initialize()
        {
            //this.Configure();
        }

        public void Init()
        {
            this.Configure();
        }

        public override bool IsEnabledByDefault
        {
            get
            {
                return true;
            }
        }
    }
}
