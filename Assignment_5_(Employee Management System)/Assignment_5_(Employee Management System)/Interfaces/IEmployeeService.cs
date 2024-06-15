using Assignment_5__Employee_Management_System_.DTO;

namespace Assignment_5__Employee_Management_System_.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeBasicModel> AddEmployeeBasicDetails(EmployeeBasicModel employeeBasicModel);
        Task<List<EmployeeBasicModel>> GetAllEmployee();
        Task<EmployeeBasicModel> GetEmployeeById(string Uid);
        Task<EmployeeBasicModel> UpdateEmployee(EmployeeBasicModel employeeBasicModel);
        Task<string> DeleteEmployee(string Uid);
        Task<EmployeeAdditionalDetailsModel> AddAdditionalDetails(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel);
        Task<List<EmployeeAdditionalDetailsModel>> GetAllEmployeeAdditionalDetails();
        Task<EmployeeAdditionalDetailsModel> GetAdditionalDetailsById(string basicUid);
        Task<EmployeeAdditionalDetailsModel> UpdateAdditionalDetails(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel);
        Task<string> DeleteAddtionalData(string Uid);
    }
}
