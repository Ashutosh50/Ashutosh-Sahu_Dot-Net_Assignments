using Newtonsoft.Json;

namespace Assignment_5__Employee_Management_System_.DTO
{
    public class WorkInfoModel
    {
        [JsonProperty(PropertyName = "designationname", NullValueHandling = NullValueHandling.Ignore)]
        public string DesignationName { get; set; }

        [JsonProperty(PropertyName = "departmentname", NullValueHandling = NullValueHandling.Ignore)]
        public string DepartmentName { get; set; }

        [JsonProperty(PropertyName = "locationname", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationName { get; set; }

        [JsonProperty(PropertyName = "employeestatus", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeStatus { get; set; } // Terminated, Active, Resigned etc

        [JsonProperty(PropertyName = "sourceofhire", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceOfHire { get; set; }

        [JsonProperty(PropertyName = "dateofjoining", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateOfJoining { get; set; }
    }
}
