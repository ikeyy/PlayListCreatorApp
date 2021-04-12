using LoggerLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaylistCreatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistCreatorApp.Controllers
{
    [Route("api/Authorization")]

    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public string AuthorizationApp()
        {
            Logger.Info("Processing Authorization");
            string result = Authorization.AuthorizeApp();

            return result;
        }

    }
}
