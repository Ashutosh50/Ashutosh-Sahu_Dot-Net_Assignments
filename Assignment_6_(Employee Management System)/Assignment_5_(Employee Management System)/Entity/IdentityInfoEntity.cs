using Newtonsoft.Json;

namespace Assignment_5__Employee_Management_System_.Entity
{
    public class IdentityInfo
    {

        [JsonProperty(PropertyName = "pan", NullValueHandling = NullValueHandling.Ignore)]
        public string PAN { get; set; }

        [JsonProperty(PropertyName = "aadhar", NullValueHandling = NullValueHandling.Ignore)]
        public string Aadhar { get; set; }

        [JsonProperty(PropertyName = "natioality", NullValueHandling = NullValueHandling.Ignore)]
        public string Nationality { get; set; }

        [JsonProperty(PropertyName = "salutory", NullValueHandling = NullValueHandling.Ignore)]
        public string PassportNumber { get; set; }
        [JsonProperty(PropertyName = "pfnumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PFNumber { get; set; }
    }
}
