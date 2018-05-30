using System.Threading.Tasks;
using DynamicModelBinding.Web.Filters;
using DynamicModelBinding.Web.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace DynamicModelBinding.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/webhook")]
    public class WebHookController : Controller
    {
        [HttpPost]
        [TypeFilter(typeof(WebHookActionFilter))]
        public async Task<IActionResult> Magic(
            [ModelBinder(BinderType = typeof(DynamicBinder))]
            dynamic payload)
        {
            Response.Headers["name"] = payload.Name;
            return Ok();
        }
    }
}