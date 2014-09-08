namespace NServiceBus.Solr
{
    using System;
    using NServiceBus.ObjectBuilder;
    using NServiceBus.Unicast;

    public class TriggerDeltaImportFluent<TCollection>
    {
        private readonly IConfigureComponents configurer;
        private readonly MessageHandlerRegistry messageHandlerRegistry;
        private readonly bool throttleErrors;

        public TriggerDeltaImportFluent(MessageHandlerRegistry messageHandlerRegistry, IConfigureComponents configurer, bool throttleErrors)
        {
            this.messageHandlerRegistry = messageHandlerRegistry;
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