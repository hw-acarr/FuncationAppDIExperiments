using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionFunctions
{
    public class HttpTriggerFunction
    {
        private readonly IRepository _repository;
        private readonly ICci _cci;
        public HttpTriggerFunction(IRepository repository, ICci cci)
        {
            _repository = repository;
            _cci = cci;
        }

        [FunctionName("HttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest request, ILogger log)
        {
            log.LogInformation("C# HTTP Trigger Function processed a request");
            var somedata = _repository.GetData() + ":" + _cci.GetCCI();
            return new OkObjectResult(somedata);
        }
    }
}