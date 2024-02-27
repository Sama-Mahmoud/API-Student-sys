using API01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API01.Filters
{
    public class LocationFilter : ActionFilterAttribute
    {
        private readonly string[] _allowedLocations;

        public LocationFilter(params string[] allowedLocations)
        {
            _allowedLocations = allowedLocations;
        }
        

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var department = context.ActionArguments["department"] as Department;

            // Check if the department's location is allowed
            if (!_allowedLocations.Contains(department.Location, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new BadRequestObjectResult($"Location '{department.Location}' is not allowed.");
                return;
            }

            //base.OnActionExecuting(context);
        }
    }
}
