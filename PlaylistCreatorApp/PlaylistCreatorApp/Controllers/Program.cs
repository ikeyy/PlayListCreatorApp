using Microsoft.AspNetCore.Mvc;
using PlaylistCreatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistCreatorApp.Controllers
{
    public class Program : Controller
    {
        public IActionResult Index()
        {
            //Authorization.AuthorizeApp();

            return View();
        }
    }
}
