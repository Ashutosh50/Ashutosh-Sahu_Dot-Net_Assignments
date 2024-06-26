﻿using Assignment_5__Employee_Management_System_.Common;
using Assignment_5__Employee_Management_System_.CosmosDB;
using Assignment_5__Employee_Management_System_.DTO;
using Assignment_5__Employee_Management_System_.Entity;
using Assignment_5__Employee_Management_System_.Interfaces;

namespace Assignment_5__Employee_Management_System_.Services
{
    public class EmployeeServices : IEmployeeService
    {
        public readonly ICosmosDB _cosmosDB;
        public EmployeeServices(ICosmosDB cosmosDB)
        {
            _cosmosDB = cosmosDB;
        }
        public async Task<EmployeeBasicModel> AddEmployeeBasicDetails(EmployeeBasicModel employeeBasicModel)
        {
            //make object of entity and map it
            var Employee = new EmployeeBasicDetailsEntity()
            {
                Salutory = employeeBasicModel.Salutory,
                FirstName = employeeBasicModel.FirstName,
                MiddleName = employeeBasicModel.MiddleName,
                LastName = employeeBasicModel.LastName,
                NickName = employeeBasicModel.NickName,
                Email = employeeBasicModel.Email,
                Mobile = employeeBasicModel.Mobile,
               // EmployeeID = employeeBasicModel.EmployeeID,
                Role = employeeBasicModel.Role,
                ReportingManagerUId = employeeBasicModel.ReportingManagerUId,
                ReportingManagerName = employeeBasicModel.ReportingManagerName,
                Address = new Address()
                {
                    Street = employeeBasicModel.Address.Street,
                    City = employeeBasicModel.Address.City,
                    State = employeeBasicModel.Address.State,
                    Country = employeeBasicModel.Address.Country,
                    ZipCode = employeeBasicModel.Address.ZipCode
                }
            };
            //2. Assign values to madatory fields
            Employee.Initialize(true, Credential.doctype, Credential.createdby, "Ashu");

            Employee.EmployeeID = Employee.UId;

            //3.Push to dataBase
            var response = await _cosmosDB.AddEmployeeBasic(Employee);

            //4.Return Model
            var ResEmployeeModel = new EmployeeBasicModel()
            {
                UId = response.UId,
                Salutory = response.Salutory,
                FirstName = response.FirstName,
                MiddleName = response.MiddleName,
                LastName = response.LastName,
                NickName = response.NickName,
                Email = response.Email,
                Mobile = response.Mobile,
                EmployeeID = response.EmployeeID,
                Role = response.Role,
                ReportingManagerUId = response.ReportingManagerUId,
                ReportingManagerName = response.ReportingManagerName,
                Address = new AddressDTO()
                {
                    Street = response.Address.Street,
                    City = response.Address.City,
                    State = response.Address.State,
                    Country = response.Address.Country,
                    ZipCode = response.Address.ZipCode,
                }
            };
            return ResEmployeeModel;
        }

        public async Task<List<EmployeeBasicModel>> GetAllEmployee()
        {
            var response = await _cosmosDB.GetAllEmployees();
            List<EmployeeBasicModel> employeeBasicModels = new List<EmployeeBasicModel>();
            foreach (var emp in response)
            {
                var Model = new EmployeeBasicModel()
                {
                    UId = emp.UId,
                    Salutory = emp.Salutory,
                    FirstName = emp.FirstName,
                    MiddleName = emp.MiddleName,
                    LastName = emp.LastName,
                    NickName = emp.NickName,
                    Email = emp.Email,
                    Mobile = emp.Mobile,
                    EmployeeID = emp.EmployeeID,
                    Role = emp.Role,
                    ReportingManagerName = emp.ReportingManagerName,
                    ReportingManagerUId = emp.ReportingManagerUId,
                    Address = new AddressDTO()
                    {
                        Street = emp.Address.Street,
                        City = emp.Address.City,
                        State = emp.Address.State,
                        Country = emp.Address.Country,
                        ZipCode = emp.Address.ZipCode
                    }
                };
                employeeBasicModels.Add(Model);
            }
            return employeeBasicModels;
        }

