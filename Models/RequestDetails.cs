using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment_QA_AjayAL.Models
{
    internal class RequestDetails
    {
        [JsonProperty("InitialBalance")]
        public double InitialBalance { get; set; }

        [JsonProperty("AccountName")]
        public string AccountName { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("Amount")]
        public double Amount { get; set; }
    }
}
