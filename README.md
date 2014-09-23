NServiceBus.Solr
================
This simply library provide a few points to integrate Apache Solr with NServiceBus infrastructure. It allows to:
* invoke delta import for Apache Solr collection when some NServiceBus event occurs,
* monitor availability of Apache Solr collection by ServiceControl and ServicePulse,

Trigger delta import
--------------------

To configure which collection should be updated on which event you have to create class with configuration.

    public class UpdateOrderSearchItem : ConfigureSolrIntegration
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
    
By default any exception occured while invoking delta import is caught and logged as a warning. If you want to change that behavior you have to point that explicitly by invoking:

    this.TriggerDeltaImportFor<OrderSearchItem>(throttleErrors: false)

Monitor availability of collection
----------------------------------

In order to monitor availability of the Apache Solr collection by ServiceControl and ServicePulsce you have to extend configuration of your `ConfigureSolrIntegration` class by the following instructions:

    public class MonitorAvailabilityOfOrderSearchItem : ConfigureSolrIntegration
    {
        protected override void Configure()
        {
            this.Ping<OrderSearchItem>()
                .Every(10.Minutes());
      }
    }

Known issues
------------

* Periodic refreshing index (method ```Every(TimeSpan time)```) doesn't work yet for XML serializer.