        public async Task<EmployeeBasicModel> GetEmployeeById(string Uid)
        {
            var response = await _cosmosDB.GetEmployeeById(Uid);
            var Model = new EmployeeBasicModel()
            {
                UId = response.UId,
                Salutory = response.Salutory,
                FirstName = response.FirstName,
                MiddleName = response.MiddleName,
                LastName = response.LastName,
                NickName = response.NickName,
                Email = response.Email,
                Mobile = response.Mobile,
                EmployeeID = response.EmployeeID,
                Role = response.Role,
                ReportingManagerName = response.ReportingManagerName,
                ReportingManagerUId = response.ReportingManagerUId,
                Address = new AddressDTO()
                {
                    Street = response.Address.Street,
                    City = response.Address.City,
                    State = response.Address.State,
                    Country = response.Address.Country,
                    ZipCode = response.Address.ZipCode
                }
            };
            return Model;
        }

        public async Task<EmployeeBasicModel> UpdateEmployee(EmployeeBasicModel employeeBasicModel)
        {
            var exeEmployee = await _cosmosDB.GetEmployeeById(employeeBasicModel.UId);

            exeEmployee.Active = false;
            exeEmployee.Archived = true;
            _cosmosDB.RePlaceasync(exeEmployee);

            exeEmployee.Initialize(false, Credential.doctype, Credential.createdby, "Ashu");

            exeEmployee.Salutory = employeeBasicModel.Salutory;
            exeEmployee.FirstName = employeeBasicModel.FirstName;
            exeEmployee.MiddleName = employeeBasicModel.MiddleName;
            exeEmployee.LastName = employeeBasicModel.LastName;
            exeEmployee.NickName = employeeBasicModel.NickName;
            exeEmployee.Email = employeeBasicModel.Email;
            exeEmployee.Mobile = employeeBasicModel.Mobile;
            exeEmployee.Role = employeeBasicModel.Role;
            exeEmployee.ReportingManagerUId = employeeBasicModel.ReportingManagerUId;
            exeEmployee.ReportingManagerName = employeeBasicModel.ReportingManagerName;

            //for Address
            exeEmployee.Address.Street = employeeBasicModel.Address.Street;
            exeEmployee.Address.City = employeeBasicModel.Address.City;
            exeEmployee.Address.State = employeeBasicModel.Address.State;
            exeEmployee.Address.Country = employeeBasicModel.Address.Country;
            exeEmployee.Address.ZipCode = employeeBasicModel.Address.ZipCode;

            var response = await _cosmosDB.AddEmployeeBasic(exeEmployee);

            var Updated = new EmployeeBasicModel()
            {
                Salutory = exeEmployee.Salutory,
                FirstName = exeEmployee.FirstName,
                MiddleName = exeEmployee.MiddleName,
                LastName = exeEmployee.LastName,
                NickName = exeEmployee.NickName,
                Email = exeEmployee.Email,
                Mobile = exeEmployee.Mobile,
                EmployeeID = exeEmployee.EmployeeID,
                Role = exeEmployee.Role,
                ReportingManagerUId = exeEmployee.ReportingManagerUId,
                ReportingManagerName = exeEmployee.ReportingManagerName,
                Address = new AddressDTO
                {
                    Street = exeEmployee.Address.Street,
                    City = exeEmployee.Address.City,
                    State = exeEmployee.Address.State,
                    Country = exeEmployee.Address.Country,
                    ZipCode = exeEmployee.Address.ZipCode
                }
            };
            return Updated;
        }

