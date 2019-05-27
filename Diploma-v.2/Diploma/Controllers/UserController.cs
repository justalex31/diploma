using Core.Entity;
using DataAccessLayer.Interface;
using Diploma.Helper;
using Diploma.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new List<IndexListViewModel>();

            foreach (var item in unitOfWork.User.GetWithInclude(p => p.Role))
            {
                model.Add(IndexListViewModel.roleToIndex.Compile()(item));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RoleDropDownList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = CreateViewModel.createToUser.Compile()(model);

                unitOfWork.User.Create(user);
                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            RoleDropDownList(model.RoleId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = unitOfWork.User.Include(x => x.Role).FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            RoleDropDownList(user.RoleId);
            return View(EditViewModel.userToEdit.Compile()(user));
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = unitOfWork.User.FindById(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.Username = model.Username;
                user.Password = model.Password;
                user.RoleId = model.RoleId;

                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            RoleDropDownList(model.Id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = unitOfWork.User.GetWithInclude(x => x.Projects).FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            
            unitOfWork.User.Remove(user);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private void RoleDropDownList(object selected = null)
        {
            var list = unitOfWork.Role.Get();
            ViewBag.RoleID = new SelectList(list, "Id", "Name", selected);
        }
    }
}
