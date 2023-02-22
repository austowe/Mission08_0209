using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_0209.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_0209.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext taskContext { get; set; }

        public HomeController(TaskContext tc)
        {
            taskContext = tc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = taskContext.Category.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Models.Task nt)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(nt);
                taskContext.SaveChanges();
                return View("Confirmation", nt);
            }

            else
            {
                ViewBag.Categories = taskContext.Category.ToList();

                return View();
            }

        }

        [HttpGet]
        public IActionResult Quadrant()
        {
            var tasks = taskContext.Tasks
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = taskContext.Category.ToList();

            var task = taskContext.Tasks.Single(x => x.TaskId == taskid);

            return View("AddTask", task);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task nt)
        {
            taskContext.Update(nt);
            taskContext.SaveChanges();

            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = taskContext.Tasks.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Models.Task nt)
        {
            taskContext.Tasks.Remove(nt);
            taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

    }
}
