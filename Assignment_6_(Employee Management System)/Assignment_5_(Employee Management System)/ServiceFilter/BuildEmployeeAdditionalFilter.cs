using Assignment_5__Employee_Management_System_.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Assignment_5__Employee_Management_System_.ServiceFilter
{
    public class BuildEmployeeAdditionalFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is FiltercriteriaAdditional);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Obj is null");
                return;
            }
            FiltercriteriaAdditional filtercriteria = (FiltercriteriaAdditional)param.Value;
            var statusfilter = filtercriteria.filtersadd.Find(a => a.FieldName == "employeestatus");
            if (statusfilter == null)
            {
                statusfilter = new FiltercAdditional()
                {
                    FieldName = "employeestatus",
                    FieldValue = "string"
                };
                filtercriteria.filtersadd.Add(statusfilter);
            }
            filtercriteria.filtersadd.RemoveAll(a => string.IsNullOrEmpty(a.FieldName));
            var result = await next();
        }
    }
}
