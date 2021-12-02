using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DotNetMiddlewareSample.WebApi.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route]
        public async Task<IEnumerable<string>> GetAsync()
        {
            // 処理時間計測のため、意図的にディレイをかけます。
            await Task.Delay(new Random().Next(500, 1500));
            return new[] { "value1", "value2" };
        }
    }
}
