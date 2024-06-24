﻿using Assignment_5__Employee_Management_System_.Common;
using Assignment_5__Employee_Management_System_.DTO;
using Newtonsoft.Json;

namespace Assignment_5__Employee_Management_System_.Entity
{
    public class EmployeeBasicDetailsEntity : BaseEntity
    {
        [JsonProperty(PropertyName = "salutory", NullValueHandling = NullValueHandling.Ignore)]
        public string Salutory { get; set; }

        [JsonProperty(PropertyName = "firstname", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middlename", NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastname", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string NickName { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "employeeId", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeID { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "reportingManagerUid", NullValueHandling = NullValueHandling.Ignore)]
        public string ReportingManagerUId { get; set; }

        [JsonProperty(PropertyName = "reportingManagerName", NullValueHandling = NullValueHandling.Ignore)]
        public string ReportingManagerName { get; set; }

        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }
    }
    public class Filtercriteria 
    {
        public Filtercriteria() 
        {
            filters=  new List<Filterc>();
            Employees = new List<EmployeeBasicModel>();
        }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalcount { get; set; }
        public List<Filterc> filters { get; set; }
        public List<EmployeeBasicModel> Employees { get; set; }

    }
    public class Filterc 
    {
     public string FieldName { get; set; }
     public string FieldValue { get; set; }
    }
}
