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
    [Route("api/AccessToken")]
    [ApiController]
    public class AccessTokenController : ControllerBase
    {
        public string AccessAppToken(string code)
        {
            Logger.Info("Processing AccessToken");
            AccessToken.AccessTokenApp(code);
            
            return null;
        }
    }
}
