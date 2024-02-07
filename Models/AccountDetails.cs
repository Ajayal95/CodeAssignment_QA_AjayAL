using Newtonsoft.Json;

namespace CodeAssignment_QA_AjayAL.Models
{
    internal class AccountDetails
    {
        [JsonProperty("Data")]
        public Data? Data { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Errors")]
        public Errors[]? Errors { get; set; }
    }

    internal class Data
    {
        [JsonProperty("NewBalance")]
        public double NewBalance { get; set; }

        [JsonProperty("AccountName")]
        public string AccountName { get; set; }

        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("Amount")]
        public double Amount { get; set; }

        [JsonProperty("AccountID")]
        public string AccountID { get; set; }
    }

    internal class Errors
    {

    }
}
