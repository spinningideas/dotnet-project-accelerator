namespace DNPA.Models
{
    /// <summary>
    /// Generic response for service operations within the DNPA application
    /// </summary>
    public class Response
    {
        public Response(bool success, string messages)
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