        public async Task<string> DeleteEmployee(string Uid)
        {
            var response = await _cosmosDB.GetEmployeeById(Uid);
            response.Active = false;
            response.Archived = true;
            await _cosmosDB.RePlaceasync(response);

            response.Initialize(false, Credential.doctype, "Ashu", "Ashu");
            response.Active = false;

            var res = await _cosmosDB.AddEmployeeBasic(response);

            return "Deleted successfully";

        }


        public async Task<EmployeeAdditionalDetailsModel> AddAdditionalDetails(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel)
        {
            var employeeBasicDetails = await _cosmosDB.GetEmployeeById(employeeAdditionalDetailsModel.EmployeeBasicDetailsUId);

            if (employeeBasicDetails == null)
            {
                throw new Exception("Employee Basic Details not found");
            }
            var Additional = new EmployeeAditionalDetailsEntity()
            {
                EmployeeBasicDetailsUId = employeeBasicDetails.UId,
                AlternateEmail = employeeAdditionalDetailsModel.AlternateEmail,
                AlternateMobile = employeeAdditionalDetailsModel.AlternateMobile,
                WorkInformation = new WorkInfo()
                {
                    DesignationName = employeeAdditionalDetailsModel.WorkInformation.DesignationName,
                    DepartmentName = employeeAdditionalDetailsModel.WorkInformation.DepartmentName,
                    LocationName = employeeAdditionalDetailsModel.WorkInformation.LocationName,
                    EmployeeStatus = employeeAdditionalDetailsModel.WorkInformation.EmployeeStatus,
                    SourceOfHire = employeeAdditionalDetailsModel.WorkInformation.SourceOfHire,
                    DateOfJoining = employeeAdditionalDetailsModel.WorkInformation.DateOfJoining,
                },
                PersonalDetails = new PersonalDetails()
                {
                    DateOfBirth = employeeAdditionalDetailsModel.PersonalDetails.DateOfBirth,
                    Age = employeeAdditionalDetailsModel.PersonalDetails.Age,
                    Gender = employeeAdditionalDetailsModel.PersonalDetails.Gender,
                    Religion = employeeAdditionalDetailsModel.PersonalDetails.Religion,
                    Caste = employeeAdditionalDetailsModel.PersonalDetails.Caste,
                    MaritalStatus = employeeAdditionalDetailsModel.PersonalDetails.MaritalStatus,
                    BloodGroup = employeeAdditionalDetailsModel.PersonalDetails.BloodGroup,
                    Height = employeeAdditionalDetailsModel.PersonalDetails.Height,
                    Weight = employeeAdditionalDetailsModel.PersonalDetails.Weight,
                },
                IdentityInformation = new IdentityInfo()
                {
                    PAN = employeeAdditionalDetailsModel.IdentityInformation.PAN,
                    Aadhar = employeeAdditionalDetailsModel.IdentityInformation.Aadhar,
                    Nationality = employeeAdditionalDetailsModel.IdentityInformation.Nationality,
                    PassportNumber = employeeAdditionalDetailsModel.IdentityInformation.PassportNumber,
                    PFNumber = employeeAdditionalDetailsModel.IdentityInformation.PFNumber
                }
            };

            Additional.Initialize(true, Credential.Adoctype, Credential.createdby, "Ashu");

            var response = await _cosmosDB.AddEmployeeAdditional(Additional);

            var ResEmployeeModel = new EmployeeAdditionalDetailsModel()
            {
                EmployeeBasicDetailsUId = response.EmployeeBasicDetailsUId,
                AlternateEmail = response.AlternateEmail,
                AlternateMobile = response.AlternateMobile,
                WorkInformation = new WorkInfoModel()
                {

                    DesignationName = response.WorkInformation.DesignationName,
                    DepartmentName = response.WorkInformation.DepartmentName,
                    LocationName = response.WorkInformation.LocationName,
                    EmployeeStatus = response.WorkInformation.EmployeeStatus,
                    SourceOfHire = response.WorkInformation.SourceOfHire,
                    DateOfJoining = response.WorkInformation.DateOfJoining,
                },
                PersonalDetails = new PersonalDetailsModel()
                {

                    DateOfBirth = response.PersonalDetails.DateOfBirth,
                    Age = response.PersonalDetails.Age,
                    Gender = response.PersonalDetails.Gender,
                    Religion = response.PersonalDetails.Religion,
                    Caste = response.PersonalDetails.Caste,
                    MaritalStatus = response.PersonalDetails.MaritalStatus,
                    BloodGroup = response.PersonalDetails.BloodGroup,
                    Height = response.PersonalDetails.Height,
                    Weight = response.PersonalDetails.Weight,

                },
                IdentityInformation = new IdentityInfoModel()
                {

                    PAN = response.IdentityInformation.PAN,
                    Aadhar = response.IdentityInformation.Aadhar,
                    Nationality = response.IdentityInformation.Nationality,
                    PassportNumber = response.IdentityInformation.PassportNumber,
                    PFNumber = response.IdentityInformation.PFNumber
                }
            };
            return ResEmployeeModel;
        }

