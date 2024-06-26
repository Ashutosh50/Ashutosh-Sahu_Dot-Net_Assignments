using Assignment_5__Employee_Management_System_.Entity;
using Newtonsoft.Json;

namespace Assignment_5__Employee_Management_System_.DTO
{
    public class EmployeeAdditionalDetailsModel
    {
        [JsonProperty(PropertyName = "employeeBasicDetailsUid", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeBasicDetailsUId { get; set; }

        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateEmail { get; set; }

        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateMobile { get; set; }

        [JsonProperty(PropertyName = "workinformation", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfoModel WorkInformation { get; set; }

        [JsonProperty(PropertyName = "personaldetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetailsModel PersonalDetails { get; set; }

        [JsonProperty(PropertyName = "identityinformation", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfoModel IdentityInformation { get; set; }
    }
}
