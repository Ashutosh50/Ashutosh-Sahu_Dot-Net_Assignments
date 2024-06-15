namespace Assignment_5__Employee_Management_System_.Common
{
    public class Credential
    {
        public static string databaseName = Environment.GetEnvironmentVariable("databaseName");
        public static string containerName = Environment.GetEnvironmentVariable("containerName");
        public static string cosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static string PrimeryKey = Environment.GetEnvironmentVariable("primarykey");
        internal static string doctype = "employee";
        internal static string Adoctype = "Extradetails";
        internal static string createdby = "Ashu";
    }
}