        public async Task<List<EmployeeAdditionalDetailsModel>> GetAllEmployeeAdditionalDetails()
        {
            var response = await _cosmosDB.GetallEmployeesAdditionalDetails();
            List<EmployeeAdditionalDetailsModel> employeeAdditionalDetailsModels = new List<EmployeeAdditionalDetailsModel>();
            foreach (var emp in response) 
            {
                var additionalModel = new EmployeeAdditionalDetailsModel() 
                {
                    EmployeeBasicDetailsUId = emp.EmployeeBasicDetailsUId,
                    AlternateEmail = emp.AlternateEmail,
                    AlternateMobile = emp.AlternateMobile,
                    WorkInformation = new WorkInfoModel()
                    {
                            DesignationName = emp.WorkInformation.DesignationName,
                            DepartmentName = emp.WorkInformation.DepartmentName,
                            LocationName = emp.WorkInformation.LocationName,
                            EmployeeStatus = emp.WorkInformation.EmployeeStatus,
                            SourceOfHire = emp.WorkInformation.SourceOfHire,
                            DateOfJoining= emp.WorkInformation.DateOfJoining,
                    },
                    PersonalDetails = new PersonalDetailsModel() 
                    {
                        DateOfBirth = emp.PersonalDetails.DateOfBirth,
                           Age = emp.PersonalDetails.Age,
                           Gender = emp.PersonalDetails.Gender,
                            Religion = emp.PersonalDetails.Religion,
                            Caste = emp.PersonalDetails.Caste,
                           MaritalStatus = emp.PersonalDetails.MaritalStatus,
                            BloodGroup = emp.PersonalDetails.BloodGroup,
                            Height = emp.PersonalDetails.Height,
                            Weight = emp.PersonalDetails.Weight,
                    },
                    IdentityInformation= new IdentityInfoModel() 
                    {
                            PAN = emp.IdentityInformation.PAN,
                            Aadhar = emp.IdentityInformation.Aadhar,
                            Nationality = emp.IdentityInformation.Nationality,
                            PassportNumber = emp.IdentityInformation.PassportNumber,
                            PFNumber = emp.IdentityInformation.PFNumber
                    }
                };
                employeeAdditionalDetailsModels.Add(additionalModel);
            }
            return employeeAdditionalDetailsModels;
        }

