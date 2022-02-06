using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleWebApplicationWithDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public string GetOSInfo()
        {
            string returnValue;

            returnValue = Environment.OSVersion.ToString();

            return returnValue;
        }
    }
}