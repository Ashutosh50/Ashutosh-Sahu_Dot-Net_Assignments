using Assignment_5__Employee_Management_System_.Common;
using Assignment_5__Employee_Management_System_.DTO;
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

    public class FiltercriteriaAdditional
    {
        public FiltercriteriaAdditional()
        {
            filtersadd = new List<FiltercAdditional>();
            EmployeesExtra = new List<EmployeeAdditionalDetailsModel>();
        }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalcount { get; set; }
        public List<FiltercAdditional> filtersadd { get; set; }
        public List<EmployeeAdditionalDetailsModel> EmployeesExtra { get; set; }

    }
    public class FiltercAdditional
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }
}
