using JobTrail.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JobTrail.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid CurrentUserId => ClaimsHelper.GetId(User.Claims);
    }
}
