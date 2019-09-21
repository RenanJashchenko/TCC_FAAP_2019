using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCC_Automatizacao_bloqueio.Models;
using TCC_Automatizacao_bloqueio.Services;

namespace TCC_Automatizacao_bloqueio.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserService _userService;

        private readonly DepartmentService _departmentService;

        public UsersController(UserService userService, DepartmentService departmentService)
        {
            _userService = userService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _userService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewmodel = new UserFormViewModel { Departments = departments };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            _userService.Insert(user);
            return RedirectToAction(nameof(Index));
        }

    }
}