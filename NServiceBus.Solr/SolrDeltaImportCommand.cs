namespace NServiceBus.Solr
{
    using System;
    using SolrNet;

    public class SolrDeltaImportCommand : ISolrCommand
    {
        public string Execute(ISolrConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            return connection.Post("/dataimport?command=delta-import", string.Empty);
        }
    }
}
