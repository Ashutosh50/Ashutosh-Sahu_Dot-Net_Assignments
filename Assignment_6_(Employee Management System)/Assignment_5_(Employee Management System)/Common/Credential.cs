namespace Assignment_5__Employee_Management_System_.Common
{
    public class Credential
    {
        public static string databaseName = Environment.GetEnvironmentVariable("databaseName");
        public static string containerName = Environment.GetEnvironmentVariable("containerName");
        public static string cosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static string PrimeryKey = Environment.GetEnvironmentVariable("primarykey");

        public static string EmployeeUri = Environment.GetEnvironmentVariable("employeeUri");
        public static string AddEmployeeBasicEndpoint = "/api / Employee / AddEmployeeBasicDetails";
        public static string GetAllEmployeeBasicEndpoint = "/api / Employee / GetAllEmployee";
        public static string GetEmployeeByIdBasicEndpoint = "/api / Employee / GetEmployeeBasicDetailsById";
        public static string UpdateEmployeeBasicEndpoint = "/api / Employee / UpdateEmployeeBasicDetails";
        public static string DeleteEmployeeBasicEndpoint = "/api / Employee / DeleteEmployeeBasicDetails";
        public static string AddEmployeeAdditionalEndpoint = "/api / Employee / AddEmployeeAditionalDetails";
        public static string GetAllEmployeeAdditionalEndpoint = "/api / Employee / GetAllEmployeeAdditionalDetails";
        public static string GetEmployeeByIdAdditionalEndpoint = "/api / Employee / GetEmployeeAdditionalDetailsById";
        public static string UpdateEmployeeAdditionalEndpoint = "/api / Employee / UpdateAdditionalDetails";
        public static string DeleteEmployeeAdditionalEndpoint = "/api / Employee / DeleteAddtionalData";
        
        internal static string doctype = "employee";
        internal static string Adoctype = "Extradetails";
        internal static string createdby = "Ashu";
    }
}
