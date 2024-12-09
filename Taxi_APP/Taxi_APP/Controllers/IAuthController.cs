using Taxi_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Taxi_APP.Models;

namespace TaxiApp.Controllers
{
    public interface IAuthController
    {
        Task<ActionResult<ServiceResponse<List<string>>>> Login([FromBody] Login login);
        Task<ActionResult<ServiceResponse<string>>> Register(Register register);

    }
}
