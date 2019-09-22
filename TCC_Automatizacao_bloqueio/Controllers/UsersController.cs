using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCC_Automatizacao_bloqueio.Models;
using TCC_Automatizacao_bloqueio.Services;
using TCC_Automatizacao_bloqueio.Services.Exceptions;

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

            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new UserFormViewModel { Departments = departments, User = user };
                return View(viewModel);
            }

            _userService.Insert(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new { message ="Id not provided"});
            }

            var obj = _userService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Delete (int id)
        {
            _userService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public  IActionResult Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _userService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _userService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = _departmentService.FindAll();
            UserFormViewModel viewModel = new UserFormViewModel { Departments = departments, User = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, User user)
        {

            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new UserFormViewModel { Departments = departments, User = user };
                return View(viewModel);
            }

            if (id != user.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _userService.Update(user);


                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
          
     
        }

        public  IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}