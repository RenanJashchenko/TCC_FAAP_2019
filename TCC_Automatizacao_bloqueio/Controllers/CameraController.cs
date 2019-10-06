using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TCC_Automatizacao_bloqueio.Controllers
{
    public class CameraController : Controller
    {
        public IActionResult CapturaImagem()
        {
            return View();
        }
    }
}