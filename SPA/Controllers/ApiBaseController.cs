using Microsoft.AspNetCore.Mvc;

namespace SPA.Controllers
{
    /// <summary>
    /// Simple base class for our api controllers that implements controllerBase,
    /// this saves having to add the apiController attribute and writing the route
    /// out every-time where i could type it wrong. The route uses [controller]
    /// which will use the first part of the controller name even when the
    /// controller inherits this class e.g AdminController : ApiBaseController
    /// then the route to that controller would be api/admin    .
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBaseController : ControllerBase
    {

    }
}