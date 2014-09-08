namespace NServiceBus.Solr
{
    using System;
    using NServiceBus.ObjectBuilder;

    public class TriggerDeltaImportFluent<TCollection>
    {
        private readonly IConfigureComponents configurer;
        private readonly bool throttleErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerDeltaImportFluent{TCollection}"/> class.
        /// </summary>
        public TriggerDeltaImportFluent(IConfigureComponents configurer, bool throttleErrors)
        {
            this.configurer = configurer;
            this.throttleErrors = throttleErrors;
        }

        public TriggerDeltaImportFluent<TCollection> On<TEvent>()
        {
            var messageHandlerType = typeof(TriggerDeltaImportHandler<TCollection, TEvent>);
            Configure.TypesToScan.Add(messageHandlerType);

            this.configurer.ConfigureProperty<TriggerDeltaImportHandler<TCollection, TEvent>>(
                x => x.ThrottleErrors, 
                this.throttleErrors);

            return this;
        }

        public TriggerDeltaImportFluent<TCollection> Every(TimeSpan timeSpan)
        {
            ConfigureSchedule.Add<TCollection>(timeSpan);

            var messageType = typeof(TriggerDeltaImport<TCollection>);
            Configure.TypesToScan.Add(messageType);

            return this.On<TriggerDeltaImport<TCollection>>();
        }
    }
}