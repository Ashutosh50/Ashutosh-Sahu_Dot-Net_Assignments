using Assignment_5__Employee_Management_System_.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_5__Employee_Management_System_.ServiceFilter
{
    public class BuildEmployeeAdditionalGetAll:IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is Filtercriteria);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Obj is null");
                return;
            }

            Filtercriteria filtercriteria = (Filtercriteria)param.Value;
            //var statusfilter = filtercriteria.filters.Find(a => a.FieldName == "role");
            //if (statusfilter == null)
            //{
            //    statusfilter = new Filterc()
            //    {
            //        FieldName = "role",
            //        FieldValue = "string"
            //    };
            //    filtercriteria.filters.Add(statusfilter);
            //}
            filtercriteria.filters.RemoveAll(a => string.IsNullOrEmpty(a.FieldName));
            await next();
        }
    }
}
