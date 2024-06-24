using Assignment_5__Employee_Management_System_.CosmosDB;
using Assignment_5__Employee_Management_System_.DTO;
using Assignment_5__Employee_Management_System_.Entity;
using Assignment_5__Employee_Management_System_.Interfaces;
using Assignment_5__Employee_Management_System_.ServiceFilter;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Assignment_5__Employee_Management_System_.Controllers
{
    [Route("api / [Controller] / [Action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<EmployeeBasicModel> AddEmployeeBasicDetails(EmployeeBasicModel employeeBasicModel)
        {
            var response = await _employeeService.AddEmployeeBasicDetails(employeeBasicModel);
            return response;
        }

        [HttpGet]
        public async Task<List<EmployeeBasicModel>> GetAllEmployee()
        {
            var response = await _employeeService.GetAllEmployee();
            return response;
        }

        [HttpGet]
        public async Task<EmployeeBasicModel> GetEmployeeBasicDetailsById(string Uid)
        {
            var response = await _employeeService.GetEmployeeById(Uid);
            return response;
        }

        [HttpPost]
        public async Task<EmployeeBasicModel> UpdateEmployeeBasicDetails(EmployeeBasicModel employeeBasicModel)
        {
            var response = await _employeeService.UpdateEmployee(employeeBasicModel);
            return response;
        }

        [HttpPost]
        public async Task<string> DeleteEmployeeBasicDetails(string Uid)
        {
            var response = await _employeeService.DeleteEmployee(Uid);
            return response;
        }

        // Aditional
        [HttpPost]
        public async Task<EmployeeAdditionalDetailsModel> AddEmployeeAditionalDetails(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel)
        {
            var response = await _employeeService.AddAdditionalDetails(employeeAdditionalDetailsModel);
            return response;
        }


        [HttpGet]
        public async Task<List<EmployeeAdditionalDetailsModel>> GetAllEmployeeAdditionalDetails()
        {
            var response = await _employeeService.GetAllEmployeeAdditionalDetails();
            return response;
        }

        [HttpGet]
        public async Task<EmployeeAdditionalDetailsModel> GetEmployeeAdditionalDetailsById(string BasicUid)
        {
            var response = await _employeeService.GetAdditionalDetailsById(BasicUid);
            return response;
        }

        [HttpPost]
        public async Task<EmployeeAdditionalDetailsModel> UpdateAdditionalDetails(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel)
        {
            var response = await _employeeService.UpdateAdditionalDetails(employeeAdditionalDetailsModel);
            return response;
        }

        [HttpPost]
        public async Task<string> DeleteAddtionalData(string Uid)
        {
            var response = await _employeeService.DeleteAddtionalData(Uid);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Upload a file.");

            var employees = new List<EmployeeBasicModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var employee = new EmployeeBasicModel
                            {
                                Salutory = worksheet.Cells[row, 1].Text,
                                FirstName = worksheet.Cells[row, 2].Text,
                                MiddleName = worksheet.Cells[row, 3].Text,
                                LastName = worksheet.Cells[row, 4].Text,
                                NickName = worksheet.Cells[row, 5].Text,
                                Email = worksheet.Cells[row, 6].Text,
                                Mobile = worksheet.Cells[row, 7].Text,
                                Role = worksheet.Cells[row, 8].Text,
                                ReportingManagerUId = worksheet.Cells[row, 9].Text,
                                ReportingManagerName = worksheet.Cells[row, 10].Text,
                                Address = new AddressDTO
                                {
                                    Street = worksheet.Cells[row, 11].Text,
                                    City = worksheet.Cells[row, 12].Text,
                                    State = worksheet.Cells[row, 13].Text,
                                    Country = worksheet.Cells[row, 14].Text,
                                    ZipCode = worksheet.Cells[row, 15].Text
                                }
                            };

                            employees.Add(employee);
                        }
                    }
                }

                foreach (var employee in employees)
                {
                    await _employeeService.AddEmployeeBasicDetails(employee);
                }

                return Ok("Import successful.");
            
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var employees = await _employeeService.GetAllEmployee();
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");

                // Adding the headers
                worksheet.Cells[1, 1].Value = "Sr.No";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Last Name";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Phone No";
                worksheet.Cells[1, 6].Value = "Reporting Manager Name";
                worksheet.Cells[1, 7].Value = "Date Of Birth";
                worksheet.Cells[1, 8].Value = "Date of Joining";

                // Adding the data
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    // Fetch additional details for each employee
                    var additionalDetails = await _employeeService.GetAdditionalDetailsById(employee.UId);

                    worksheet.Cells[i + 2, 1].Value = i + 1; // Sr.No
                    worksheet.Cells[i + 2, 2].Value = employee.FirstName;
                    worksheet.Cells[i + 2, 3].Value = employee.LastName;
                    worksheet.Cells[i + 2, 4].Value = employee.Email;
                    worksheet.Cells[i + 2, 5].Value = employee.Mobile;
                    worksheet.Cells[i + 2, 6].Value = employee.ReportingManagerName;
                    worksheet.Cells[i + 2, 7].Value = additionalDetails.PersonalDetails.DateOfBirth.ToString("yyyy-MM-dd"); 
                    worksheet.Cells[i + 2, 8].Value = additionalDetails.WorkInformation.DateOfJoining.ToString("yyyy-MM-dd");
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Employees.xlsx";
                return File(stream, contentType, fileName);
            }
        }
        [HttpGet]
        public async Task<List<EmployeeBasicModel>> GetEmployeeByRole(string role) 
        {
            var response = await _employeeService.GetEmployeeByRole(role);
            return response;
        }

        [HttpPost]
        [ServiceFilter(typeof(BuildEmployeeBasicFilter))]
        public async Task<Filtercriteria> FilterBasic(Filtercriteria filter) 
        {
            var response = await _employeeService.FilterbyPagenation(filter);
            return response;
        }

        [HttpPost]
        [ServiceFilter(typeof(BuildEmployeeAdditionalFilter))]
        public async Task<FiltercriteriaAdditional> FilterAdditonal(FiltercriteriaAdditional additional)
        {
            var response = await _employeeService.FilterbyPagenationAdditional(additional);
            return response;
        }

    }
}