using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Diploma_v._2.Models;
using DataAccessLayer.UnitOfWork;
using DataAccessLayer.Interface;
using Diploma_v._2.Models.Projects;

namespace Diploma_v._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var model = new List<IndexListViewModel>();

            foreach (var item in unitOfWork.Project.Get().ToList())
            {
                model.Add(new IndexListViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Status = item.Status,
                    UpdateAt = item.UpdateAt
                });
            }

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
