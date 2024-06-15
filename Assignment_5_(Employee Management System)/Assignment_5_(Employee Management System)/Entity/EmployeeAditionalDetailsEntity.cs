using Assignment_5__Employee_Management_System_.Common;
using Newtonsoft.Json;

namespace Assignment_5__Employee_Management_System_.Entity
{
    public class EmployeeAditionalDetailsEntity : BaseEntity
    {
        [JsonProperty(PropertyName = "employeeBasicDetailsUid", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeBasicDetailsUId { get; set; }

        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateEmail { get; set; }

        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateMobile { get; set; }

        [JsonProperty(PropertyName = "workinformation", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo WorkInformation { get; set; }

        [JsonProperty(PropertyName = "personaldetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetails PersonalDetails { get; set; }

        [JsonProperty(PropertyName = "identityinformation", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfo IdentityInformation { get; set; }
    }
}
