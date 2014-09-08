NServiceBus.Solr
================
This simply library provide you the ability to invoke delta import for Apache Solr collection when some NServiceBus event occurs. To configure which collection should be updated on which event you have to create class with configuration.

    public class UpdateOrderSearchItem : SolrDataImportTrigger
    {
      protected override void Configure()
      {
        this.TriggerDeltaImportFor<OrderSearchItem>()
          .Every(10.Minutes()) // this method doesn't work yet for XML serializer.
          .On<OrderSubmited>()
          .On<OrderAccepted>()
          .On<OrderBilled>()
          .On<OrderShipped>();
      }
    }

