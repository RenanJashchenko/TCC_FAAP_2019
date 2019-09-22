﻿using System;
using System.Collections.Generic;
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
            _userService.Insert(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _userService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
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
                return NotFound();
            }

            var obj = _userService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var obj = _userService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            UserFormViewModel viewModel = new UserFormViewModel { Departments = departments, User = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userService.Update(user);


                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {

                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
     
        }

    }
}