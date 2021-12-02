using Microsoft.AspNetCore.Mvc;

namespace DotNetMiddlewareSample.NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            // 処理時間計測のため、意図的にディレイをかけます。
            await Task.Delay(new Random().Next(500, 1500));
            return new[] { "value1", "value2" };
        }
    }
}
