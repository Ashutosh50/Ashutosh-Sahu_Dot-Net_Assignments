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
    public class Week8Assignment : Controller
    {
        public readonly IEmployeeService _employeeService;
        public Week8Assignment(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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

        [HttpPost]
        [ServiceFilter(typeof(BuildEmployeeBasicGetAll))]
        public async Task<Filtercriteria> FilterBasicdetailGetAllDefault(Filtercriteria filtercriteria) 
        {
        var response = await _employeeService.FilterBasicdetailGetAllDefault(filtercriteria);
            return response;
        }

        [HttpPost]
        [ServiceFilter(typeof(BuildEmployeeAdditionalFilter))]
        public async Task<FiltercriteriaAdditional> FilterAdditionaldetailGetAllDefault(FiltercriteriaAdditional filtercriteria)
        {
            var response = await _employeeService.FilterAdditionaldetailGetAllDefault(filtercriteria);
            return response;
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
                worksheet.Cells[1, 4].Value = "NickName";
                worksheet.Cells[1, 5].Value = "Email";
                worksheet.Cells[1, 6].Value = "Phone No";
                worksheet.Cells[1, 7].Value = "Role";
                worksheet.Cells[1, 8].Value = "Reporting Manager Name";
                worksheet.Cells[1, 9].Value = "Street";
                worksheet.Cells[1, 10].Value = "City";
                worksheet.Cells[1, 11].Value = "State";
                worksheet.Cells[1, 12].Value = "Country";
                worksheet.Cells[1, 13].Value = "ZipCode";
                worksheet.Cells[1, 14].Value = "AlternateEmail";
                worksheet.Cells[1, 15].Value = "AlternateMobile";
                worksheet.Cells[1, 16].Value = "DesignationName";
                worksheet.Cells[1, 17].Value = "LocationName";
                worksheet.Cells[1, 18].Value = "EmployeeStatus";
                worksheet.Cells[1, 19].Value = "SourceOfHire";
                worksheet.Cells[1, 20].Value = "DateOfJoining";
                worksheet.Cells[1, 21].Value = "DateOfBirth";
                worksheet.Cells[1, 22].Value = "Age";
                worksheet.Cells[1, 23].Value = "Gender";
                worksheet.Cells[1, 24].Value = "Religion";
                worksheet.Cells[1, 25].Value = "Caste";
                worksheet.Cells[1, 26].Value = "MaritalStatus";
                worksheet.Cells[1, 27].Value = "BloodGroup";
                worksheet.Cells[1, 28].Value = "Height";
                worksheet.Cells[1, 29].Value = "Weight";
                worksheet.Cells[1, 30].Value = "PAN";
                worksheet.Cells[1, 31].Value = "Aadhar";
                worksheet.Cells[1, 32].Value = "Nationality";
                worksheet.Cells[1, 33].Value = "PassportNumber";
                worksheet.Cells[1, 34].Value = "PFNumber";




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
                    worksheet.Cells[i + 2, 7].Value = employee.Role;
                    worksheet.Cells[i + 2, 8].Value = employee.ReportingManagerName;
                    worksheet.Cells[i + 2, 9].Value = employee.Address.Street;
                    worksheet.Cells[i + 2, 10].Value = employee.Address.City;
                    worksheet.Cells[i + 2, 11].Value = employee.Address.State;
                    worksheet.Cells[i + 2, 12].Value = employee.Address.Country;
                    worksheet.Cells[i + 2, 13].Value = employee.Address.ZipCode;
                    worksheet.Cells[i + 2, 14].Value = additionalDetails.AlternateMobile;
                    worksheet.Cells[i + 2, 15].Value = additionalDetails.AlternateEmail;
                    worksheet.Cells[i + 2, 16].Value = additionalDetails.WorkInformation.DesignationName;
                    worksheet.Cells[i + 2, 17].Value = additionalDetails.WorkInformation.LocationName;
                    worksheet.Cells[i + 2, 18].Value = additionalDetails.WorkInformation.EmployeeStatus;
                    worksheet.Cells[i + 2, 19].Value = additionalDetails.WorkInformation.SourceOfHire;
                    worksheet.Cells[i + 2, 20].Value = additionalDetails.WorkInformation.DateOfJoining;
                    worksheet.Cells[i + 2, 21].Value = additionalDetails.PersonalDetails.DateOfBirth;
                    worksheet.Cells[i + 2, 22].Value = additionalDetails.PersonalDetails.Age;
                    worksheet.Cells[i + 2, 23].Value = additionalDetails.PersonalDetails.Gender;
                    worksheet.Cells[i + 2, 24].Value = additionalDetails.PersonalDetails.Religion;
                    worksheet.Cells[i + 2, 25].Value = additionalDetails.PersonalDetails.Caste;
                    worksheet.Cells[i + 2, 26].Value = additionalDetails.PersonalDetails.MaritalStatus;
                    worksheet.Cells[i + 2, 27].Value = additionalDetails.PersonalDetails.BloodGroup;
                    worksheet.Cells[i + 2, 28].Value = additionalDetails.PersonalDetails.Height;
                    worksheet.Cells[i + 2, 29].Value = additionalDetails.PersonalDetails.Weight;
                    worksheet.Cells[i + 2, 30].Value = additionalDetails.IdentityInformation.PAN;
                    worksheet.Cells[i + 2, 31].Value = additionalDetails.IdentityInformation.Aadhar;
                    worksheet.Cells[i + 2, 32].Value = additionalDetails.IdentityInformation.Nationality;
                    worksheet.Cells[i + 2, 33].Value = additionalDetails.IdentityInformation.PassportNumber;
                    worksheet.Cells[i + 2, 34].Value = additionalDetails.IdentityInformation.PFNumber;
                    
                   
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Employees.xlsx";
                return File(stream, contentType, fileName);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeeAdditionalDetailsByBasicDetailsUIdFilterCriteria(FiltercriteriaAdditional filtercriteria)
        {
            var BasicFilter = filtercriteria.filtersadd.FirstOrDefault(f=>f.FieldName== "EmployeeBasicDetailsUId");

            var response = await _employeeService.GetEmployeeAdditionalDetailsByBasicDetailsUIdFilterCriteria(BasicFilter.FieldValue);
            return Ok(response);
        }
    }
}
