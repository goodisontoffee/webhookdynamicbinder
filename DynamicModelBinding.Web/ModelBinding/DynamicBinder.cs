using System.Dynamic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicModelBinding.Web.ModelBinding
{
    public class DynamicBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            using (var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body, Encoding.UTF8))
            {
                var bodyAsString = await streamReader.ReadToEndAsync();

                var converter = new ExpandoObjectConverter();    
                dynamic model = JsonConvert.DeserializeObject<ExpandoObject>(bodyAsString, converter);

                bindingContext.Result = ModelBindingResult.Success(model);
            }
        }
    }
}
