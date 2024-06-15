using Newtonsoft.Json;

namespace Assignment_5__Employee_Management_System_.DTO
{
    public class AddressDTO
    {
        [JsonProperty(PropertyName = "street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "zipcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ZipCode { get; set; }
    }
}
