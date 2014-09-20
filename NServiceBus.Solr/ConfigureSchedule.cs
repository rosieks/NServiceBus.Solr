namespace NServiceBus.Solr.Infrastructure
{
    using System;
    using System.Collections.Generic;

    internal class ConfigureSchedule : IWantToRunWhenBusStartsAndStops
    {
        private static readonly IDictionary<Type, TimeSpan> Timespans = new Dictionary<Type, TimeSpan>();

        public IBus Bus { get; set; }

        public void Start()
        {
            foreach (var timeSpan in Timespans)
            {
                var messageType = typeof(TriggerDeltaImport<>).MakeGenericType(timeSpan.Key);
                var message = Activator.CreateInstance(messageType);
                Schedule.Every(timeSpan.Value).Action(() =>
                {
                    this.Bus.SendLocal(message);
                });
            }
        }

        public void Stop()
        {
        }

        internal static void Add<TCollection>(TimeSpan timeSpan)
        {
            if (Timespans.ContainsKey(typeof(TCollection)))
            {
                Timespans[typeof(TCollection)] = timeSpan;
            }
            else
            {
                Timespans.Add(typeof(TCollection), timeSpan);
            }
        }
    }
}
