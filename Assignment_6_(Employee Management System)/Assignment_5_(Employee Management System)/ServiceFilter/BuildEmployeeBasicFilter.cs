using Assignment_5__Employee_Management_System_.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_5__Employee_Management_System_.ServiceFilter
{
    public class BuildEmployeeBasicFilter : IAsyncActionFilter
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
            var statusfilter = filtercriteria.filters.Find(a => a.FieldName == "role");
            if (statusfilter == null)
            {
                statusfilter = new Filterc();
                statusfilter.FieldValue = "role";
                statusfilter.FieldValue = "string";
                filtercriteria.filters.Add(statusfilter);
            }
            filtercriteria.filters.RemoveAll(a => string.IsNullOrEmpty(a.FieldName));
            var result = await next();
        }
    }
}
