namespace NServiceBus.Solr
{
    using System;
    using SolrNet;

    /// <summary>
    /// Delta import command. 
    /// </summary>
    public class SolrDeltaImportCommand : ISolrCommand
    {
        /// <summary>
        /// Executes the SOLR delta import for specified collection.
        /// </summary>
        /// <param name="connection">Connection that specify collection to update.</param>
        /// <returns>Result of the operation.</returns>
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
