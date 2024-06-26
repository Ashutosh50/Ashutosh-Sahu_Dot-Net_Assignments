using Assignment_5__Employee_Management_System_.DTO;
using Assignment_5__Employee_Management_System_.Entity;
using Microsoft.AspNetCore.Mvc;

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
        Task<List<EmployeeBasicModel>> GetEmployeeByRole(string role);
        Task<Filtercriteria> FilterbyPagenation(Filtercriteria filter);
        Task <EmployeeBasicModel>AddEmployeeBasicByMakePostRequest(EmployeeBasicModel employeeBasicModel);
        Task<List<EmployeeBasicModel>> GetAllEmployeesBasicByMakeGetRequest();
        Task<EmployeeBasicModel> GetEmployeeBasicByIdMakeGetRequest(string Uid);
        Task<EmployeeBasicModel> UpdateEmployeeBasicByMakePostRequest(EmployeeBasicModel employeeBasicModel);
        Task<EmployeeAdditionalDetailsModel> AddEmployeeAdditionalByMakePostRequest(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel);
        Task<List<EmployeeAdditionalDetailsModel>> GetAllEmployeesAdditionalByMakeGetRequest();
        Task<EmployeeAdditionalDetailsModel> GetEmployeeAdditionalByIdMakeGetRequest(string uid);
        Task<EmployeeAdditionalDetailsModel> UpdateEmployeeAdditionalByMakePostRequest(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel);
        Task<FiltercriteriaAdditional> FilterbyPagenationAdditional(FiltercriteriaAdditional additional);
        Task<Filtercriteria> FilterBasicdetailGetAllDefault(Filtercriteria filtercriteria);
        Task<FiltercriteriaAdditional> FilterAdditionaldetailGetAllDefault(FiltercriteriaAdditional filtercriteria);
        Task<EmployeeAdditionalDetailsModel> GetEmployeeAdditionalDetailsByBasicDetailsUIdFilterCriteria(string fieldValue);
    }
}