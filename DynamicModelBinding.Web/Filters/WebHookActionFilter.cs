using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DynamicModelBinding.Web.Filters
{
    public class WebHookActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            dynamic payload = context.ActionArguments.Single().Value;

            if (payload.Age % 2 == 0)
                await next.Invoke();
            else
                context.Result = new BadRequestResult();
        }
    }
}
