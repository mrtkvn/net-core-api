using Microsoft.AspNetCore.Mvc;
using NetCore.Dto.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NetCoreApi.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IActionResult ReturnResult(RequestResult result)
        {
            if (result.IsSuccess)
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }

            return StatusCode(result.StatusCode, result.Message);
        }

        protected IActionResult ReturnResult<T>(RequestResult<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result.Obj);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
