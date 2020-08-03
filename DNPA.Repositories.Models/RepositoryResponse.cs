namespace DNPA.Repositories.Models
{
    /// <summary>
    /// Response for repository operations within the DNPA application
    /// indicating simple success or failure and any resulting messages
    /// </summary>
    public class RepositoryResponse
    {
        public RepositoryResponse(bool success, string messages)
        {
            Success = success;
            Messages = messages;
        }

        /// <summary>
        /// Whether or not operation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Any messages related to success or failure of the operation.
        /// </summary>
        public string Messages { get; set; }
    }
}
