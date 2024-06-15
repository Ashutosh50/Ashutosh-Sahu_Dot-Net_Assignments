using Assignment_5__Employee_Management_System_.Common;
using Assignment_5__Employee_Management_System_.DTO;
using Assignment_5__Employee_Management_System_.Entity;
using Microsoft.Azure.Cosmos;

namespace Assignment_5__Employee_Management_System_.CosmosDB
{
    public class CosmosDBService : ICosmosDB
    {
        public readonly CosmosClient _cosmosClient;
        public readonly Container _container;
        public CosmosDBService(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer(Credential.databaseName,Credential.containerName);
        }


        public async Task<EmployeeBasicDetailsEntity> AddEmployeeBasic(EmployeeBasicDetailsEntity employee)
        {
            var response = await _container.CreateItemAsync(employee);
            return response;
        }

        public async Task<List<EmployeeBasicDetailsEntity>> GetAllEmployees()
        {
            var response =  _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == Credential.doctype).ToList();
            return response;
        }

        public async Task<EmployeeBasicDetailsEntity> GetEmployeeById(string Uid)
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(a => a.UId == Uid && a.Active == true && a.Archived == false && a.DocumentType == Credential.doctype).FirstOrDefault();
            return response;
        }

        public async Task RePlaceasync(dynamic entity)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id);
        }

        //public async Task<EmployeeBasicDetailsEntity> GetEmployeeBasicDetailsByUId(string uid)
        //{
        //    var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(a => a.UId == uid && a.Active == true && a.Archived == false && a.DocumentType == Credential.doctype).FirstOrDefault();
        //    return response;
        //}
        public async Task<EmployeeAditionalDetailsEntity> AddEmployeeAdditional(EmployeeAditionalDetailsEntity additional)
        {
            var response =await _container.CreateItemAsync(additional);
            return response;
        }

        public async Task<List<EmployeeAditionalDetailsEntity>> GetallEmployeesAdditionalDetails()
        {
            var response = _container.GetItemLinqQueryable<EmployeeAditionalDetailsEntity>(true).Where(a => a.Active == true && a.Archived == false && a.DocumentType == Credential.Adoctype).ToList();
            return response;
        }

        public async Task<EmployeeAditionalDetailsEntity> GetAdditionalDetailsById(string basicUid)
        {
            var response = _container.GetItemLinqQueryable<EmployeeAditionalDetailsEntity>(true).Where(a => a.EmployeeBasicDetailsUId == basicUid && a.Active == true && a.Archived == false && a.DocumentType == Credential.Adoctype).FirstOrDefault();
           return response;

        }
    }
}
