using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Diploma.Models;
using DataAccessLayer.Interface;
using Diploma.Models.Projects;
using Core.Enum;
using Diploma.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entity;

namespace Diploma.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new List<IndexListViewModel>();

            foreach (var item in unitOfWork.Project.GetWithInclude(x => x.Author).ToList())
            {
                model.Add(new IndexListViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Rate = item.Rate,
                    Status = item.Status,
                    UpdateAt = item.UpdateAt,
                    Deleted = item.Deleted,
                    Username = item.Author?.Username ?? string.Empty
                });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            StatusDropDownList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = unitOfWork.User.Get(x => x.Username == model.Username).FirstOrDefault();

                if (user != null)
                {
                    return NotFound();
                }

                var project = CreateViewModel.createToProject.Compile()(model);
                project.AuthorId = user?.Id ?? null;

                unitOfWork.Project.Create(project);
                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            StatusDropDownList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = unitOfWork.Project.GetWithInclude(x => x.Author).FirstOrDefault(y => y.Id == id);

            if (project == null)
            {
                return NotFound();
            } else
            {
                StatusDropDownList(project.Status);
                return View(EditViewModel.expression.Compile()(project));
            }
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var project = unitOfWork.Project.FindById(model.Id);

                if (project == null)
                {
                    return NotFound();
                }

                var user = unitOfWork.User.Get(x => x.Username == model.Username).FirstOrDefault();

                if (user != null)
                {
                    return NotFound();
                }

                project.Title = model.Title;
                project.Description = model.Description;
                project.Rate = model.Rate;
                project.UpdateAt = DateTime.Now;
                project.Status = model.Status;
                project.AuthorId = user?.Id ?? null;

                if (model.Status == Status.Rejected)
                {
                    project.Deleted = true;
                } else
                {
                    project.Deleted = false;
                }

                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            StatusDropDownList(model.Status);
            return View(model);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = unitOfWork.Project.FindById(id);

            if (project == null)
            {
                return NotFound();
            }
            else
            {
                unitOfWork.Project.Remove(project);
                unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [NonAction]
        private void StatusDropDownList(object selected = null)
        {
            var list = Enum.GetValues(typeof(Status)).Cast<Status>().Select(x => new EnumModel { ID = (int)x, Name = x.ToString() });
            ViewBag.StatusID = new SelectList(list, "ID", "Name", selected);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
