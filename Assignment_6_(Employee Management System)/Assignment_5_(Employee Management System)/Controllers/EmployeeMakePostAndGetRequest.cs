using Assignment_5__Employee_Management_System_.DTO;
using Assignment_5__Employee_Management_System_.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_5__Employee_Management_System_.Controllers
{
    [Route("api / [Controller] / [Action]")]
    [ApiController]
    public class EmployeeMakePostAndGetRequest : Controller
    {
        public readonly IEmployeeService _employeeService;
        public EmployeeMakePostAndGetRequest(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeBasicByMakePostRequest(EmployeeBasicModel employeeBasicModel)
        {
            var response = await _employeeService.AddEmployeeBasicByMakePostRequest(employeeBasicModel);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesBasicByMakeGetRequest()
        {
            var response = await _employeeService.GetAllEmployeesBasicByMakeGetRequest();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeBasicByIdMakeGetRequest(string Uid)
        {
            var response = await _employeeService.GetEmployeeBasicByIdMakeGetRequest(Uid);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeBasicByMakePostRequest(EmployeeBasicModel employeeBasicModel)
        {
            var response = await _employeeService.UpdateEmployeeBasicByMakePostRequest(employeeBasicModel);
            return Ok(response);

        }





        [HttpPost]
        public async Task<IActionResult> AddEmployeeAdditionalByMakePostRequest(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel)
        {
            var response = await _employeeService.AddEmployeeAdditionalByMakePostRequest(employeeAdditionalDetailsModel);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAdditionalByMakeGetRequest()
        {
            var response = await _employeeService.GetAllEmployeesAdditionalByMakeGetRequest();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeAdditionalByIdMakeGetRequest(string Uid)
        {
            var response = await _employeeService.GetEmployeeAdditionalByIdMakeGetRequest(Uid);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeAdditionalByMakePostRequest(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel)
        {
            var response = await _employeeService.UpdateEmployeeAdditionalByMakePostRequest(employeeAdditionalDetailsModel);
            return Ok(response);

        }
    }
}