        public async Task<EmployeeAdditionalDetailsModel> GetAdditionalDetailsById(string basicUid)
        {
            var response = await _cosmosDB.GetAdditionalDetailsById(basicUid);
            var Model = new EmployeeAdditionalDetailsModel()
            { 
            EmployeeBasicDetailsUId= response.EmployeeBasicDetailsUId,
            AlternateEmail = response.AlternateEmail,
            AlternateMobile=response.AlternateMobile,
            WorkInformation =new WorkInfoModel() 
            {
                DesignationName = response.WorkInformation.DesignationName,
                DepartmentName = response.WorkInformation.DepartmentName,
                LocationName = response.WorkInformation.LocationName,
                EmployeeStatus = response.WorkInformation.EmployeeStatus,
                SourceOfHire = response.WorkInformation.SourceOfHire,
                DateOfJoining = response.WorkInformation.DateOfJoining,
            },
            PersonalDetails =new PersonalDetailsModel() 
            {
                DateOfBirth = response.PersonalDetails.DateOfBirth,
                Age = response.PersonalDetails.Age,
                Gender = response.PersonalDetails.Gender,
                Religion = response.PersonalDetails.Religion,
                Caste = response.PersonalDetails.Caste,
                MaritalStatus = response.PersonalDetails.MaritalStatus,
                BloodGroup = response.PersonalDetails.BloodGroup,
                Height = response.PersonalDetails.Height,
                Weight = response.PersonalDetails.Weight,
            },
            IdentityInformation = new IdentityInfoModel() 
            {
                PAN = response.IdentityInformation.PAN,
                Aadhar = response.IdentityInformation.Aadhar,
                Nationality = response.IdentityInformation.Nationality,
                PassportNumber = response.IdentityInformation.PassportNumber,
                PFNumber = response.IdentityInformation.PFNumber
            }
            };
            return Model;
        }

