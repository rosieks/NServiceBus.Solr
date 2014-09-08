NServiceBus.Solr
================
This simply library provide you the ability to invoke delta import for Apache Solr collection when some NServiceBus event occurs. To configure which collection should be updated on which event you have to create class with configuration.

    public class UpdateOrderSearchItem : SolrDataImportTrigger
    {
        protected override void Configure()
        {
            this.TriggerDeltaImportFor<OrderSearchItem>()
                .Every(10.Minutes())
                .On<OrderSubmited>()
                .On<OrderAccepted>()
                .On<OrderBilled>()
                .On<OrderShipped>();
      }
    }
    
By default any exception during invoking delta import is caught and logged as a warning. If you want to avoid that you have to point that explicitly by invoking:

    this.TriggerDeltaImportFor<OrderSearchItem>(throttleErrors: false)


Known issues
------------

* Method `Every(TimeSpan time)` doesn't work yet for XML serializer.
