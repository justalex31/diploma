using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using DataAccessLayer.Interface;
using Diploma.Models.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var model = new List<IndexListViewModel>();

            foreach (var item in unitOfWork.Role.Get())
            {
                model.Add(IndexListViewModel.roleToIndex.Compile()(item));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = CreateViewModel.createToRole.Compile()(model);

                unitOfWork.Role.Create(role);
                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id != null)
            {
                return NotFound();
            }

            var role = unitOfWork.Role.FindById(id);

            if (role != null)
            {
                return NotFound();
            }

            return View(EditViewModel.roleToEdit.Compile()(role));
        }
        
        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = unitOfWork.Role.FindById(model.Id);

                if (role == null)
                {
                    return NotFound();
                }

                role.Name = model.Name;
                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = unitOfWork.Role.FindById(id);

            if (role == null)
            {
                return NotFound();
            } else
            {
                unitOfWork.Role.Remove(role);
                unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}