        public async Task<EmployeeAdditionalDetailsModel> UpdateAdditionalDetails(EmployeeAdditionalDetailsModel employeeAdditionalDetailsModel)
        {
            var exeAdditionalDetail = await _cosmosDB.GetAdditionalDetailsById(employeeAdditionalDetailsModel.EmployeeBasicDetailsUId);
            exeAdditionalDetail.Active = false;
            exeAdditionalDetail.Archived = true;
            _cosmosDB.RePlaceasync(exeAdditionalDetail);

            exeAdditionalDetail.Initialize(false, Credential.Adoctype, Credential.createdby, "Ashu");


            exeAdditionalDetail.AlternateEmail=employeeAdditionalDetailsModel.AlternateEmail;
            exeAdditionalDetail.AlternateMobile=employeeAdditionalDetailsModel.AlternateMobile;

            //Work
            exeAdditionalDetail.WorkInformation.DesignationName=employeeAdditionalDetailsModel.WorkInformation.DesignationName;
            exeAdditionalDetail.WorkInformation.DepartmentName = employeeAdditionalDetailsModel.WorkInformation.DepartmentName;
            exeAdditionalDetail.WorkInformation.LocationName= employeeAdditionalDetailsModel.WorkInformation.LocationName;
            exeAdditionalDetail.WorkInformation.EmployeeStatus= employeeAdditionalDetailsModel.WorkInformation.EmployeeStatus;
            exeAdditionalDetail.WorkInformation.SourceOfHire= employeeAdditionalDetailsModel.WorkInformation.SourceOfHire;
            exeAdditionalDetail.WorkInformation.DateOfJoining= employeeAdditionalDetailsModel.WorkInformation.DateOfJoining;

            //Personal
            exeAdditionalDetail.PersonalDetails.DateOfBirth=employeeAdditionalDetailsModel.PersonalDetails.DateOfBirth;
            exeAdditionalDetail.PersonalDetails.Age=employeeAdditionalDetailsModel.PersonalDetails.Age;
            exeAdditionalDetail.PersonalDetails.Gender = employeeAdditionalDetailsModel.PersonalDetails.Gender;
                exeAdditionalDetail.PersonalDetails.Religion=employeeAdditionalDetailsModel.PersonalDetails.Religion;
            exeAdditionalDetail.PersonalDetails.Caste = employeeAdditionalDetailsModel.PersonalDetails.Caste;
            exeAdditionalDetail.PersonalDetails.MaritalStatus = employeeAdditionalDetailsModel.PersonalDetails.MaritalStatus;
            exeAdditionalDetail.PersonalDetails.BloodGroup = employeeAdditionalDetailsModel.PersonalDetails.BloodGroup;
            exeAdditionalDetail.PersonalDetails.Height = employeeAdditionalDetailsModel.PersonalDetails.Height;
            exeAdditionalDetail.PersonalDetails.Weight = employeeAdditionalDetailsModel.PersonalDetails.Weight;

            //Info
            exeAdditionalDetail.IdentityInformation.PAN=employeeAdditionalDetailsModel.IdentityInformation.PAN;
            exeAdditionalDetail.IdentityInformation.Aadhar=employeeAdditionalDetailsModel.IdentityInformation.Aadhar;
            exeAdditionalDetail.IdentityInformation.Nationality=employeeAdditionalDetailsModel.IdentityInformation.Nationality;
            exeAdditionalDetail.IdentityInformation.PassportNumber = employeeAdditionalDetailsModel.IdentityInformation.PassportNumber;
            exeAdditionalDetail.IdentityInformation.PFNumber=employeeAdditionalDetailsModel.IdentityInformation.PFNumber;

            var response = await _cosmosDB.AddEmployeeAdditional(exeAdditionalDetail);

            var Updated = new EmployeeAdditionalDetailsModel()
            {
                AlternateEmail = exeAdditionalDetail.AlternateEmail,
                AlternateMobile = exeAdditionalDetail.AlternateMobile,
                WorkInformation = new WorkInfoModel()
                {
                    DesignationName = exeAdditionalDetail.WorkInformation.DesignationName,
                    DepartmentName = exeAdditionalDetail.WorkInformation.DepartmentName,
                    LocationName = exeAdditionalDetail.WorkInformation.LocationName,
                    EmployeeStatus = exeAdditionalDetail.WorkInformation.EmployeeStatus,
                    SourceOfHire = exeAdditionalDetail.WorkInformation.SourceOfHire,
                    DateOfJoining = exeAdditionalDetail.WorkInformation.DateOfJoining,
                },
                PersonalDetails = new PersonalDetailsModel() 
                {
                    DateOfBirth = exeAdditionalDetail.PersonalDetails.DateOfBirth,
                    Age = exeAdditionalDetail.PersonalDetails.Age,
                    Gender = exeAdditionalDetail.PersonalDetails.Gender,
                    Religion = exeAdditionalDetail.PersonalDetails.Religion,
                    Caste = exeAdditionalDetail.PersonalDetails.Caste,
                    MaritalStatus = exeAdditionalDetail.PersonalDetails.MaritalStatus,
                    BloodGroup = exeAdditionalDetail.PersonalDetails.BloodGroup,
                    Height = exeAdditionalDetail.PersonalDetails.Height,
                    Weight = exeAdditionalDetail.PersonalDetails.Weight,
                },
                IdentityInformation= new IdentityInfoModel() 
                {
                    PAN = exeAdditionalDetail.IdentityInformation.PAN,
                    Aadhar = exeAdditionalDetail.IdentityInformation.Aadhar,
                    Nationality = exeAdditionalDetail.IdentityInformation.Nationality,
                    PassportNumber = exeAdditionalDetail.IdentityInformation.PassportNumber,
                    PFNumber = exeAdditionalDetail.IdentityInformation.PFNumber
                }
            };
            return Updated;
        }

        public async Task<string> DeleteAddtionalData(string Uid)
        {
            var response = await _cosmosDB.GetAdditionalDetailsById(Uid);
            response.Active = false;
            response.Archived = true;
            await _cosmosDB.RePlaceasync(response);

            response.Initialize(false, Credential.doctype, "Ashu", "Ashu");
            response.Active = false;

            var res = await _cosmosDB.AddEmployeeAdditional(response);

            return "Deleted successfully";
        }
    }
}
