using Assignment_5__Employee_Management_System_.DTO;
using Assignment_5__Employee_Management_System_.Entity;

namespace Assignment_5__Employee_Management_System_.CosmosDB
{
    public interface ICosmosDB
    {
        Task<EmployeeBasicDetailsEntity> AddEmployeeBasic(EmployeeBasicDetailsEntity employee);
        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployees();
        Task<EmployeeBasicDetailsEntity> GetEmployeeById(string Uid);
        Task RePlaceasync(dynamic entity);
        //Task<EmployeeBasicDetailsEntity> GetEmployeeBasicDetailsByUId(string uid);
        Task<EmployeeAditionalDetailsEntity> AddEmployeeAdditional(EmployeeAditionalDetailsEntity additional);
        Task<List<EmployeeAditionalDetailsEntity>> GetallEmployeesAdditionalDetails();
        Task<EmployeeAditionalDetailsEntity> GetAdditionalDetailsById(string basicUid);
    }
}
